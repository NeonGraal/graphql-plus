namespace GqlPlus.Verifier.Ast;

public class ArgumentAstTests
{
  [Fact]
  public void HashCode()
    => TestHashCode(() => new ArgumentAst(AstNulls.At));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithVariable(string variable)
    => TestHashCode(() => new ArgumentAst(AstNulls.At, variable));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithConstant(string enumType, string label)
    => TestHashCode(() => new ArgumentAst(new FieldKeyAst(AstNulls.At, enumType, label)));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithValues(string label)
    => TestHashCode(() => new ArgumentAst(AstNulls.At, label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string key, string label)
    => TestHashCode(() => new ArgumentAst(AstNulls.At, label.ArgumentObject(key)));

  [Theory, RepeatData(Repeats)]
  public void String_WithVariable(string variable)
    => new ArgumentAst(AstNulls.At, variable)
    .TestString($"( !A ${variable} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithConstant(string enumType, string label)
    => new ArgumentAst(new FieldKeyAst(AstNulls.At, enumType, label))
    .TestString($"( !K {enumType}.{label} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithValues(string label)
    => new ArgumentAst(AstNulls.At, label.ArgumentList())
    .TestString($"( !A [ !A ${label} !K {label} ] )");

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string key, string label)
    => new ArgumentAst(AstNulls.At, label.ArgumentObject(key))
    .TestString(
      $"( !A {{ ( !K {key} ):( !A ${label} ) ( !K {label} ):( !K {key} ) }} )",
      key == label);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithVariable(string variable)
  {
    var left = new ArgumentAst(AstNulls.At, variable);
    var right = new ArgumentAst(AstNulls.At, variable);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithVariable(string variable)
  {
    var left = new ArgumentAst(AstNulls.At, variable);
    var right = new ArgumentAst(AstNulls.At, variable + "a");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithConstant(string enumType, string label)
  {
    var left = new ArgumentAst(new FieldKeyAst(AstNulls.At, enumType, label));
    var right = new ArgumentAst(new FieldKeyAst(AstNulls.At, enumType, label));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithConstant(string enumType, string label)
  {
    if (enumType == label) {
      return;
    }

    var left = new ArgumentAst(new FieldKeyAst(AstNulls.At, enumType, label));
    var right = new ArgumentAst(new FieldKeyAst(AstNulls.At, label, enumType));

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithValues(string label)
  {
    var left = new ArgumentAst(AstNulls.At, label.ArgumentList());
    var right = new ArgumentAst(AstNulls.At, label.ArgumentList());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithValues(string label)
  {
    var left = new ArgumentAst(AstNulls.At, label.ArgumentList());
    var right = new ArgumentAst(AstNulls.At, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string key, string label)
  {
    var left = new ArgumentAst(AstNulls.At, label.ArgumentObject(key));
    var right = new ArgumentAst(AstNulls.At, label.ArgumentObject(key));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithFields(string key, string label)
  {
    var left = new ArgumentAst(AstNulls.At, label.ArgumentObject(key));
    var right = new ArgumentAst(AstNulls.At, label);

    (left != right).Should().BeTrue();
  }
}
