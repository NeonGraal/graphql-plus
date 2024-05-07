using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomainRegex(
  Parser<DomainRegexAst>.DA items
) : ParseDomainItem<DomainRegexAst>(items)
{
  public override DomainKind Kind => DomainKind.String;

  public override IResult<DomainRegexAst> Parse<TContext>(TContext tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    DomainRegexAst? result;
    bool excluded = tokens.Take('!');
    if (tokens.Regex(out string? regex)) {
      result = new(at, excluded, regex);
      return result.Ok();
    }

    result = new(at, false, regex);
    return string.IsNullOrEmpty(regex)
      ? excluded
        ? tokens.Error(label, "regex after '!'", result)
        : result.Empty()
      : tokens.Error(label, "Closing '/'", result);
  }

  protected override void ApplyItems(DomainDefinition result, DomainRegexAst[] items)
    => result.Regexes = items;
}
