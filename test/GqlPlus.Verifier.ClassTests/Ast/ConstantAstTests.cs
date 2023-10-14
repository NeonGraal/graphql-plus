namespace GqlPlus.Verifier.Ast;

public class ConstantAstTests
{
  [Fact]
  public void HashCode()
    => new ConstantAst(AstNulls.At).GetHashCode().Should().Be(new ConstantAst(AstNulls.At).GetHashCode());

  [Theory, RepeatData(Repeats)]
  public void String_WithLabel(string label)
    => new ConstantAst(new FieldKeyAst(AstNulls.At, "", label))
    .TestString($"C({label})");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumLabel(string enumType, string label)
    => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, label))
    .TestString($"C({enumType}.{label})");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumType(string enumType)
    => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, "label"))
    .TestString($"C({enumType}.label)");

  [Theory, RepeatData(Repeats)]
  public void String_WithValues(string label)
    => new ConstantAst(AstNulls.At, label.ConstantList())
    .TestString($"C([ C({label}) C({label}) ])");

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string key, string label)
    => new ConstantAst(AstNulls.At, label.ConstantObject(key))
    .TestString(
      $"C({{ K({key}):C({label}) K({label}):C({key}) }})",
      key == label);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithLabel(string label)
  {
    ConstantAst left = new FieldKeyAst(AstNulls.At, "", label);
    ConstantAst right = new FieldKeyAst(AstNulls.At, "", label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumLabel(string enumType, string label)
  {
    ConstantAst left = new FieldKeyAst(AstNulls.At, enumType, label);
    ConstantAst right = new FieldKeyAst(AstNulls.At, enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumType(string enumType)
  {
    ConstantAst left = new FieldKeyAst(AstNulls.At, enumType, "label");
    ConstantAst right = new FieldKeyAst(AstNulls.At, enumType, "label");

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithLabel(string label)
  {
    ConstantAst left = new FieldKeyAst(AstNulls.At, "", label);
    ConstantAst right = new FieldKeyAst(AstNulls.At, "", label + "a");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumLabel(string enumType, string label)
  {
    if (enumType == label) {
      return;
    }

    ConstantAst left = new FieldKeyAst(AstNulls.At, enumType, label);
    ConstantAst right = new FieldKeyAst(AstNulls.At, label, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumType(string enumType)
  {
    ConstantAst left = new FieldKeyAst(AstNulls.At, enumType, "label");
    ConstantAst right = new FieldKeyAst(AstNulls.At, enumType + "a", "label");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithValues(string label)
  {
    var left = new ConstantAst(AstNulls.At, label.ConstantList());
    var right = new ConstantAst(AstNulls.At, label.ConstantList());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithValues(string label)
  {
    var left = new ConstantAst(AstNulls.At, label.ConstantList());
    ConstantAst right = new FieldKeyAst(AstNulls.At, "", label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string key, string label)
  {
    var left = new ConstantAst(AstNulls.At, label.ConstantObject(key));
    var right = new ConstantAst(AstNulls.At, label.ConstantObject(key));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithFields(string key, string label)
  {
    var left = new ConstantAst(AstNulls.At, label.ConstantObject(key));
    ConstantAst right = new FieldKeyAst(AstNulls.At, key, label);

    (left != right).Should().BeTrue();
  }
}
