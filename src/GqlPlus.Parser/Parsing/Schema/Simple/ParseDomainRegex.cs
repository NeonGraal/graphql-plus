using GqlPlus.Abstractions.Schema;
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
    string description = tokens.Description();
    TokenAt at = tokens.At;
    IGqlpDomainRegex? result;
    bool excluded = tokens.Take('!');
    if (tokens.Regex(out string? regex)) {
      result = new DomainRegexAst(at, description, excluded, regex);
      return result.Ok();
    }

    result = new DomainRegexAst(at, description, false, regex);
    return string.IsNullOrEmpty(regex)
      ? excluded
        ? tokens.Error(label, "regex after '!'", result)
        : result.Empty()
      : tokens.Error(label, "Closing '/'", result);
  }

  protected override void ApplyItems(Tokenizer tokens, string label, DomainDefinition result, IGqlpDomainRegex[] items)
    => result.Regexes = items.ArrayOf<DomainRegexAst>();
}
