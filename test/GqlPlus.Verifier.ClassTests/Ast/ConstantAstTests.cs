namespace GqlPlus.Verifier.Ast;

public class ConstantAstTests
{
  [Theory, RepeatData(Repeats)]
  public void Equality_WithLabel(string label)
  {
    ConstantAst left = new FieldKeyAst("", label);
    ConstantAst right = new FieldKeyAst("", label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumLabel(string enumType, string label)
  {
    ConstantAst left = new FieldKeyAst(enumType, label);
    ConstantAst right = new FieldKeyAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumType(string enumType)
  {
    ConstantAst left = new FieldKeyAst(enumType, "label");
    ConstantAst right = new FieldKeyAst(enumType, "label");

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithLabel(string label)
  {
    ConstantAst left = new FieldKeyAst("", label);
    ConstantAst right = new FieldKeyAst("", label + "a");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumLabel(string enumType, string label)
  {
    if (enumType != label) {
      return;
    }

    ConstantAst left = new FieldKeyAst(enumType, label);
    ConstantAst right = new FieldKeyAst(label, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumType(string enumType)
  {
    ConstantAst left = new FieldKeyAst(enumType, "label");
    ConstantAst right = new FieldKeyAst(enumType + "a", "label");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithValues(string label)
  {
    var left = new ConstantAst(label.ConstantList());
    var right = new ConstantAst(label.ConstantList());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithValues(string label)
  {
    var left = new ConstantAst(label.ConstantList());
    ConstantAst right = new FieldKeyAst("", label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string key, string label)
  {
    var left = new ConstantAst(label.ConstantObject(key));
    var right = new ConstantAst(label.ConstantObject(key));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithFields(string key, string label)
  {
    var left = new ConstantAst(label.ConstantObject(key));
    ConstantAst right = new FieldKeyAst(key, label);

    (left != right).Should().BeTrue();
  }
}
