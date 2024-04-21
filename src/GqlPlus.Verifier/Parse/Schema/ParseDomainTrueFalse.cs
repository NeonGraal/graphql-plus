﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseDomainTrueFalse(
  Parser<DomainTrueFalseAst>.DA items
) : ParseDomainItem<DomainTrueFalseAst>(items)
{
  public override DomainDomain Kind => DomainDomain.Boolean;

  public override IResult<DomainTrueFalseAst> Parse<TContext>(TContext tokens, string label)
  {
    var at = tokens.At;
    var excluded = tokens.Take('!');
    var hasType = tokens.Identifier(out var type);
    DomainTrueFalseAst result = new(at, excluded, type.Equals("true", StringComparison.Ordinal));

    return hasType && (result.Value || type.Equals("false", StringComparison.Ordinal))
      ? result.Ok()
      : excluded
        ? tokens.Partial(label, "boolean after '!'", () => result)
        : hasType
          ? tokens.Partial(label, "true or false", () => result)
          : result.Empty();
  }

  protected override void ApplyItems(DomainDefinition result, DomainTrueFalseAst[] items)
    => result.Values = items;
}
