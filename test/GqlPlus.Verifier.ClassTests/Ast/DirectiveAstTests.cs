namespace GqlPlus.Verifier.Ast;

public class DirectiveAstTests
{
  [Theory, RepeatData(Repeats)]
  public void String(string name)
    => new DirectiveAst(name).TestString($"D({name})");

  [Theory, RepeatData(Repeats)]
  public void String_WithArgument(string variable, string name)
    => new DirectiveAst(name) { Argument = new ArgumentAst(variable) }
    .TestString($"D({name} A(${variable}))");

  [Theory, RepeatData(Repeats)]
  public void Equality(string name)
  {
    var left = new DirectiveAst(name);
    var right = new DirectiveAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality(string name1, string name2)
  {
    if (name1 == name2) {
      return;
    }

    var left = new DirectiveAst(name1);
    var right = new DirectiveAst(name2);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArgument(string variable, string name)
  {
    var left = new DirectiveAst(name) { Argument = new ArgumentAst(variable) };
    var right = new DirectiveAst(name) { Argument = new ArgumentAst(variable) };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithArgument(string variable, string name)
  {
    var left = new DirectiveAst(name) { Argument = new ArgumentAst(variable) };
    var right = new DirectiveAst(name);

    (left != right).Should().BeTrue();
  }
}
