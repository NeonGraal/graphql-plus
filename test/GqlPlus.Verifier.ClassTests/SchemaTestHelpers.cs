using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Ast;

internal static class SchemaTestHelpers
{
  public static EnumLabelAst[] EnumLabels(this string label)
    => new EnumLabelAst[] { new(AstNulls.At, label) };
}
