using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseField(
  IParserRepository parsers
) : IParser<IAstField>
{
  private readonly ParserArray<IAstModifier> _modifiers = parsers.ArrayFor<IAstModifier>();
  private readonly ParserArray<IAstDirective> _directives = parsers.ArrayFor<IAstDirective>();
  private readonly ParserOne<IParserArg, IAstArg> _argument = parsers.ParserFor<IParserArg, IAstArg>();
  private readonly ParserArray<IAstSelection> _object = parsers.ArrayFor<IAstSelection>();

  public IResult<IAstField> Parse([NotNull] ITokenizer tokens, string label)

  {
    TokenAt at = tokens.At;
    if (!tokens.Identifier(out string? alias)) {
      return tokens.Error<IAstField>(label, "initial identifier");
    }

    FieldAst result = new(at, alias);

    if (tokens.Take(':')) {
      at = tokens.At;
      if (!tokens.Identifier(out string? name)) {
        return tokens.Error<IAstField>(label, "a name after an alias");
      }

      result = new FieldAst(at, name) { FieldAlias = alias };
    }

    _argument.Parse(tokens, "Arg").Required(argument => result.Arg = argument);

    IResultArray<IAstModifier> modifiers = _modifiers.Parse(tokens, label);
    if (!modifiers.Optional(value => result.Modifiers = [.. value])) {
      return modifiers.AsPartial<IAstField>(result);
    }

    IResultArray<IAstDirective> directives = _directives.Parse(tokens, label);
    if (!directives.Optional(value => result.Directives = [.. value])) {
      return directives.AsPartial<IAstField>(result);
    }

    IResultArray<IAstSelection> selections = _object.Parse(tokens, label);
    return !selections.Optional(value => result.Selections = [.. value])
      ? selections.AsPartial<IAstField>(result)
      : result.Ok<IAstField>();
  }

  internal static ParseField Factory(IParserRepository p) => new(p);
}
