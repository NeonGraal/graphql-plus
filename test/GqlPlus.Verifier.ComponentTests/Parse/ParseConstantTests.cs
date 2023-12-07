﻿namespace GqlPlus.Verifier.Parse;

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
  public void WithLabel_ReturnsCorrectAst(string label)
    => _test.TrueExpected(
      label,
      label.FieldKey());

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_ReturnsCorrectAst(string enumType, string label)
    => _test.TrueExpected(
      enumType + "." + label,
      new FieldKeyAst(AstNulls.At, enumType, label));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
    => _test.TrueExpected(
      '[' + label + ' ' + label + ']',
      new ConstantAst(AstNulls.At, label.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string label)
    => _test.TrueExpected(
      '[' + label + ',' + label + ']',
      new ConstantAst(AstNulls.At, label.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
    => _test.False(
      '[' + label + ':' + label + ']',
      CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
    => _test.TrueExpected(
      '{' + key + ':' + label + ' ' + label + ':' + key + '}',
      new ConstantAst(AstNulls.At, label.ConstantObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string label)
    => _test.TrueExpected(
      '{' + key + ':' + label + ',' + label + ':' + key + '}',
      new ConstantAst(AstNulls.At, label.ConstantObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string label)
    => _test.False(
      '{' + key + ':' + label + ':' + key + '}',
      CheckNull,
      key == label);

  private void CheckDefault(ConstantAst? result)
    => result.Should().Be(new ConstantAst(AstNulls.At));

  private void CheckNull(ConstantAst? result)
    => result.Should().BeNull();

  private readonly OneChecksParser<ConstantAst> _test;

  public ParseConstantTests(Parser<ConstantAst>.D parser)
    => _test = new(parser);
}
