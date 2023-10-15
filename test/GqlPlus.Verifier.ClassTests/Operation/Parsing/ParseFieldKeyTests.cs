using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation.Parsing;

public class ParseFieldKeyTests
{
  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithNumber_ReturnsCorrectAst(decimal number)
  => Test.TrueExpected(
      number.ToString(),
      new FieldKeyAst(AstNulls.At, number));

  [Fact]
  public void ParseFieldKey_WithSpecific_ReturnsCorrectAst()
  {
    var contents = "?&ZbND|2\\";
    Test.TrueExpected(
      contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));
  }

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithString_ReturnsCorrectAst(string contents)
  => Test.TrueExpected(
      contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithLabel_ReturnsCorrectAst(string label)
  => Test.TrueExpected(
      label,
      new FieldKeyAst(AstNulls.At, "", label));

  [Theory]
  [InlineData("true", "Boolean", "true")]
  [InlineData("false", "Boolean", "false")]
  [InlineData("null", "Null", "null")]
  [InlineData("_", "Unit", "_")]
  public void ParseFieldKey_WithSpecifcLabels_ReturnsCorrectAst(string label, string enumType, string enumLabel)
  => Test.TrueExpected(
      label,
      new FieldKeyAst(AstNulls.At, enumType, enumLabel));

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithTypeAndLabel_ReturnsCorrectAst(string theType, string label)
    => Test.TrueExpected(
      theType + "." + label,
      new FieldKeyAst(AstNulls.At, theType, label));

  private static BaseOneChecks<FieldKeyAst> Test => new((ref OperationParser parser, out FieldKeyAst result)
    => parser.ParseFieldKey(out result));
}
