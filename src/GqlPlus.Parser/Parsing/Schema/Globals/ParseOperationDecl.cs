using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseOperationDecl(
  IParserRepository parsers
) : DeclarationParser<OperationDefinition, IAstSchemaOperation>(parsers)
{
  protected override IAstSchemaOperation MakeResult(AstPartial<NullAst, NullOption> partial, OperationDefinition value)
        => new OperationDeclAst(partial.At, partial.Name, partial.Description, value.Category) {
          Aliases = partial.Aliases,
        };

  protected override IAstSchemaOperation ToResult(AstPartial<NullAst, NullOption> partial)
    => new OperationDeclAst(partial.At, partial.Name, partial.Description, partial.Name) {
      Aliases = partial.Aliases,
    };
}

internal record OperationDefinition(string Category)
{
  public IEnumerable<IAstVariable> Variables { get; set; } = [];
  public IAstArg? Argument { get; set; }
  public string? ResultType { get; set; }
  public IEnumerable<IAstSelection>? ResultObject { get; set; } = [];
  public IEnumerable<IAstFragment> Fragments { get; set; } = [];
  public IEnumerable<IAstDirective> Directives { get; set; } = [];
  public IEnumerable<IAstModifier> Modifiers { get; set; } = [];
}

internal class ParseOperationDefinition(
  IParserRepository parsers
) : Parser<OperationDefinition>.I
{
  private readonly Parser<IParserArg, IAstArg>.L _argument = parsers.ParserFor<IParserArg, IAstArg>();
  private readonly Parser<IAstDirective>.LA _directives = parsers.ArrayFor<IAstDirective>();
  private readonly ParserArray<IParserStartFragments, IAstFragment>.LA _fragments = parsers.ArrayFor<IParserStartFragments, IAstFragment>();
  private readonly Parser<IAstModifier>.LA _modifiers = parsers.ArrayFor<IAstModifier>();
  private readonly Parser<IAstSelection>.LA _object = parsers.ArrayFor<IAstSelection>();
  private readonly Parser<IAstVariable>.LA _variables = parsers.ArrayFor<IAstVariable>();

  public IResult<OperationDefinition> Parse(ITokenizer tokens, string label)
  {
    if (!tokens.Identifier(out string? category)) {
      return tokens.Error<OperationDefinition>(label, "category");
    }

    OperationDefinition result = new(category);

    IResultArray<IAstVariable> variables = _variables.Parse(tokens, label);
    if (!variables.Optional(value => result.Variables = [.. value])) {
      return variables.AsPartial(result);
    }

    _directives.Parse(tokens, label).Required(directives => result.Directives = [.. directives]);

    _fragments.I.Parse(tokens, label).WithResult(value => result.Fragments = [.. value]);
    if (!tokens.Prefix(':', out string? resultType, out _)) {
      return tokens.Partial(label, "identifier to follow ':'", () => result);
    }

    if (resultType is not null) {
      result.ResultType = resultType;
      IResult<IAstArg> argument = _argument.I.Parse(tokens, "Arg");
      if (!argument.Optional(value => result.Argument = value)) {
        return argument.AsPartial(result);
      }
    } else if (!_object.Parse(tokens, label).Required(selections => result.ResultObject = [.. selections])) {
      return tokens.Partial(label, "Object or Type", () => result);
    }

    IResultArray<IAstModifier> modifiers = _modifiers.Parse(tokens, label);

    if (modifiers.IsError()) {
      return modifiers.AsPartial(result);
    }

    modifiers.WithResult(value => result.Modifiers = value.ArrayOf<ModifierAst>());

    return tokens.End(label, () => result);
  }
}
