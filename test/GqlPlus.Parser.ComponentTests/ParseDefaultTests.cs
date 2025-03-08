using System.Globalization;
using GqlPlus.Parsing;

namespace GqlPlus;

public class ParseDefaultTests(
  IOneChecksParser<IParserDefault, IGqlpConstant> checks
)
{
  [Fact]
  public void WithEmpty_ReturnsEmpty()
    => checks.EmptyResult("");

  [Fact]
  public void WithInvalid_ReturnsFalse()
    => checks.FalseExpected("=");

  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => checks.TrueExpected(
      "=" + number.ToString(CultureInfo.InvariantCulture),
      new ConstantAst(new FieldKeyAst(AstNulls.At, number)));

  [Theory, RepeatData(Repeats)]
  public void WithString_ReturnsCorrectAst(string contents)
    => checks.TrueExpected(
      "=" + contents.Quote(),
      new ConstantAst(new FieldKeyAst(AstNulls.At, contents)));

  [Theory, RepeatData(Repeats)]
  public void WithEnumValue_ReturnsCorrectAst(string enumValue)
    => checks.TrueExpected(
      "=" + enumValue,
      new ConstantAst(enumValue.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithEnumValueInvalid_ReturnsFalse(string enumValue)
    => checks.FalseExpected("=." + enumValue);

  [Theory, RepeatData(Repeats)]
  public void WithEnumTypeAndValue_ReturnsCorrectAst(string enumType, string enumValue)
    => checks.TrueExpected(
      "=" + enumType + "." + enumValue,
      new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData(Repeats)]
  public void WithEnumInvalid_ReturnsFalse(string enumType)
    => checks.FalseExpected("=" + enumType + ".");

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string enumValue)
    => checks.TrueExpected(
      "=" + '[' + enumValue + ' ' + enumValue + ']',
      new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string enumValue)
    => checks.FalseExpected(
      "=" + '[' + enumValue + ':' + enumValue + ']',
      CheckNull);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string enumValue)
    => checks
      .SkipIf(key == enumValue)
      .TrueExpected(
        "=" + '{' + key + ':' + enumValue + ' ' + enumValue + ':' + key + '}',
        new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string enumValue)
    => checks
      .SkipIf(key == enumValue)
      .FalseExpected(
        "=" + '{' + key + ':' + enumValue + ':' + key + '}',
        CheckNull);

  private void CheckNull(IGqlpConstant? result)
    => result.ShouldBeNull();
}
