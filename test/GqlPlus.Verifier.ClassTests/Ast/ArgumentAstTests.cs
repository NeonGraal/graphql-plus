namespace GqlPlus.Verifier.Ast;

public class ArgumentAstTests
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_Equality(string variable)
  {
    var left = new ArgumentAst(variable);
    var right = new ArgumentAst(variable);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithVariable_Inequality(string variable)
  {
    var left = new ArgumentAst(variable);
    var right = new ArgumentAst(variable + "a");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithConstant_Equality(string enumType, string label)
  {
    var left = new ArgumentAst(new ConstantAst(enumType, label));
    var right = new ArgumentAst(new ConstantAst(enumType, label));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithConstant_Inequality(string enumType, string label)
  {
    var left = new ArgumentAst(new ConstantAst(enumType, label));
    var right = new ArgumentAst(new ConstantAst(label, enumType));

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithValues_Equality(string label)
  {
    var left = new ArgumentAst(label.ArgumentList());
    var right = new ArgumentAst(label.ArgumentList());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithValues_Inequality(string label)
  {
    var left = new ArgumentAst(label.ArgumentList());
    var right = new ArgumentAst(label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithFields_Equality(string key, string label)
  {
    var left = new ArgumentAst(label.ArgumentObject(key));
    var right = new ArgumentAst(label.ArgumentObject(key));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithFields_Inequality(string key, string label)
  {
    var left = new ArgumentAst(label.ArgumentObject(key));
    var right = new ArgumentAst(label);

    (left != right).Should().BeTrue();
  }
}
