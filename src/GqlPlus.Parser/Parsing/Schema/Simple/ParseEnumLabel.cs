using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseEnumLabel(
  Parser<string>.DA aliases
) : Parser<IGqlpEnumLabel>.I
{
  private readonly Parser<string>.LA _aliases = aliases;

  public IResult<IGqlpEnumLabel> Parse(ITokenizer tokens, string label)

  {
    string description = tokens.Description();
    TokenAt at = tokens.At;
    if (!tokens.Identifier(out string? value)) {
      return tokens.Error<IGqlpEnumLabel>(label, "label");
    }

    IResultArray<string> enumAliases = _aliases.Parse(tokens, "Enum Label");
    EnumLabelAst enumLabel = enumAliases.IsOk()
      ? new EnumLabelAst(at, value, description) { Aliases = [.. enumAliases.Required()] }
      : new EnumLabelAst(at, value, description);

    return enumAliases.AsPartial<IGqlpEnumLabel>(enumLabel);
  }
}
