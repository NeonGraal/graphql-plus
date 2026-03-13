using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseOperationDecl(
  IParserRepository parsers
) : DeclarationParser<OperationDefinition, IGqlpSchemaOperation>(parsers)
{
  protected override IGqlpSchemaOperation MakeResult(AstPartial<NullAst, NullOption> partial, OperationDefinition value)
        => new OperationDeclAst(partial.At, partial.Name, partial.Description, value.Category) {
          Aliases = partial.Aliases,
        };

  protected override IGqlpSchemaOperation ToResult(AstPartial<NullAst, NullOption> partial)
    => new OperationDeclAst(partial.At, partial.Name, partial.Description, partial.Name) {
      Aliases = partial.Aliases,
    };
}

internal record OperationDefinition(string Category)
{
  public IEnumerable<IGqlpVariable> Variables { get; set; } = [];
  public IGqlpArg? Argument { get; set; }
  public string? ResultType { get; set; }
  public IEnumerable<IGqlpSelection>? ResultObject { get; set; } = [];
  public IEnumerable<IGqlpFragment> Fragments { get; set; } = [];
  public IEnumerable<IGqlpDirective> Directives { get; set; } = [];
  public IEnumerable<IGqlpModifier> Modifiers { get; set; } = [];
}

internal class ParseOperationDefinition(
  IParserRepository parsers
) : Parser<OperationDefinition>.I
{
  private readonly Parser<IParserArg, IGqlpArg>.L _argument = parsers.ParserFor<IParserArg, IGqlpArg>();
  private readonly Parser<IGqlpDirective>.LA _directives = parsers.ArrayFor<IGqlpDirective>();
  private readonly ParserArray<IParserStartFragments, IGqlpFragment>.LA _fragments = parsers.ArrayFor<IParserStartFragments, IGqlpFragment>();
  private readonly Parser<IGqlpModifier>.LA _modifiers = parsers.ArrayFor<IGqlpModifier>();
  private readonly Parser<IGqlpSelection>.LA _object = parsers.ArrayFor<IGqlpSelection>();
  private readonly Parser<IGqlpVariable>.LA _variables = parsers.ArrayFor<IGqlpVariable>();

  public IResult<OperationDefinition> Parse(ITokenizer tokens, string label)
  {
    if (!tokens.Identifier(out string? category)) {
      return tokens.Error<OperationDefinition>(label, "category");
    }

    OperationDefinition result = new(category);

    IResultArray<IGqlpVariable> variables = _variables.Parse(tokens, label);
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
      IResult<IGqlpArg> argument = _argument.I.Parse(tokens, "Arg");
      if (!argument.Optional(value => result.Argument = value)) {
        return argument.AsPartial(result);
      }
    } else if (!_object.Parse(tokens, label).Required(selections => result.ResultObject = [.. selections])) {
      return tokens.Partial(label, "Object or Type", () => result);
    }

    IResultArray<IGqlpModifier> modifiers = _modifiers.Parse(tokens, label);

    if (modifiers.IsError()) {
      return modifiers.AsPartial(result);
    }

    modifiers.WithResult(value => result.Modifiers = value.ArrayOf<ModifierAst>());

    return tokens.End(label, () => result);
  }
}
