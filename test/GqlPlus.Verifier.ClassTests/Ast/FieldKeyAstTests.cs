namespace GqlPlus.Verifier.Ast;

public class FieldKeyAstTests
{
  [Theory, RepeatData(Repeats)]
  public void String_WithNumber(decimal number)
    => new FieldKeyAst(number).TestString($"FieldKey({number})");

  [Theory, RepeatData(Repeats)]
  public void String_WithString(string contents)
    => new FieldKeyAst(contents).TestString($"FieldKey('{contents}')");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithNumber(decimal number)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(number);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithNumber(decimal number1, decimal number2)
  {
    var left = new FieldKeyAst(number1);
    var right = new FieldKeyAst(number2);

    left.CompareTo(right).Should().Be(number1.CompareTo(number2));
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberString(decimal number, string contents)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(contents);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberEnumLabel(decimal number, string enumType, string label)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithString(string contents)
  {
    var left = new FieldKeyAst(contents);
    var right = new FieldKeyAst(contents);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithString(string contents1, string contents2)
  {
    var left = new FieldKeyAst(contents1);
    var right = new FieldKeyAst(contents2);

    left.CompareTo(right).Should().Be(contents1.CompareTo(contents2));
  }

  [Theory, RepeatData(Repeats)]
  public void Inquality_WithStringEnumLabel(string contents, string enumType, string label)
  {
    var left = new FieldKeyAst(contents);
    var right = new FieldKeyAst(enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumLabel(string enumType, string label)
  {
    var left = new FieldKeyAst(enumType, label);
    var right = new FieldKeyAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumLabel(string enumType, string label1, string label2)
  {
    var left = new FieldKeyAst(enumType, label1);
    var right = new FieldKeyAst(enumType, label2);

    left.CompareTo(right).Should().Be(label1.CompareTo(label2));
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumLabel(string enumType, string label)
  {
    if (enumType != label) {
      return;
    }

    var left = new FieldKeyAst(enumType, label);
    var right = new FieldKeyAst(label, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithLabel(string label)
  {
    var left = new FieldKeyAst("", label);
    var right = new FieldKeyAst("", label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithLabel(string label1, string label2)
  {
    var left = new FieldKeyAst("", label1);
    var right = new FieldKeyAst("", label2);

    left.CompareTo(right).Should().Be(label1.CompareTo(label2));
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithLabel(string label)
  {
    var left = new FieldKeyAst("", label);
    var right = new FieldKeyAst(label, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumType(string enumType)
  {
    var left = new FieldKeyAst(enumType, "label");
    var right = new FieldKeyAst(enumType, "label");

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumType(string enumType1, string enumType2)
  {
    var left = new FieldKeyAst(enumType1, "label");
    var right = new FieldKeyAst(enumType2, "label");

    left.CompareTo(right).Should().Be(enumType1.CompareTo(enumType2));
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumType(string enumType)
  {
    var left = new FieldKeyAst(enumType, "label");
    var right = new FieldKeyAst(enumType, enumType + "label");

    (left != right).Should().BeTrue();
  }
}
