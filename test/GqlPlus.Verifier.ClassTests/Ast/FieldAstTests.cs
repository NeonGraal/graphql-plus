namespace GqlPlus.Verifier.Ast;

public class FieldAstTests : BaseNamedDirectivesAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlias(string name, string alias)
    => TestHashCode(() => new FieldAst(AstNulls.At, name) { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArgument(string variable, string name)
    => TestHashCode(() => new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(string name)
    => TestHashCode(() => new FieldAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithSelection(string name, string field)
  => TestHashCode(() => new FieldAst(AstNulls.At, name) { Selections = field.Fields() });

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

  internal override BaseNamedDirectivesAstChecks DirectivesChecks { get; }
    = new BaseNamedDirectivesAstChecks<FieldAst>(name => new FieldAst(AstNulls.At, name));
}
