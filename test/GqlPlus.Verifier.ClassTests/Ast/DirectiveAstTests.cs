namespace GqlPlus.Verifier.Ast;

public class DirectiveAstTests
{
  [Theory, RepeatData(Repeats)]
  public void String(string name)
    => new DirectiveAst(AstNulls.At, name).TestString($"( !D {name} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithArgument(string variable, string name)
    => new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) }
    .TestString($"( !D {name} ( !A ${variable} ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality(string name)
  {
    var left = new DirectiveAst(AstNulls.At, name);
    var right = new DirectiveAst(AstNulls.At, name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality(string name1, string name2)
  {
    if (name1 == name2) {
      return;
    }

    var left = new DirectiveAst(AstNulls.At, name1);
    var right = new DirectiveAst(AstNulls.At, name2);

    (left != right).Should().BeTrue();
  }

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
}
