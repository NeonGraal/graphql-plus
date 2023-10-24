using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Ast;

internal static class SchemaTestHelpers
{
  public static EnumLabelAst[] EnumLabels(this string label)
    => new EnumLabelAst[] { new(AstNulls.At, label) };

  public static InputFieldAst[] InputFields(this string fieldName, string fieldType)
    => new InputFieldAst[] { new(AstNulls.At, fieldName, new(AstNulls.At, fieldType)) };

  public static InputReferenceAst[] InputReferences(this string argument)
    => new InputReferenceAst[] { new(AstNulls.At, argument) };

  public static ScalarRangeAst[] ScalarRanges(this RangeInput input)
    => new ScalarRangeAst[] { new(AstNulls.At, input.Lower, input.Upper) };

  public static ScalarRegexAst[] ScalarRegexes(this string regex)
    => new ScalarRegexAst[] { new(AstNulls.At, regex, true) };
}
