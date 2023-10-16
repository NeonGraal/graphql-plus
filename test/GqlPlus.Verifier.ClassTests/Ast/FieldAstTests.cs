namespace GqlPlus.Verifier.Ast;

public class FieldAstTests
{
  [Fact]
  public void HashCode()
    => new FieldAst(AstNulls.At, "").GetHashCode().Should().Be(new FieldAst(AstNulls.At, "").GetHashCode());

  [Theory, RepeatData(Repeats)]
  public void String(string name)
    => new FieldAst(AstNulls.At, name).TestString($"( !F {name} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithAlias(string name, string alias)
    => new FieldAst(AstNulls.At, name) { Alias = alias }
    .TestString($"( !F {alias}: {name} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithArgument(string variable, string name)
    => new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) }
    .TestString($"( !F {name} ( !A ${variable} ) )");

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => new FieldAst(AstNulls.At, name) { Modifiers = TestMods() }
    .TestString($"( !F {name} []? )");

  [Theory, RepeatData(Repeats)]
  public void String_WithSelection(string name, string field)
  => new FieldAst(AstNulls.At, name) { Selections = field.Fields() }
  .TestString($"( !F {name} {{ !F {field} }} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(string name, string directive)
    => new FieldAst(AstNulls.At, name) { Directives = directive.Directives() }
    .TestString($"( !F {name} ( !D {directive} ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality(string name)
  {
    var left = new FieldAst(AstNulls.At, name);
    var right = new FieldAst(AstNulls.At, name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inquality(string name)
  {
    var left = new FieldAst(AstNulls.At, name);
    var right = new FieldAst(AstNulls.At, name + "a");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlias(string name, string alias)
  {
    var left = new FieldAst(AstNulls.At, name) { Alias = alias };
    var right = new FieldAst(AstNulls.At, name) { Alias = alias };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inquality_WithAlias(string name, string alias)
  {
    var left = new FieldAst(AstNulls.At, name) { Alias = alias };
    var right = new FieldAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArgument(string variable, string name)
  {
    var left = new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) };
    var right = new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithArgument(string variable, string name)
  {
    var left = new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) };
    var right = new FieldAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(string name)
  {
    var left = new FieldAst(AstNulls.At, name) { Modifiers = TestMods() };
    var right = new FieldAst(AstNulls.At, name) { Modifiers = TestMods() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(string name)
  {
    var left = new FieldAst(AstNulls.At, name) { Modifiers = TestMods() };
    var right = new FieldAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithSelection(string name, string field)
  {
    var left = new FieldAst(AstNulls.At, name) { Selections = field.Fields() };
    var right = new FieldAst(AstNulls.At, name) { Selections = field.Fields() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithSelection(string name, string field)
  {
    var left = new FieldAst(AstNulls.At, name) { Selections = field.Fields() };
    var right = new FieldAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDirective(string name, string directive)
  {
    var left = new FieldAst(AstNulls.At, name) { Directives = directive.Directives() };

    var right = new FieldAst(AstNulls.At, name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(string name, string directive)
  {
    var left = new FieldAst(AstNulls.At, name) { Directives = directive.Directives() };
    var right = new FieldAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }
}
