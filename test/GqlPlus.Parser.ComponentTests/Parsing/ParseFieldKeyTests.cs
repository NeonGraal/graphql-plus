using System.Globalization;

namespace GqlPlus.Parsing;

public class ParseFieldKeyTests(Parser<FieldKeyAst>.D parser)
{
  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => Test.TrueExpected(
      number.ToString(CultureInfo.InvariantCulture),
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
  public void WithEnumValue_ReturnsCorrectAst(string enumValue)
    => Test.TrueExpected(
      enumValue,
      enumValue.FieldKey());

  [Theory]
  [InlineData("true", "Boolean", "true")]
  [InlineData("false", "Boolean", "false")]
  [InlineData("null", "Null", "null")]
  [InlineData("_", "Unit", "_")]
  public void WithSpecificValues_ReturnsCorrectAst(string value, string enumType, string enumValue)
    => Test.TrueExpected(
      value,
      new FieldKeyAst(AstNulls.At, enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void WithTypeAndValue_ReturnsCorrectAst(string enumType, string enumValue)
    => Test.TrueExpected(
      enumType + "." + enumValue,
      new FieldKeyAst(AstNulls.At, enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void WithTypeAndNoValue_ReturnsFalse(string enumType)
    => Test.False(enumType + ".");

  private OneChecksParser<FieldKeyAst> Test { get; } = new(parser);
}

