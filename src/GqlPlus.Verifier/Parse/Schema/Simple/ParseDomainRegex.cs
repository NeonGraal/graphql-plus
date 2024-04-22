using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

internal class ParseDomainRegex(
  Parser<DomainRegexAst>.DA items
) : ParseDomainItem<DomainRegexAst>(items)
{
  public override DomainDomain Kind => DomainDomain.String;

  public override IResult<DomainRegexAst> Parse<TContext>(TContext tokens, string label)
  {
    var at = tokens.At;
    DomainRegexAst? result;
    var excluded = tokens.Take('!');
    if (tokens.Regex(out var regex)) {
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
