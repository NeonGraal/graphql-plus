using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseFieldKeyTests
{
  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithNumber_ReturnsCorrectAst(decimal number)
  => ParseFieldKeyTrueExpected(
      number.ToString(),
      new FieldKeyAst(number));

  [Fact]
  public void ParseFieldKey_WithSpecific_ReturnsCorrectAst()
  {
    var contents = "?&ZbND|2\\";
    ParseFieldKeyTrueExpected(
      contents.Quote(),
      new FieldKeyAst(contents));
  }

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithString_ReturnsCorrectAst(string contents)
  => ParseFieldKeyTrueExpected(
      contents.Quote(),
      new FieldKeyAst(contents));

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithLabel_ReturnsCorrectAst(string label)
  => ParseFieldKeyTrueExpected(
      label,
      new FieldKeyAst("", label));

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithTypeAndLabel_ReturnsCorrectAst(string theType, string label)
    => ParseFieldKeyTrueExpected(
      theType + "." + label,
      new FieldKeyAst(theType, label));

  private void ParseFieldKeyTrueExpected(string input, FieldKeyAst expected)
  {
    var parser = new OperationParser(Tokens(input));

    parser.ParseFieldKey(out FieldKeyAst result).Should().BeTrue();

    result.Should().Be(expected);
  }
}
