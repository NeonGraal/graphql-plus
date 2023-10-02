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
  public void WithEnumLabel_Inequality(string enumType, string label)
  {
    var left = new FieldKeyAst(enumType, label);
    var right = new FieldKeyAst(label, enumType);

    (left != right).Should().BeTrue();
  }
}
