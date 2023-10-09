using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseArgumentTests
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_ReturnsCorrectAst(string variable)
    => ParseArgumentTrueExpected(
      "($" + variable + ")",
      new ArgumentAst(variable));

  [Theory, RepeatData(Repeats)]
  public void WithConstant_ReturnsCorrectAst(string label)
    => ParseArgumentTrueExpected(
      "(" + label + ")",
      new ArgumentAst(new FieldKeyAst("", label)));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
    => ParseArgumentTrueExpected(
      "($" + label + ' ' + label + ')',
      new ArgumentAst(label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string label)
    => ParseArgumentTrueExpected(
      "($" + label + ',' + label + ')',
      new ArgumentAst(label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
    => ParseArgumentFalse(
      "($" + label + '|' + label + ')');

  [Theory, RepeatData(Repeats)]
  public void WithField_ReturnsTrue(string label)
    => ParseArgumentTrueExpected(
      '(' + label + ":$" + label + ')',
      new ArgumentAst(label.ArgumentObject(label)));

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
    => ParseArgumentTrueExpected(
      '(' + key + ":$" + label + ' ' + label + ':' + key + ')',
      new ArgumentAst(label.ArgumentObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string label)
    => ParseArgumentTrueExpected(
      '(' + key + ":$" + label + ';' + label + ':' + key + ')',
      new ArgumentAst(label.ArgumentObject(key)),
        key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string label)
    => ParseArgumentFalse(
      '(' + key + ':' + label + ',' + label + ':' + key + ')',
      key == label);

  private void ParseArgumentTrueExpected(string input, ArgumentAst expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = new OperationParser(Tokens(input));

    parser.ParseArgument(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  private void ParseArgumentFalse(string input, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = new OperationParser(Tokens(input));

    parser.ParseArgument(out ArgumentAst result).Should().BeFalse();

    result.Should().Be(new ArgumentAst());
  }
}
