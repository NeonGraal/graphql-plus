using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomainTrueFalse(
  Parser<IGqlpDomainTrueFalse>.DA items
) : ParseDomainItem<IGqlpDomainTrueFalse>(items)
{
  public override DomainKind Kind => DomainKind.Boolean;

  public override IResult<IGqlpDomainTrueFalse> Parse(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    TokenAt at = tokens.At;
    bool excluded = tokens.Take('!');
    bool hasType = tokens.Identifier(out string? type);
    IGqlpDomainTrueFalse result = new DomainTrueFalseAst(at, description, excluded, type.Equals("true", StringComparison.Ordinal));

    return hasType && (result.IsTrue || type.Equals("false", StringComparison.Ordinal))
      ? result.Ok()
      : excluded
        ? tokens.Partial(label, "boolean after '!'", () => result)
        : hasType
          ? tokens.Partial(label, "true or false", () => result)
          : result.Empty();
  }

  protected override void ApplyItems(ITokenizer tokens, string label, DomainDefinition result, IGqlpDomainTrueFalse[] items)
    => result.Values = items.Length > 0 ? items.ArrayOf<DomainTrueFalseAst>()
    : [DefaultTrueFalse(tokens, false), DefaultTrueFalse(tokens, true)];

  private static DomainTrueFalseAst DefaultTrueFalse(ITokenizer tokens, bool value)
    => new(tokens.At, "", false, value);
}
