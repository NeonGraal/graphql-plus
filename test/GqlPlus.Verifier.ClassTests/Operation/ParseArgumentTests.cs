using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseArgumentTests
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_ReturnsCorrectAst(string variable)
  {
    var parser = new OperationParser(Tokens("($" + variable + ")"));
    var expected = new ArgumentAst(variable);

    parser.ParseArgument(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithNumber_ReturnsCorrectAst(decimal number)
  {
    var parser = new OperationParser(Tokens(number.ToString()));
    var expected = new FieldKeyAst(number);

    parser.ParseFieldKey(out FieldKeyAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Fact]
  public void ParseFieldKey_WithSSpecific_ReturnsCorrectAst()
  {
    var contents = "?&ZbND|2\\";
    var parser = new OperationParser(Tokens(contents.Quote()));
    var expected = new FieldKeyAst(contents);

    parser.ParseFieldKey(out FieldKeyAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithString_ReturnsCorrectAst(string contents)
  {
    var parser = new OperationParser(Tokens(contents.Quote()));
    var expected = new FieldKeyAst(contents);

    parser.ParseFieldKey(out FieldKeyAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithLabel_ReturnsCorrectAst(string label)
  {
    var parser = new OperationParser(Tokens(label));
    var expected = new FieldKeyAst("", label);

    parser.ParseFieldKey(out FieldKeyAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseFieldKey_WithTypeAndLabel_ReturnsCorrectAst(string theType, string label)
  {
    var parser = new OperationParser(Tokens(theType + "." + label));
    var expected = new FieldKeyAst(theType, label);

    parser.ParseFieldKey(out FieldKeyAst result).Should().BeTrue();

    result.Should().Be(expected);
  }
}
