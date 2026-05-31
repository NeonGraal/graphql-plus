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
          Variables = value.Variables ?? [],
          Argument = value.Argument,
          Directives = value.Directives,
          Domain = value.Domain,
          Fragments = value.Fragments,
          Modifiers = value.Modifiers,
          Selections = value.Selections ?? [],
        };

  protected override IAstSchemaOperation ToResult(AstPartial<NullAst, NullOption> partial)
    => new OperationDeclAst(partial.At, partial.Name, partial.Description, partial.Name) {
      Aliases = partial.Aliases,
    };

  internal static ParseOperationDecl Factory(IParserRepository p) => new(p);
}

internal record OperationDefinition(string Category)
{
  public IEnumerable<IAstVariable> Variables { get; set; } = [];
  public IAstArg? Argument { get; set; }
  public IAstTypeRef? Domain { get; set; }
  public IEnumerable<IAstSelection> Selections { get; set; } = [];
  public IEnumerable<IAstFragment> Fragments { get; set; } = [];
  public IEnumerable<IAstDirective> Directives { get; set; } = [];
  public IEnumerable<IAstModifier> Modifiers { get; set; } = [];
}

internal class ParseOperationDefinition(
  IParserRepository parsers
) : IParser<OperationDefinition>
{
  private readonly ParserOne<IParserArg, IAstArg> _argument = parsers.ParserFor<IParserArg, IAstArg>();
  private readonly ParserArray<IAstDirective> _directives = parsers.ArrayFor<IAstDirective>();
  private readonly ParserArray<IParserStartFragments, IAstFragment> _fragments = parsers.ArrayFor<IParserStartFragments, IAstFragment>();
  private readonly ParserArray<IAstModifier> _modifiers = parsers.ArrayFor<IAstModifier>();
  private readonly ParserArray<IAstSelection> _object = parsers.ArrayFor<IAstSelection>();
  private readonly ParserOne<IAstTypeRef> _resultType = parsers.ParserFor<IAstTypeRef>();
  private readonly ParserArray<IAstVariable> _variables = parsers.ArrayFor<IAstVariable>();

  public IResult<OperationDefinition> Parse([NotNull] ITokenizer tokens, string label)
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

    _fragments.Parse(tokens, label).WithResult(value => result.Fragments = [.. value]);
    if (tokens.Take(':')) {
      IResult<IAstTypeRef>? resultType = _resultType.Parse(tokens, label);
      if (!resultType.Required(v => result.Domain = v)) {
        return resultType.AsPartial(result);
      }

      IResult<IAstArg> argument = _argument.I.Parse(tokens, "Arg");
      if (!argument.Optional(value => result.Argument = value)) {
        return argument.AsPartial(result);
      }
    } else if (!_object.Parse(tokens, label).Required(selections => result.Selections = [.. selections])) {
      return tokens.Partial(label, "Object or Type", () => result);
    }

    IResultArray<IAstModifier> modifiers = _modifiers.Parse(tokens, label);

    if (modifiers.IsError()) {
      return modifiers.AsPartial(result);
    }

    modifiers.WithResult(value => result.Modifiers = value.ArrayOf<ModifierAst>());

    return tokens.End(label, () => result);
  }

  internal static ParseOperationDefinition Factory(IParserRepository p) => new(p);
}
