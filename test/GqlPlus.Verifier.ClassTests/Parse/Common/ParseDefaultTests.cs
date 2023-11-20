namespace GqlPlus.Verifier.Parse.Common;

public class ParseDefaultTests
{
  [Fact]
  public void WithEmpty_ReturnsEmpty()
    => Test.Empty("");

  [Fact]
  public void WithInvalid_ReturnsFalse()
    => Test.False("=");

  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => Test.TrueExpected(
      "=" + number.ToString(),
      new FieldKeyAst(AstNulls.At, number));

  [Theory, RepeatData(Repeats)]
  public void WithString_ReturnsCorrectAst(string contents)
    => Test.TrueExpected(
      "=" + contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void WithLabel_ReturnsCorrectAst(string label)
    => Test.TrueExpected(
      "=" + label,
      label.FieldKey());

  [Theory, RepeatData(Repeats)]
  public void WithLabelInvalid_ReturnsFalse(string label)
    => Test.False("=." + label);

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_ReturnsCorrectAst(string enumType, string label)
    => Test.TrueExpected(
      "=" + enumType + "." + label,
      new FieldKeyAst(AstNulls.At, enumType, label));

  [Theory, RepeatData(Repeats)]
  public void WithEnumInvalid_ReturnsFalse(string enumType)
    => Test.False("=" + enumType + ".");

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
    => Test.TrueExpected(
      "=" + '[' + label + ' ' + label + ']',
      new ConstantAst(AstNulls.At, label.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
    => Test.False(
      "=" + '[' + label + ':' + label + ']',
      CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
    => Test.TrueExpected(
      "=" + '{' + key + ':' + label + ' ' + label + ':' + key + '}',
      new ConstantAst(AstNulls.At, label.ConstantObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string label)
    => Test.False(
      "=" + '{' + key + ':' + label + ':' + key + '}',
      CheckNull,
      key == label);

  private void CheckNull(ConstantAst? result)
    => result.Should().BeNull();

  private readonly OneChecks<ConstantAst> Test;

  public ParseDefaultTests(IParserDefault parser)
    => Test = new(parser);
}
