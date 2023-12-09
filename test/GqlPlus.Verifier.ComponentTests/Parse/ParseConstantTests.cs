namespace GqlPlus.Verifier.Parse;

public class ParseConstantTests
{
  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => _test.TrueExpected(
      number.ToString(),
      new FieldKeyAst(AstNulls.At, number));

  [Theory, RepeatData(Repeats)]
  public void WithString_ReturnsCorrectAst(string contents)
    => _test.TrueExpected(
      contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void WithEnumValue_ReturnsCorrectAst(string enumValue)
    => _test.TrueExpected(
      enumValue,
      enumValue.FieldKey());

  [Theory, RepeatData(Repeats)]
  public void WithEnumTypeAndValue_ReturnsCorrectAst(string enumType, string enumValue)
    => _test.TrueExpected(
      enumType + "." + enumValue,
      new FieldKeyAst(AstNulls.At, enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string enumValue)
    => _test.TrueExpected(
      '[' + enumValue + ' ' + enumValue + ']',
      new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string enumValue)
    => _test.TrueExpected(
      '[' + enumValue + ',' + enumValue + ']',
      new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string enumValue)
    => _test.False(
      '[' + enumValue + ':' + enumValue + ']',
      CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string enumValue)
    => _test.TrueExpected(
      '{' + key + ':' + enumValue + ' ' + enumValue + ':' + key + '}',
      new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)),
      key == enumValue);

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string enumValue)
    => _test.TrueExpected(
      '{' + key + ':' + enumValue + ',' + enumValue + ':' + key + '}',
      new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)),
      key == enumValue);

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string enumValue)
    => _test.False(
      '{' + key + ':' + enumValue + ':' + key + '}',
      CheckNull,
      key == enumValue);

  private void CheckDefault(ConstantAst? result)
    => result.Should().Be(new ConstantAst(AstNulls.At));

  private void CheckNull(ConstantAst? result)
    => result.Should().BeNull();

  private readonly OneChecksParser<ConstantAst> _test;

  public ParseConstantTests(Parser<ConstantAst>.D parser)
    => _test = new(parser);
}
