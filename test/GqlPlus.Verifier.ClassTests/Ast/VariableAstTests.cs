namespace GqlPlus.Verifier.Ast;

public class VariableAstTests
{
  [Fact]
  public void HashCode()
    => new VariableAst(AstNulls.At, "").GetHashCode().Should().Be(new VariableAst(AstNulls.At, "").GetHashCode());

  [Theory, RepeatData(Repeats)]
  public void String(string name)
    => new VariableAst(AstNulls.At, name).TestString("V(" + name + ")");

  [Theory, RepeatData(Repeats)]
  public void String_WithType(string name, string varType)
    => new VariableAst(AstNulls.At, name) { Type = varType }.TestString($"V({name} :{varType})");

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => new VariableAst(AstNulls.At, name) { Modifers = TestMods() }.TestString($"V({name} [] ?)");

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(string name, string directive)
    => new VariableAst(AstNulls.At, name) { Directives = directive.Directives() }.TestString($"V({name} D({directive}))");

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(string name, string value)
    => new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) }.TestString($"V({name} =C('{value}'))");

  [Theory, RepeatData(Repeats)]
  public void Equality(string name)
  {
    var left = new VariableAst(AstNulls.At, name);
    var right = new VariableAst(AstNulls.At, name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality(string name1, string name2)
  {
    if (name1 == name2) {
      return;
    }

    var left = new VariableAst(AstNulls.At, name1);
    var right = new VariableAst(AstNulls.At, name2);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithType(string name, string varType)
  {
    var left = new VariableAst(AstNulls.At, name) { Type = varType };
    var right = new VariableAst(AstNulls.At, name) { Type = varType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithType(string name, string varType)
  {
    var left = new VariableAst(AstNulls.At, name) { Type = varType };
    var right = new VariableAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(string name)
  {
    var left = new VariableAst(AstNulls.At, name) { Modifers = TestMods() };
    var right = new VariableAst(AstNulls.At, name) { Modifers = TestMods() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(string name)
  {
    var left = new VariableAst(AstNulls.At, name) { Modifers = TestMods() };
    var right = new VariableAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDirective(string name, string directive)
  {
    var left = new VariableAst(AstNulls.At, name) { Directives = directive.Directives() };
    var right = new VariableAst(AstNulls.At, name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(string name, string directive)
  {
    var left = new VariableAst(AstNulls.At, name) { Directives = directive.Directives() };
    var right = new VariableAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDefault(string name, string value)
  {
    var left = new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) };
    var right = new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDefault(string name, string value)
  {
    var left = new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) };
    var right = new VariableAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }
}
