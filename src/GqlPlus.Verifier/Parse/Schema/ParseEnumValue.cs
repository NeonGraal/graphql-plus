using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseEnumValue(
  Parser<string>.DA aliases
) : Parser<EnumValueAst>.I
{
  private readonly Parser<string>.LA _aliases = aliases;

  public IResult<EnumValueAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    var at = tokens.At;

    if (!tokens.Identifier(out var value)) {
      return tokens.Error<EnumValueAst>(label, "value");
    }

    var enumAliases = _aliases.Parse(tokens, "Enum Value");
    var enumValue = enumAliases.IsOk()
      ? new EnumValueAst(at, value, description) { Aliases = enumAliases.Required() }
      : new EnumValueAst(at, value, description);

    return enumAliases.AsPartial(enumValue);
  }
}
