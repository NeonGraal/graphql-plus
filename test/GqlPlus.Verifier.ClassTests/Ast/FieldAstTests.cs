namespace GqlPlus.Verifier.Ast;

public class FieldAstTests
{
  [Theory, RepeatData(Repeats)]
  public void Equality(string name)
  {
    var left = new FieldAst(name);
    var right = new FieldAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inquality(string name)
  {
    var left = new FieldAst(name);
    var right = new FieldAst(name + "a");

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithAlias_Equality(string name, string alias)
  {
    var left = new FieldAst(name) { Alias = alias };
    var right = new FieldAst(name) { Alias = alias };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithAlias_Inquality(string name, string alias)
  {
    var left = new FieldAst(name) { Alias = alias };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithArgument_Equality(string variable, string name)
  {
    var left = new FieldAst(name) { Argument = new ArgumentAst(variable) };
    var right = new FieldAst(name) { Argument = new ArgumentAst(variable) };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithArgument_Inequality(string variable, string name)
  {
    var left = new FieldAst(name) { Argument = new ArgumentAst(variable) };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_Equality(string name)
  {
    var left = new FieldAst(name) { Modifiers = TestMods() };
    var right = new FieldAst(name) { Modifiers = TestMods() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_Inequality(string name)
  {
    var left = new FieldAst(name) { Modifiers = TestMods() };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithSelection_Equality(string name, string field)
  {
    var left = new FieldAst(name) { Selections = field.Fields() };
    var right = new FieldAst(name) { Selections = field.Fields() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithSelection_Inequality(string name, string field)
  {
    var left = new FieldAst(name) { Selections = field.Fields() };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Equality(string name, string directive)
  {
    var left = new FieldAst(name) { Directives = directive.Directives() };

    var right = new FieldAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Inequality(string name, string directive)
  {
    var left = new FieldAst(name) { Directives = directive.Directives() };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }
}
