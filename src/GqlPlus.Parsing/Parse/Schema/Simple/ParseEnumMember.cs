﻿using GqlPlus.Ast.Schema.Simple;
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
    tokens.TakeDescription();
    TokenAt at = tokens.At;

    string description = tokens.GetDescription();
    if (!tokens.Identifier(out string? value)) {
      return tokens.Error<EnumMemberAst>(label, "member");
    }

    IResultArray<string> enumAliases = _aliases.Parse(tokens, "Enum Member");
    EnumMemberAst enumMember = enumAliases.IsOk()
      ? new EnumMemberAst(at, value, description) { Aliases = [.. enumAliases.Required()] }
      : new EnumMemberAst(at, value, description);

    return enumAliases.AsPartial(enumMember);
  }
}
