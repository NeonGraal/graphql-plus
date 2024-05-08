using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomainTrueFalse(
  Parser<DomainTrueFalseAst>.DA items
) : ParseDomainItem<DomainTrueFalseAst>(items)
{
  public override DomainKind Kind => DomainKind.Boolean;

  public override IResult<DomainTrueFalseAst> Parse<TContext>(TContext tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    bool excluded = tokens.Take('!');
    bool hasType = tokens.Identifier(out string? type);
    DomainTrueFalseAst result = new(at, excluded, type.Equals("true", StringComparison.Ordinal));

    return hasType && (result.Value || type.Equals("false", StringComparison.Ordinal))
      ? result.Ok()
      : excluded
        ? tokens.Partial(label, "boolean after '!'", () => result)
        : hasType
          ? tokens.Partial(label, "true or false", () => result)
          : result.Empty();
  }

  protected override void ApplyItems(Tokenizer tokens, string label, DomainDefinition result, DomainTrueFalseAst[] items)
    => result.Values = items.Length > 0 ? items
    : [new(tokens.At, false, false), new(tokens.At, false, true)];
}
