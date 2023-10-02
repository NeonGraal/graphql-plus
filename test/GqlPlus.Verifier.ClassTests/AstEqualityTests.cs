using GqlPlus.Verifier.Ast;
using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class AstEqualityTests
{
  [Theory, RepeatData(Repeats)]
  public void ArgumentAst_WithVariable_Equality(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var left = new ArgumentAst(variable);
    var right = new ArgumentAst(variable);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  // FieldKeyAst
  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithNumber_Equality(
    [Range(-99999.99999, 99999.99999)] decimal number)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(number);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithNumberString_Inequality(
    [Range(-99999.99999, 99999.99999)] decimal number,
    [RegularExpression(IdentifierPattern)] string content)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(content);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithNumberEnumLabel_Inequality(
    [Range(-99999.99999, 99999.99999)] decimal number,
    [RegularExpression(IdentifierPattern)] string enumType,
    [RegularExpression(IdentifierPattern)] string label)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithString_Equality(
    [RegularExpression(IdentifierPattern)] string content)
  {
    var left = new FieldKeyAst(content);
    var right = new FieldKeyAst(content);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithStringEnumLabel_Inquality(
    [RegularExpression(IdentifierPattern)] string content,
    [RegularExpression(IdentifierPattern)] string enumType,
    [RegularExpression(IdentifierPattern)] string label)
  {
    var left = new FieldKeyAst(content);
    var right = new FieldKeyAst(enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithEnumLabel_Equality(
    [RegularExpression(IdentifierPattern)] string enumType,
    [RegularExpression(IdentifierPattern)] string label)
  {
    var left = new FieldKeyAst(enumType, label);
    var right = new FieldKeyAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithEnumLabel_Inequality(
    [RegularExpression(IdentifierPattern)] string enumType,
    [RegularExpression(IdentifierPattern)] string label)
  {
    var left = new FieldKeyAst(enumType, label);
    var right = new FieldKeyAst(label, enumType);

    (left != right).Should().BeTrue();
  }

  // ConstantAst
  [Theory, RepeatData(Repeats)]
  public void ConstantAst_WithEnumLabel_Equality(
    [RegularExpression(IdentifierPattern)] string enumType,
    [RegularExpression(IdentifierPattern)] string label)
  {
    var left = new ConstantAst(enumType, label);
    var right = new ConstantAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void ConstantAst_WithEnumLabel_Inequality(
    [RegularExpression(IdentifierPattern)] string enumType,
    [RegularExpression(IdentifierPattern)] string label)
  {
    var left = new ConstantAst(enumType, label);
    var right = new ConstantAst(label, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void ConstantAst_WithValues_Equality(
    [RegularExpression(IdentifierPattern)] string label)
  {
    var left = new ConstantAst(label.ConstantList());
    var right = new ConstantAst(label.ConstantList());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void ConstantAst_WithFields_Equality(
    [RegularExpression(IdentifierPattern)] string key,
    [RegularExpression(IdentifierPattern)] string label)
  {
    var left = new ConstantAst(label.ConstantObject(key));
    var right = new ConstantAst(label.ConstantObject(key));

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
