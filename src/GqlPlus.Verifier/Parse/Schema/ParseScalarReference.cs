using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarReference(
  Parser<ScalarReferenceAst>.DA items
) : ParseScalarItem<ScalarReferenceAst>(items)
{
  public override ScalarKind Kind => ScalarKind.Union;

  public override IResult<ScalarReferenceAst> Parse<TContext>(TContext tokens, string label)
  {
    ScalarReferenceAst? result = null;
    var at = tokens.At;
    if (tokens.Take('|')) {
      if (tokens.Identifier(out var name)) {
        result = new(at, name);
        return result.Ok();
      }

      return tokens.Error(label, "reference after '|'", result);
    }

    return result.Empty();
  }

  protected override void ApplyItems(ScalarDefinition result, ScalarReferenceAst[] items)
    => result.References = items;
}
