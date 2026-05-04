using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomainRegex(
  IParserRepository parsers
) : ParseDomainItem<IAstDomainRegex>(parsers)
{
  public override DomainKind Kind => DomainKind.String;

  public override IResult<IAstDomainRegex> Parse(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    TokenAt at = tokens.At;
    IAstDomainRegex? result;
    bool excluded = tokens.Take('!');
    if (tokens.Regex(out string? regex)) {
      result = new DomainRegexAst(at, description, excluded, regex);
      return result.Ok();
    }

    result = new DomainRegexAst(at, description, false, regex.IfWhiteSpace());
    return string.IsNullOrEmpty(regex)
      ? excluded
        ? tokens.Error(label, "regex after '!'", result)
        : result.Empty()
      : tokens.Error(label, "Closing '/'", result);
  }

  protected override void ApplyItems(
    ITokenizer tokens,
    string label,
    DomainDefinition result,
    IAstDomainRegex[] items
  )
    => result.Regexes = items.ArrayOf<DomainRegexAst>();

  internal static ParseDomainRegex Factory(IParserRepository p) => new(p);
}
