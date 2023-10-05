using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseConstantTests
{
  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => ParseConstantTrueExpected(
      number.ToString(),
      new FieldKeyAst(number));

  [Theory, RepeatData(Repeats)]
  public void WithString_ReturnsCorrectAst(string contents)
    => ParseConstantTrueExpected(
      contents.Quote(),
      new FieldKeyAst(contents));

  [Theory, RepeatData(Repeats)]
  public void WithLabel_ReturnsCorrectAst(string label)
    => ParseConstantTrueExpected(
      label,
      new FieldKeyAst("", label));

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_ReturnsCorrectAst(string enumType, string label)
    => ParseConstantTrueExpected(
      enumType + "." + label,
      new FieldKeyAst(enumType, label));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
    => ParseConstantTrueExpected(
      '[' + label + ' ' + label + ']',
      new ConstantAst(label.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string label)
    => ParseConstantTrueExpected(
      '[' + label + ',' + label + ']',
      new ConstantAst(label.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
    => ParseConstantFalseExpected(
      '[' + label + ':' + label + ']',
      new ConstantAst());

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
    => ParseConstantTrueExpected(
      '{' + key + ':' + label + ' ' + label + ':' + key + '}',
      new ConstantAst(label.ConstantObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string label)
    => ParseConstantTrueExpected(
      '{' + key + ':' + label + ';' + label + ':' + key + '}',
      new ConstantAst(label.ConstantObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string label)
    => ParseConstantFalseExpected(
      '{' + key + ':' + label + ',' + label + ':' + key + '}',
      new ConstantAst(),
      key == label);

  private void ParseConstantTrueExpected(string input, ConstantAst expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = new OperationParser(Tokens(input));

    parser.ParseConstant(out ConstantAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  private void ParseConstantFalseExpected(string input, ConstantAst expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = new OperationParser(Tokens(input));

    parser.ParseConstant(out ConstantAst result).Should().BeFalse();

    result.Should().Be(expected);
  }
}
