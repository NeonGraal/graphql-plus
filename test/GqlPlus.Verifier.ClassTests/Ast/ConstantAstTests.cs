namespace GqlPlus.Verifier.Ast;

public class ConstantAstTests
{
  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_Equality(string enumType, string label)
  {
    var left = new ConstantAst(enumType, label);
    var right = new ConstantAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_Inequality(string enumType, string label)
  {
    var left = new ConstantAst(enumType, label);
    var right = new ConstantAst(label, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithValues_Equality(string label)
  {
    var left = new ConstantAst(label.ConstantList());
    var right = new ConstantAst(label.ConstantList());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithFields_Equality(string key, string label)
  {
    var left = new ConstantAst(label.ConstantObject(key));
    var right = new ConstantAst(label.ConstantObject(key));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }
  private ModifierAst[] TestMods()
    => new[] { ModifierAst.List, ModifierAst.Optional };
}
