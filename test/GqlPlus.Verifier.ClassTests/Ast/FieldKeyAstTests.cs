namespace GqlPlus.Verifier.Ast;

public class FieldKeyAstTests
{
  [Theory, RepeatData(Repeats)]
  public void WithNumber_Equality(decimal number)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(number);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithNumber_Compare(decimal number1, decimal number2)
  {
    var left = new FieldKeyAst(number1);
    var right = new FieldKeyAst(number2);

    left.CompareTo(right).Should().Be(number1.CompareTo(number2));
  }

  [Theory, RepeatData(Repeats)]
  public void WithNumberString_Inequality(decimal number, string contents)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(contents);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithNumberEnumLabel_Inequality(decimal number, string enumType, string label)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithString_Equality(string contents)
  {
    var left = new FieldKeyAst(contents);
    var right = new FieldKeyAst(contents);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithString_Compare(string contents1, string contents2)
  {
    var left = new FieldKeyAst(contents1);
    var right = new FieldKeyAst(contents2);

    left.CompareTo(right).Should().Be(contents1.CompareTo(contents2));
  }

  [Theory, RepeatData(Repeats)]
  public void WithStringEnumLabel_Inquality(string contents, string enumType, string label)
  {
    var left = new FieldKeyAst(contents);
    var right = new FieldKeyAst(enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_Equality(string enumType, string label)
  {
    var left = new FieldKeyAst(enumType, label);
    var right = new FieldKeyAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_Compare(string enumType, string label1, string label2)
  {
    var left = new FieldKeyAst(enumType, label1);
    var right = new FieldKeyAst(enumType, label2);

    left.CompareTo(right).Should().Be(label1.CompareTo(label2));
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_Inequality(string enumType, string label)
  {
    var left = new FieldKeyAst(enumType, label);
    var right = new FieldKeyAst(label, enumType);

    (left != right).Should().Be(enumType != label);
  }

  [Theory, RepeatData(Repeats)]
  public void WithLabel_Equality(string label)
  {
    var left = new FieldKeyAst("", label);
    var right = new FieldKeyAst("", label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithLabel_Compare(string label1, string label2)
  {
    var left = new FieldKeyAst("", label1);
    var right = new FieldKeyAst("", label2);

    left.CompareTo(right).Should().Be(label1.CompareTo(label2));
  }

  [Theory, RepeatData(Repeats)]
  public void WithLabel_Inequality(string label)
  {
    var left = new FieldKeyAst("", label);
    var right = new FieldKeyAst(label, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumType_Equality(string enumType)
  {
    var left = new FieldKeyAst(enumType, "label");
    var right = new FieldKeyAst(enumType, "label");

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumType_Compare(string enumType1, string enumType2)
  {
    var left = new FieldKeyAst(enumType1, "label");
    var right = new FieldKeyAst(enumType2, "label");

    left.CompareTo(right).Should().Be(enumType1.CompareTo(enumType2));
  }

  [Theory, RepeatData(Repeats)]
  public void WithEnumType_Inequality(string enumType)
  {
    var left = new FieldKeyAst(enumType, "label");
    var right = new FieldKeyAst(enumType, enumType + "label");

    (left != right).Should().BeTrue();
  }
}
