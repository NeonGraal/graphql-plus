using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Simple;

internal class ParseEnumMember(
  Parser<string>.DA aliases
) : Parser<EnumMemberAst>.I
{
  private readonly Parser<string>.LA _aliases = aliases;

  public IResult<EnumMemberAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    var at = tokens.At;

    if (!tokens.Identifier(out var value)) {
      return tokens.Error<EnumMemberAst>(label, "member");
    }

    var enumAliases = _aliases.Parse(tokens, "Enum Member");
    var enumMember = enumAliases.IsOk()
      ? new EnumMemberAst(at, value, description) { Aliases = enumAliases.Required() }
      : new EnumMemberAst(at, value, description);

    return enumAliases.AsPartial(enumMember);
  }
}
