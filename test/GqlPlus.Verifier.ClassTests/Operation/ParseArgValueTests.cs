using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseArgValueTests
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_ReturnsCorrectAst(string variable)
  {
    var parser = new OperationParser(Tokens("$" + variable));
    var expected = new ArgumentAst(variable);

    parser.ParseArgValue(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithLabel_ReturnsCorrectAst(string label)
  {
    var parser = new OperationParser(Tokens(label));
    var expected = new ArgumentAst(new FieldKeyAst("", label));

    parser.ParseArgValue(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
  {
    var parser = new OperationParser(Tokens('[' + label + ' ' + label + ']'));
    var expected = new ArgumentAst(label.ArgumentList());

    parser.ParseArgValue(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string label)
  {
    var parser = new OperationParser(Tokens('[' + label + ',' + label + ']'));
    var expected = new ArgumentAst(label.ArgumentList());

    parser.ParseArgValue(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
  {
    var parser = new OperationParser(Tokens('[' + label + ':' + label + ']'));
    var expected = new ArgumentAst();

    parser.ParseArgValue(out ArgumentAst result).Should().BeFalse();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
  {
    if (key == label) {
      return;
    }

    var parser = new OperationParser(Tokens('{' + key + ':' + label + ' ' + label + ':' + key + '}'));
    var expected = new ArgumentAst(label.ArgumentObject(key));

    parser.ParseArgValue(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);

  }

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string label)
  {
    if (key == label) {
      return;
    }

    var parser = new OperationParser(Tokens('{' + key + ':' + label + ';' + label + ':' + key + '}'));
    var expected = new ArgumentAst(label.ArgumentObject(key));

    parser.ParseArgValue(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsCorrectAst(string key, string label)
  {
    if (key == label) {
      return;
    }

    var parser = new OperationParser(Tokens('{' + key + ':' + label + ',' + label + ':' + key + '}'));
    var expected = new ArgumentAst();

    parser.ParseArgValue(out ArgumentAst result).Should().BeFalse();

    result.Should().Be(expected);
  }
}
