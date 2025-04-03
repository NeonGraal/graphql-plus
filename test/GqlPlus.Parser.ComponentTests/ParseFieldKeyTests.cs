using System.Globalization;

namespace GqlPlus;

public class ParseFieldKeyTests(
  IOneChecksParser<IGqlpFieldKey> checks
)
{
  [Theory, RepeatData]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => checks.TrueExpected(
      number.ToString(CultureInfo.InvariantCulture),
      new FieldKeyAst(AstNulls.At, number));

  [Theory]
  [InlineData(", b.BJ)s\"")]
  [InlineData("?&ZbND|\"\"\"2\\")]
  public void WithSpecificString_ReturnsCorrectAst(string contents)
    => checks.TrueExpected(
      contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData]
  public void WithString_ReturnsCorrectAst(string contents)
    => checks.TrueExpected(
      contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory]
  [InlineData(", b.BJ)s\"")]
  [InlineData("?&ZbND|\"\"\"2\\")]
  public void WithSpecificBlockString_ReturnsCorrectAst(string contents)
    => checks.TrueExpected(
      contents.BlockQuote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData]
  public void WithBlockString_ReturnsCorrectAst(string contents)
    => checks.TrueExpected(
      contents.BlockQuote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData]
  public void WithEnumValue_ReturnsCorrectAst(string enumValue)
    => checks.TrueExpected(
      enumValue,
      enumValue.FieldKey());

  [Theory]
  [InlineData("true", "Boolean", "true")]
  [InlineData("false", "Boolean", "false")]
  [InlineData("null", "Null", "null")]
  [InlineData("_", "Unit", "_")]
  public void WithSpecificValues_ReturnsCorrectAst(string value, string enumType, string enumValue)
    => checks.TrueExpected(
      value,
      new FieldKeyAst(AstNulls.At, enumType, enumValue));

  [Theory, RepeatData]
  public void WithTypeAndValue_ReturnsCorrectAst(string enumType, string enumValue)
    => checks.TrueExpected(
      enumType + "." + enumValue,
      new FieldKeyAst(AstNulls.At, enumType, enumValue));

  [Theory, RepeatData]
  public void WithTypeAndNoValue_ReturnsFalse(string enumType)
    => checks.FalseExpected(enumType + ".");
}

