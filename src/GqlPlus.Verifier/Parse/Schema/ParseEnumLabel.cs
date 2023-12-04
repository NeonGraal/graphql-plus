using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseEnumLabel : Parser<EnumLabelAst>.I
{
  private readonly Parser<string>.LA _aliases;

  public ParseEnumLabel(Parser<string>.DA aliases)
    => _aliases = aliases;

  public IResult<EnumLabelAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    var at = tokens.At;

    if (!tokens.Identifier(out var value)) {
      return tokens.Error<EnumLabelAst>(label, "label");
    }

    var enumAliases = _aliases.Parse(tokens, "Enum Label");
    var enumLabel = enumAliases.IsOk()
      ? new EnumLabelAst(at, value, description) { Aliases = enumAliases.Required() }
      : new EnumLabelAst(at, value, description);

    return enumAliases.AsPartial(enumLabel);
  }
}
