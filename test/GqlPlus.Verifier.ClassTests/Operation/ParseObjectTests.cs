using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseObjectTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string field)
  {
    var parser = new OperationParser(Tokens("{" + field + "}"));

    parser.ParseObject(out AstSelection[] result).Should().BeTrue();

    result.Should().NotBeNull();
    result!.Length.Should().Be(1);
  }

  [Fact]
  public void WithNoFields_ReturnsFalse()
  {
    var parser = new OperationParser(Tokens("{}"));

    parser.ParseObject(out AstSelection[] result).Should().BeFalse();

    result.Should().NotBeNull();
    result!.Length.Should().Be(0);
  }
}
