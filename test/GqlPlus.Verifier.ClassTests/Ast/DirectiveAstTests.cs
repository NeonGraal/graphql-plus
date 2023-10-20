namespace GqlPlus.Verifier.Ast;

public class DirectiveAstTests : BaseNamedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArgument(string variable, string name)
    => TestHashCode(() => new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void String_WithArgument(string variable, string name)
    => new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) }
    .TestString($"( !D {name} ( !A ${variable} ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArgument(string variable, string name)
  {
    var left = new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) };
    var right = new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithArgument(string variable, string name)
  {
    var left = new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) };
    var right = new DirectiveAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }

  internal override BaseNamedAstChecks NamedChecks { get; }
    = new BaseNamedAstChecks<DirectiveAst>(name => new DirectiveAst(AstNulls.At, name));
}
