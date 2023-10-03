namespace GqlPlus.Verifier.Ast;

public class VariableAstTests
{
  [Theory, RepeatData(Repeats)]
  public void Equality(string name)
  {
    var left = new VariableAst(name);
    var right = new VariableAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality(string name1, string name2)
  {
    var left = new VariableAst(name1);
    var right = new VariableAst(name2);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithType_Equality(string name, string varType)
  {
    var left = new VariableAst(name) { Type = varType };
    var right = new VariableAst(name) { Type = varType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithType_Inequality(string name, string varType)
  {
    var left = new VariableAst(name) { Type = varType };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_Equality(string name)
  {
    var left = new VariableAst(name) { Modifers = TestMods() };
    var right = new VariableAst(name) { Modifers = TestMods() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_Inequality(string name)
  {
    var left = new VariableAst(name) { Modifers = TestMods() };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Equality(string name, string directive)
  {
    var left = new VariableAst(name) { Directives = directive.Directives() };
    var right = new VariableAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Inequality(string name, string directive)
  {
    var left = new VariableAst(name) { Directives = directive.Directives() };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithDefault_Equality(string name, string value)
  {
    var left = new VariableAst(name) { Default = new ConstantAst(value) };
    var right = new VariableAst(name) { Default = new ConstantAst(value) };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithDefault_Inequality(string name, string value)
  {
    var left = new VariableAst(name) { Default = new ConstantAst(value) };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }
}
