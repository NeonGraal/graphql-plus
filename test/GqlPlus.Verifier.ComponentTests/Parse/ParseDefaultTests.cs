using System.Globalization;

namespace GqlPlus.Verifier.Parse;

public class ParseDefaultTests(Parser<IParserDefault, ConstantAst>.D parser)
{
  [Fact]
  public void WithEmpty_ReturnsEmpty()
    => _checks.Empty("");

  [Fact]
  public void WithInvalid_ReturnsFalse()
    => _checks.False("=");

  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => _checks.TrueExpected(
      "=" + number.ToString(CultureInfo.InvariantCulture),
      new FieldKeyAst(AstNulls.At, number));

  [Theory, RepeatData(Repeats)]
  public void WithString_ReturnsCorrectAst(string contents)
    => _checks.TrueExpected(
      "=" + contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void WithEnumValue_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      "=" + enumValue,
      enumValue.FieldKey());

  [Theory, RepeatData(Repeats)]
  public void WithEnumValueInvalid_ReturnsFalse(string enumValue)
    => _checks.False("=." + enumValue);

  [Theory, RepeatData(Repeats)]
  public void WithEnumTypeAndValue_ReturnsCorrectAst(string enumType, string enumValue)
    => _checks.TrueExpected(
      "=" + enumType + "." + enumValue,
      new FieldKeyAst(AstNulls.At, enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void WithEnumInvalid_ReturnsFalse(string enumType)
    => _checks.False("=" + enumType + ".");

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      "=" + '[' + enumValue + ' ' + enumValue + ']',
      new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string enumValue)
    => _checks.False(
      "=" + '[' + enumValue + ':' + enumValue + ']',
      CheckNull);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string enumValue)
    => _checks.TrueExpected(
      "=" + '{' + key + ':' + enumValue + ' ' + enumValue + ':' + key + '}',
      new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)),
      key == enumValue);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string enumValue)
    => _checks.False(
      "=" + '{' + key + ':' + enumValue + ':' + key + '}',
      CheckNull,
      key == enumValue);

  private void CheckNull(ConstantAst? result)
    => result.Should().BeNull();

  private readonly OneChecksParser<IParserDefault, ConstantAst> _checks = new(parser);
}
