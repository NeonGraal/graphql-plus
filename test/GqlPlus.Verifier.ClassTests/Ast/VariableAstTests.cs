namespace GqlPlus.Verifier.Ast;

public class VariableAstTests : BaseNamedDirectivesAstTests
{
  [Theory, RepeatData(Repeats)]
  public void String_WithType(string name, string varType)
    => new VariableAst(AstNulls.At, name) { Type = varType }.TestString($"( !V {name} :{varType} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => new VariableAst(AstNulls.At, name) { Modifers = TestMods() }.TestString($"( !V {name} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(string name, string value)
    => new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) }.TestString($"( !V {name} =( !K '{value}' ) )");

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

  internal override BaseNamedDirectivesAstChecks DirectivesChecks { get; }
    = new BaseNamedDirectivesAstChecks<VariableAst>(name => new VariableAst(AstNulls.At, name));
}
