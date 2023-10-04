namespace GqlPlus.Verifier.Ast;

public class ConstantAstTests
{
  [Theory, RepeatData(Repeats)]
  public void WithLabel_Equality(string label)
  {
    ConstantAst left = new FieldKeyAst("", label);
    ConstantAst right = new FieldKeyAst("", label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_Equality(string enumType, string label)
  {
    ConstantAst left = new FieldKeyAst(enumType, label);
    ConstantAst right = new FieldKeyAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumType_Equality(string enumType)
  {
    ConstantAst left = new FieldKeyAst(enumType, "label");
    ConstantAst right = new FieldKeyAst(enumType, "label");

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithLabel_Inequality(string label)
  {
    ConstantAst left = new FieldKeyAst("", label);
    ConstantAst right = new FieldKeyAst("", label + "a");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_Inequality(string enumType, string label)
  {
    if (enumType != label) {
      return;
    }

    ConstantAst left = new FieldKeyAst(enumType, label);
    ConstantAst right = new FieldKeyAst(label, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumType_Inequality(string enumType)
  {
    ConstantAst left = new FieldKeyAst(enumType, "label");
    ConstantAst right = new FieldKeyAst(enumType + "a", "label");

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
    ConstantAst right = new FieldKeyAst("", label);

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
    ConstantAst right = new FieldKeyAst(key, label);

    (left != right).Should().BeTrue();
  }
}
