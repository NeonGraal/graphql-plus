using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseArgValueTests
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_ReturnsCorrectAst(string variable)
    => ParseArgValueTrueExpected(
      "$" + variable,
      new ArgumentAst(variable));

  [Theory, RepeatData(Repeats)]
  public void WithLabel_ReturnsCorrectAst(string label)
    => ParseArgValueTrueExpected(
      label,
      new ArgumentAst(new FieldKeyAst("", label)));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
    => ParseArgValueTrueExpected(
      "[$" + label + ' ' + label + ']',
      new ArgumentAst(label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string label)
    => ParseArgValueTrueExpected(
      "[$" + label + ',' + label + ']',
      new ArgumentAst(label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
    => ParseArgValueFalse(
      '[' + label + ':' + label + ']');

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
    => ParseArgValueTrueExpected(
      '{' + key + ":$" + label + ' ' + label + ':' + key + '}',
      new ArgumentAst(label.ArgumentObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string label)
    => ParseArgValueTrueExpected(
      '{' + key + ":$" + label + ';' + label + ':' + key + '}',
      new ArgumentAst(label.ArgumentObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string label)
    => ParseArgValueFalse(
      '{' + key + ':' + label + ':' + label + ':' + key + '}',
      key == label);

  private void ParseArgValueTrueExpected(string input, ArgumentAst expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = new OperationParser(Tokens(input));

    parser.ParseArgValue(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  private void ParseArgValueFalse(string input, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = new OperationParser(Tokens(input));

    parser.ParseArgValue(out ArgumentAst result).Should().BeFalse();

    result.Should().Be(new ArgumentAst());
  }
}
