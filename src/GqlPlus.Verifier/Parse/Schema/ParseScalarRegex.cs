using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarRegex(
  Parser<ScalarRegexAst>.DA items
) : ParseScalarItem<ScalarRegexAst>(items)
{
  public override ScalarDomain Kind => ScalarDomain.String;

  public override IResult<ScalarRegexAst> Parse<TContext>(TContext tokens, string label)
  {
    var at = tokens.At;
    ScalarRegexAst? result;
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

  protected override void ApplyItems(ScalarDefinition result, ScalarRegexAst[] items)
    => result.Regexes = items;
}
