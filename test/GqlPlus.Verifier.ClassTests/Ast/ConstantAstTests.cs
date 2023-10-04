namespace GqlPlus.Verifier.Ast;

public class ConstantAstTests
{
  [Theory, RepeatData(Repeats)]
  public void WithLabel_Equality(string label)
  {
    var left = new ConstantAst("", label);
    var right = new ConstantAst("", label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_Equality(string enumType, string label)
  {
    var left = new ConstantAst(enumType, label);
    var right = new ConstantAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumType_Equality(string enumType)
  {
    var left = new ConstantAst(enumType, "label");
    var right = new ConstantAst(enumType, "label");

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithLabel_Inequality(string label)
  {
    var left = new ConstantAst("", label);
    var right = new ConstantAst("", label + "a");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_Inequality(string enumType, string label)
  {
    if (enumType != label) {
      return;
    }

    var left = new ConstantAst(enumType, label);
    var right = new ConstantAst(label, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumType_Inequality(string enumType)
  {
    var left = new ConstantAst(enumType, "label");
    var right = new ConstantAst(enumType + "a", "label");

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
  public void WithValues_Inequality(string label)
  {
    var left = new ConstantAst(label.ConstantList());
    var right = new ConstantAst("", label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithFields_Equality(string key, string label)
  {
    var left = new ConstantAst(label.ConstantObject(key));
    var right = new ConstantAst(label.ConstantObject(key));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithFields_Inequality(string key, string label)
  {
    var left = new ConstantAst(label.ConstantObject(key));
    var right = new ConstantAst(key, label);

    (left != right).Should().BeTrue();
  }
}
