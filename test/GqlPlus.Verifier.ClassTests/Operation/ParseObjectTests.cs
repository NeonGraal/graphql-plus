using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseObjectTests
{
  [Theory, RepeatData(Repeats)]
  public void WithJustField_ReturnsCorrectAst(string field)
  {
    var parser = new OperationParser(Tokens("{" + field + "}"));
    var expected = new FieldAst(field);

    parser.ParseObject(out AstSelection[] result).Should().BeTrue();

    result.Should().Equal(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithJustInline_ReturnsCorrectAst(string inline)
  {
    var parser = new OperationParser(Tokens("{|{" + inline + "}}"));
    var expected = new InlineAst(new FieldAst(inline));

    parser.ParseObject(out AstSelection[] result).Should().BeTrue();

    result.Should().Equal(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithJustSpread_ReturnsCorrectAst(string spread)
  {
    var parser = new OperationParser(Tokens("{|" + spread + "}"));
    var expected = new SpreadAst(spread);

    parser.ParseObject(out AstSelection[] result).Should().BeTrue();

    result.Should().Equal(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string field, string inline, string spread)
  {
    var parser = new OperationParser(Tokens("{" + field + "|{" + inline + "}|" + spread + "}"));
    var expected = new AstSelection[] {
      new FieldAst(field),
      new InlineAst(new FieldAst(inline)),
      new SpreadAst(spread),
  };

    parser.ParseObject(out AstSelection[] result).Should().BeTrue();

    result.Should().Equal(expected);
  }

  [Fact]
  public void WithNoFields_ReturnsFalse()
  {
    var tokens = Tokens("{}");
    var parser = new OperationParser(tokens);

    parser.ParseObject(out AstSelection[] result).Should().BeFalse();

    result.Should().NotBeNull();
    result!.Length.Should().Be(0);
  }
}
