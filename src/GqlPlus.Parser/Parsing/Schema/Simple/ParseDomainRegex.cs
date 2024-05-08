using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomainRegex(
  Parser<IGqlpDomainRegex>.DA items
) : ParseDomainItem<IGqlpDomainRegex>(items)
{
  public override DomainKind Kind => DomainKind.String;

  public override IResult<IGqlpDomainRegex> Parse<TContext>(TContext tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    DomainRegexAst? result;
    bool excluded = tokens.Take('!');
    if (tokens.Regex(out string? regex)) {
      result = new(at, excluded, regex);
      return result.Ok<IGqlpDomainRegex>();
    }

    result = new(at, false, regex);
    return string.IsNullOrEmpty(regex)
      ? excluded
        ? tokens.Error<IGqlpDomainRegex>(label, "regex after '!'", result)
        : result.Empty<IGqlpDomainRegex>()
      : tokens.Error<IGqlpDomainRegex>(label, "Closing '/'", result);
  }

  protected override void ApplyItems(Tokenizer tokens, string label, DomainDefinition result, IGqlpDomainRegex[] items)
    => result.Regexes = items.ArrayOf<DomainRegexAst>();
}
