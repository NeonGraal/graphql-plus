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
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<OperationDefinition>.D definition
) : DeclarationParser<OperationDefinition, IGqlpSchemaOperation>(name, param, aliases, option, definition)
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
  Parser<IParserArg, IGqlpArg>.D argument,
  Parser<IGqlpDirective>.DA directives,
  ParserArray<IParserStartFragments, IGqlpFragment>.DA fragments,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpSelection>.DA objectParser,
  Parser<IGqlpVariable>.DA variables
) : Parser<OperationDefinition>.I
{
  private readonly Parser<IParserArg, IGqlpArg>.L _argument = argument;
  private readonly Parser<IGqlpDirective>.LA _directives = directives;
  private readonly ParserArray<IParserStartFragments, IGqlpFragment>.LA _fragments = fragments;
  private readonly Parser<IGqlpModifier>.LA _modifiers = modifiers;
  private readonly Parser<IGqlpSelection>.LA _object = objectParser;
  private readonly Parser<IGqlpVariable>.LA _variables = variables;

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
      if (!argument.Optional(value => result.Argument = (ArgAst?)value)) {
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
