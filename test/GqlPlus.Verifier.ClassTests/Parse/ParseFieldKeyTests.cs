namespace GqlPlus.Verifier.Parse;

public class ParseFieldKeyTests
{
  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => Test.TrueExpected(
      number.ToString(),
      new FieldKeyAst(AstNulls.At, number));

  [Theory]
  [InlineData(", b.BJ)s\"")]
  [InlineData("?&ZbND|\"\"\"2\\")]
  public void WithSpecificString_ReturnsCorrectAst(string contents)
    => Test.TrueExpected(
      contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void WithString_ReturnsCorrectAst(string contents)
    => Test.TrueExpected(
      contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory]
  [InlineData(", b.BJ)s\"")]
  [InlineData("?&ZbND|\"\"\"2\\")]
  public void WithSpecificBlockString_ReturnsCorrectAst(string contents)
    => Test.TrueExpected(
      contents.BlockQuote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void WithBlockString_ReturnsCorrectAst(string contents)
    => Test.TrueExpected(
      contents.BlockQuote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void WithLabel_ReturnsCorrectAst(string label)
    => Test.TrueExpected(
      label,
      label.FieldKey());

  [Theory]
  [InlineData("true", "Boolean", "true")]
  [InlineData("false", "Boolean", "false")]
  [InlineData("null", "Null", "null")]
  [InlineData("_", "Unit", "_")]
  public void WithSpecifcLabels_ReturnsCorrectAst(string label, string enumType, string enumLabel)
    => Test.TrueExpected(
      label,
      new FieldKeyAst(AstNulls.At, enumType, enumLabel));

  [Theory, RepeatData(Repeats)]
  public void WithTypeAndLabel_ReturnsCorrectAst(string theType, string label)
    => Test.TrueExpected(
      theType + "." + label,
      new FieldKeyAst(AstNulls.At, theType, label));

  [Theory, RepeatData(Repeats)]
  public void WithTypeAndNoLabel_ReturnsFalse(string theType)
    => Test.False(theType + ".");

  private OneChecksParser<FieldKeyAst> Test { get; }

  public ParseFieldKeyTests(Parser<FieldKeyAst>.D parser)
    => Test = new(parser);
}
