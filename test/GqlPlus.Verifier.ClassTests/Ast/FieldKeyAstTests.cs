namespace GqlPlus.Verifier.Ast;

public class FieldKeyAstTests
{
  [Theory, RepeatData(Repeats)]
  public void String_WithNumber(decimal number)
    => new FieldKeyAst(AstNulls.At, number).TestString($"( !K {number} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithString(string contents)
    => new FieldKeyAst(AstNulls.At, contents).TestString($"( !K '{contents}' )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumLabel(string enumType, string label)
    => new FieldKeyAst(AstNulls.At, enumType, label).TestString($"( !K {enumType}.{label} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithLabel(string label)
    => new FieldKeyAst(AstNulls.At, "", label).TestString($"( !K {label} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithNumber(decimal number)
  {
    var left = new FieldKeyAst(AstNulls.At, number);
    var right = new FieldKeyAst(AstNulls.At, number);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithNumber(decimal number1, decimal number2)
  {
    var left = new FieldKeyAst(AstNulls.At, number1);
    var right = new FieldKeyAst(AstNulls.At, number2);

    left.CompareTo(right).Should().Be(number1.CompareTo(number2));
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberString(decimal number, string contents)
  {
    var left = new FieldKeyAst(AstNulls.At, number);
    var right = new FieldKeyAst(AstNulls.At, contents);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberEnumLabel(decimal number, string enumType, string label)
  {
    var left = new FieldKeyAst(AstNulls.At, number);
    var right = new FieldKeyAst(AstNulls.At, enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithString(string contents)
  {
    var left = new FieldKeyAst(AstNulls.At, contents);
    var right = new FieldKeyAst(AstNulls.At, contents);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithString(string contents1, string contents2)
  {
    var left = new FieldKeyAst(AstNulls.At, contents1);
    var right = new FieldKeyAst(AstNulls.At, contents2);
    var expected = string.Compare(contents1, contents2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inquality_WithStringEnumLabel(string contents, string enumType, string label)
  {
    var left = new FieldKeyAst(AstNulls.At, contents);
    var right = new FieldKeyAst(AstNulls.At, enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumLabel(string enumType, string label)
  {
    var left = new FieldKeyAst(AstNulls.At, enumType, label);
    var right = new FieldKeyAst(AstNulls.At, enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumLabel(string enumType, string label1, string label2)
  {
    var left = new FieldKeyAst(AstNulls.At, enumType, label1);
    var right = new FieldKeyAst(AstNulls.At, enumType, label2);
    var expected = string.Compare(enumType + "." + label1, enumType + "." + label2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumLabel(string enumType, string label)
  {
    if (enumType != label) {
      return;
    }

    var left = new FieldKeyAst(AstNulls.At, enumType, label);
    var right = new FieldKeyAst(AstNulls.At, label, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithLabel(string label)
  {
    var left = new FieldKeyAst(AstNulls.At, "", label);
    var right = new FieldKeyAst(AstNulls.At, "", label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithLabel(string label1, string label2)
  {
    var left = new FieldKeyAst(AstNulls.At, "", label1);
    var right = new FieldKeyAst(AstNulls.At, "", label2);
    var expected = string.Compare(label1, label2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithLabel(string label)
  {
    var left = new FieldKeyAst(AstNulls.At, "", label);
    var right = new FieldKeyAst(AstNulls.At, label, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumType(string enumType)
  {
    var left = new FieldKeyAst(AstNulls.At, enumType, "label");
    var right = new FieldKeyAst(AstNulls.At, enumType, "label");

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumType(string enumType1, string enumType2)
  {
    var left = new FieldKeyAst(AstNulls.At, enumType1, "label");
    var right = new FieldKeyAst(AstNulls.At, enumType2, "label");
    var expected = string.Compare(enumType1 + ".label", enumType2 + ".label", StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumType(string enumType)
  {
    var left = new FieldKeyAst(AstNulls.At, enumType, "label");
    var right = new FieldKeyAst(AstNulls.At, enumType, enumType + "label");

    (left != right).Should().BeTrue();
  }
}
