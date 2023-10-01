using GqlPlus.Verifier.Ast;
using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class AstEqualityTests
{
  [Theory, RepeatData(Repeats)]
  public void ArgumentAst_WithVariable_Equality(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var left = new ArgumentAst { Variable = variable };
    var right = new ArgumentAst { Variable = variable };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void ConstantAst_WithEnumLabel_Equality(
    [RegularExpression(IdentifierPattern)] string enumType,
    [RegularExpression(IdentifierPattern)] string label)
  {
    var left = new ConstantAst { Type = enumType, Label = label };
    var right = new ConstantAst { Type = enumType, Label = label };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  // FieldAst
  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithAlias_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string alias)
  {
    var left = new FieldAst(name) { Alias = alias };
    var right = new FieldAst(name) { Alias = alias };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithAlias_Inquality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string alias)
  {
    var left = new FieldAst(name) { Alias = alias };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithSelection_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var left = new FieldAst(name) { Selections = field.Fields() };
    var right = new FieldAst(name) { Selections = field.Fields() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithSelection_Inequality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var left = new FieldAst(name) { Selections = field.Fields() };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithDirective_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new FieldAst(name) { Directives = directive.Directives() };

    var right = new FieldAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithDirective_Inequality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new FieldAst(name) { Directives = directive.Directives() };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  // FragmentAst
  [Theory, RepeatData(Repeats)]
  public void FragmentAst_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var left = new FragmentAst(name, onType, field.Fields());
    var right = new FragmentAst(name, onType, field.Fields());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FragmentAst_WithDirective_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new FragmentAst(name, onType, field.Fields()) { Directives = directive.Directives() };
    var right = new FragmentAst(name, onType, field.Fields()) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FragmentAst_WithDirective_Inequality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new FragmentAst(name, onType, field.Fields()) { Directives = directive.Directives() };
    var right = new FragmentAst(name, onType, field.Fields());

    (left != right).Should().BeTrue();
  }

  // InlineAst
  [Theory, RepeatData(Repeats)]
  public void InlineAst_Equality(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var left = new InlineAst(field.Fields());
    var right = new InlineAst(field.Fields());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void InlineAst_WithOnType_Equality(
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var left = new InlineAst(field.Fields()) { OnType = onType };
    var right = new InlineAst(field.Fields()) { OnType = onType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void InlineAst_WithOnType_Inequality(
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var left = new InlineAst(field.Fields()) { OnType = onType };
    var right = new InlineAst(field.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void InlineAst_WithDirective_Equality(
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new InlineAst(field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(field.Fields()) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void InlineAst_WithDirective_Inequality(
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new InlineAst(field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(field.Fields());

    (left != right).Should().BeTrue();
  }

  // SpreadAst
  [Theory, RepeatData(Repeats)]
  public void SpreadAst_Equality(
    [RegularExpression(IdentifierPattern)] string name)
  {
    var left = new SpreadAst(name);
    var right = new SpreadAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void SpreadAst_WithDirective_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new SpreadAst(name) { Directives = directive.Directives() };
    var right = new SpreadAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void SpreadAst_WithDirective_Inequality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new SpreadAst(name) { Directives = directive.Directives() };
    var right = new SpreadAst(name);

    (left != right).Should().BeTrue();
  }

  // VariableAst
  [Theory, RepeatData(Repeats)]
  public void VariableAst_Equality(
    [RegularExpression(IdentifierPattern)] string name)
  {
    var left = new VariableAst(name);
    var right = new VariableAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithType_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string varType)
  {
    var left = new VariableAst(name) { Type = varType };
    var right = new VariableAst(name) { Type = varType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithType_Inequality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string varType)
  {
    var left = new VariableAst(name) { Type = varType };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithModifiers_Equality(
    [RegularExpression(IdentifierPattern)] string name)
  {
    var left = new VariableAst(name) { Modifers = TestMods() };
    var right = new VariableAst(name) { Modifers = TestMods() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithModifiers_Inequality(
    [RegularExpression(IdentifierPattern)] string name)
  {
    var left = new VariableAst(name) { Modifers = TestMods() };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithDirective_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new VariableAst(name) { Directives = directive.Directives() };
    var right = new VariableAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithDirective_Inequality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var left = new VariableAst(name) { Directives = directive.Directives() };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }

  private ModifierAst[] TestMods()
    => new[] { ModifierAst.List, ModifierAst.Optional };
}
