using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseEnumLabel : IParser<EnumLabelAst>
{
  private readonly Parser<string>.LA _aliases;

  public ParseEnumLabel(Parser<string>.DA aliases)
    => _aliases = aliases;

  public IResult<EnumLabelAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    var at = tokens.At;

    if (!tokens.Identifier(out var label)) {
      return tokens.Error<EnumLabelAst>("Enum", "label");
    }

    var enumAliases = _aliases.Parse(tokens, "Enum Label");
    var enumLabel = enumAliases.IsOk()
      ? new EnumLabelAst(at, label, description) { Aliases = enumAliases.Required() }
      : new EnumLabelAst(at, label, description);

    return enumAliases.AsPartial(enumLabel);
  }
}
