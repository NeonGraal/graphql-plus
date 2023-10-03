using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseDirectivesTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string directive)
  {
    var parser = new OperationParser(Tokens("@" + directive));

    DirectiveAst[] result = parser.ParseDirectives();

    result.Should()
      .NotBeNull().And
      .Equal(new DirectiveAst(directive));
  }

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string directive, string variable)
  {
    var parser = new OperationParser(Tokens("@" + directive + "($" + variable + ")"));
    var expected = new DirectiveAst(directive) { Argument = new ArgumentAst(variable) };

    DirectiveAst[] result = parser.ParseDirectives();

    result.Should().NotBeNull().And.Equal(expected);
  }
}
