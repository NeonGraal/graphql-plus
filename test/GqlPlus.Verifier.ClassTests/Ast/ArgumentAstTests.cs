namespace GqlPlus.Verifier.Ast;

public class ArgumentAstTests
{
  [Theory, RepeatData(Repeats)]
  public void String_WithVariable(string variable)
    => new ArgumentAst(variable)
    .TestString($"A(${variable})");

  [Theory, RepeatData(Repeats)]
  public void String_WithConstant(string enumType, string label)
    => new ArgumentAst(new FieldKeyAst(enumType, label))
    .TestString($"A({enumType}.{label})");

  [Theory, RepeatData(Repeats)]
  public void String_WithValues(string label)
    => new ArgumentAst(label.ArgumentList())
    .TestString($"A([ A(${label}) A({label}) ])");

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string key, string label)
    => new ArgumentAst(label.ArgumentObject(key))
    .TestString(
      $"A({{ K({key}):A(${label}) K({label}):A({key}) }})",
      key == label);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithVariable(string variable)
  {
    var left = new ArgumentAst(variable);
    var right = new ArgumentAst(variable);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithVariable(string variable)
  {
    var left = new ArgumentAst(variable);
    var right = new ArgumentAst(variable + "a");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithConstant(string enumType, string label)
  {
    var left = new ArgumentAst(new FieldKeyAst(enumType, label));
    var right = new ArgumentAst(new FieldKeyAst(enumType, label));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithConstant(string enumType, string label)
  {
    if (enumType == label) {
      return;
    }

    var left = new ArgumentAst(new FieldKeyAst(enumType, label));
    var right = new ArgumentAst(new FieldKeyAst(label, enumType));

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithValues(string label)
  {
    var left = new ArgumentAst(label.ArgumentList());
    var right = new ArgumentAst(label.ArgumentList());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithValues(string label)
  {
    var left = new ArgumentAst(label.ArgumentList());
    var right = new ArgumentAst(label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string key, string label)
  {
    var left = new ArgumentAst(label.ArgumentObject(key));
    var right = new ArgumentAst(label.ArgumentObject(key));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithFields(string key, string label)
  {
    var left = new ArgumentAst(label.ArgumentObject(key));
    var right = new ArgumentAst(label);

    (left != right).Should().BeTrue();
  }
}
