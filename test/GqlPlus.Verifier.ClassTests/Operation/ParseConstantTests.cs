using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseConstantTests
{
  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
  {
    var parser = new OperationParser(Tokens(number.ToString()));
    var expected = new ConstantAst(number);

    parser.ParseConstant(out ConstantAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithString_ReturnsCorrectAst(string contents)
  {
    var parser = new OperationParser(Tokens(contents.Quote()));
    var expected = new ConstantAst(contents);

    parser.ParseConstant(out ConstantAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithLabel_ReturnsCorrectAst(string label)
  {
    var parser = new OperationParser(Tokens(label));
    var expected = new ConstantAst("", label);

    parser.ParseConstant(out ConstantAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_ReturnsCorrectAst(string enumType, string label)
  {
    var parser = new OperationParser(Tokens(enumType + "." + label));
    var expected = new ConstantAst(enumType, label);

    parser.ParseConstant(out ConstantAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
  {
    var parser = new OperationParser(Tokens('[' + label + ' ' + label + ']'));
    var expected = new ConstantAst(label.ConstantList());

    parser.ParseConstant(out ConstantAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string label)
  {
    var parser = new OperationParser(Tokens('[' + label + ',' + label + ']'));
    var expected = new ConstantAst(label.ConstantList());

    parser.ParseConstant(out ConstantAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
  {
    var parser = new OperationParser(Tokens('[' + label + ':' + label + ']'));
    var expected = new ConstantAst();

    parser.ParseConstant(out ConstantAst result).Should().BeFalse();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
  {
    if (key == label) {
      return;
    }

    var parser = new OperationParser(Tokens('{' + key + ':' + label + ' ' + label + ':' + key + '}'));
    var expected = new ConstantAst(label.ConstantObject(key));

    parser.ParseConstant(out ConstantAst result).Should().BeTrue();

    result.Should().Be(expected);

  }

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string label)
  {
    if (key == label) {
      return;
    }

    var parser = new OperationParser(Tokens('{' + key + ':' + label + ';' + label + ':' + key + '}'));
    var expected = new ConstantAst(label.ConstantObject(key));

    parser.ParseConstant(out ConstantAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsCorrectAst(string key, string label)
  {
    if (key == label) {
      return;
    }

    var parser = new OperationParser(Tokens('{' + key + ':' + label + ',' + label + ':' + key + '}'));
    var expected = new ConstantAst();

    parser.ParseConstant(out ConstantAst result).Should().BeFalse();

    result.Should().Be(expected);
  }
}
