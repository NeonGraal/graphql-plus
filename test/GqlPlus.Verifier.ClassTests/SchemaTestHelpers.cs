using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Ast;

internal static class SchemaTestHelpers
{
  public static EnumLabelAst[] EnumLabels(this string label)
    => new EnumLabelAst[] { new(AstNulls.At, label) };

  public static ScalarRangeAst[] ScalarRanges(this decimal min, decimal max)
    => new ScalarRangeAst[] { new(AstNulls.At, min, max) };

  public static ScalarRegexAst[] ScalarRegexes(this string regex)
    => new ScalarRegexAst[] { new(AstNulls.At, regex, true) };
}
