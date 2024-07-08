using System.Globalization;

namespace GqlPlus.Parsing;

public class ParseConstantTests(Parser<IGqlpConstant>.D parser)
{
  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => _checks.TrueExpected(
      number.ToString(CultureInfo.InvariantCulture),
      new ConstantAst(new FieldKeyAst(AstNulls.At, number)));

  [Theory, RepeatData(Repeats)]
  public void WithString_ReturnsCorrectAst(string contents)
    => _checks.TrueExpected(
      contents.Quote(),
      new ConstantAst(new FieldKeyAst(AstNulls.At, contents)));

  [Theory, RepeatData(Repeats)]
  public void WithEnumValue_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      enumValue,
      new ConstantAst(enumValue.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithEnumTypeAndValue_ReturnsCorrectAst(string enumType, string enumValue)
    => _checks.TrueExpected(
      enumType + "." + enumValue,
      new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      '[' + enumValue + ' ' + enumValue + ']',
      new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      '[' + enumValue + ',' + enumValue + ']',
      new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string enumValue)
    => _checks.FalseExpected(
      '[' + enumValue + ':' + enumValue + ']',
      CheckNull);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string enumValue)
    => _checks
      .SkipIf(key == enumValue)
      .TrueExpected(
        '{' + key + ':' + enumValue + ' ' + enumValue + ':' + key + '}',
        new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string enumValue)
    => _checks
      .SkipIf(key == enumValue)
      .TrueExpected(
        '{' + key + ':' + enumValue + ',' + enumValue + ':' + key + '}',
        new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string enumValue)
    => _checks
      .SkipIf(key == enumValue)
      .FalseExpected(
        '{' + key + ':' + enumValue + ':' + key + '}',
        CheckNull);

  private void CheckNull(IGqlpConstant? result)
    => result.Should().BeNull();

  private readonly OneChecksParser<IGqlpConstant> _checks = new(parser);
}
