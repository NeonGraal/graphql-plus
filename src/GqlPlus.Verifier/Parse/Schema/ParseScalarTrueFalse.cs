using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarTrueFalse(
  Parser<ScalarTrueFalseAst>.DA items
) : ParseScalarItem<ScalarTrueFalseAst>(items)
{
  public override ScalarKind Kind => ScalarKind.Boolean;

  public override IResult<ScalarTrueFalseAst> Parse<TContext>(TContext tokens, string label)
  {
    var at = tokens.At;
    var excluded = tokens.Take('!');
    var hasType = tokens.Identifier(out var type);
    ScalarTrueFalseAst result = new(at, excluded, type.Equals("true", StringComparison.Ordinal));

    return hasType && (result.Value || type.Equals("false", StringComparison.Ordinal))
      ? result.Ok()
      : excluded
        ? tokens.Partial(label, "boolean after '!'", () => result)
        : hasType
          ? tokens.Partial(label, "true or false", () => result)
          : result.Empty();
  }

  protected override void ApplyItems(ScalarDefinition result, ScalarTrueFalseAst[] items)
    => result.Values = items;
}
