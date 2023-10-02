using GqlPlus.Verifier.Ast;
using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class AstEqualityTests
{
  [Theory, RepeatData(Repeats)]
  public void ArgumentAst_WithVariable_Equality(string variable)
  {
    var left = new ArgumentAst(variable);
    var right = new ArgumentAst(variable);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  // FieldKeyAst
  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithNumber_Equality(decimal number)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(number);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithNumberString_Inequality(decimal number, string contents)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(contents);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithNumberEnumLabel_Inequality(decimal number, string enumType, string label)
  {
    var left = new FieldKeyAst(number);
    var right = new FieldKeyAst(enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithString_Equality(string contents)
  {
    var left = new FieldKeyAst(contents);
    var right = new FieldKeyAst(contents);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithStringEnumLabel_Inquality(string contents, string enumType, string label)
  {
    var left = new FieldKeyAst(contents);
    var right = new FieldKeyAst(enumType, label);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithEnumLabel_Equality(string enumType, string label)
  {
    var left = new FieldKeyAst(enumType, label);
    var right = new FieldKeyAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldKeyAst_WithEnumLabel_Inequality(string enumType, string label)
  {
    var left = new FieldKeyAst(enumType, label);
    var right = new FieldKeyAst(label, enumType);

    (left != right).Should().BeTrue();
  }

  // ConstantAst
  [Theory, RepeatData(Repeats)]
  public void ConstantAst_WithEnumLabel_Equality(string enumType, string label)
  {
    var left = new ConstantAst(enumType, label);
    var right = new ConstantAst(enumType, label);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void ConstantAst_WithEnumLabel_Inequality(string enumType, string label)
  {
    var left = new ConstantAst(enumType, label);
    var right = new ConstantAst(label, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void ConstantAst_WithValues_Equality(string label)
  {
    var left = new ConstantAst(label.ConstantList());
    var right = new ConstantAst(label.ConstantList());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void ConstantAst_WithFields_Equality(string key, string label)
  {
    var left = new ConstantAst(label.ConstantObject(key));
    var right = new ConstantAst(label.ConstantObject(key));

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  // FieldAst
  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithAlias_Equality(string name, string alias)
  {
    var left = new FieldAst(name) { Alias = alias };
    var right = new FieldAst(name) { Alias = alias };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithAlias_Inquality(string name, string alias)
  {
    var left = new FieldAst(name) { Alias = alias };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithSelection_Equality(string name, string field)
  {
    var left = new FieldAst(name) { Selections = field.Fields() };
    var right = new FieldAst(name) { Selections = field.Fields() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithSelection_Inequality(string name, string field)
  {
    var left = new FieldAst(name) { Selections = field.Fields() };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithDirective_Equality(string name, string directive)
  {
    var left = new FieldAst(name) { Directives = directive.Directives() };

    var right = new FieldAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FieldAst_WithDirective_Inequality(string name, string directive)
  {
    var left = new FieldAst(name) { Directives = directive.Directives() };
    var right = new FieldAst(name);

    (left != right).Should().BeTrue();
  }

  // FragmentAst
  [Theory, RepeatData(Repeats)]
  public void FragmentAst_Equality(string name, string onType, string field)
  {
    var left = new FragmentAst(name, onType, field.Fields());
    var right = new FragmentAst(name, onType, field.Fields());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FragmentAst_WithDirective_Equality(string name, string onType, string field, string directive)
  {
    var left = new FragmentAst(name, onType, field.Fields()) { Directives = directive.Directives() };
    var right = new FragmentAst(name, onType, field.Fields()) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void FragmentAst_WithDirective_Inequality(string name, string onType, string field, string directive)
  {
    var left = new FragmentAst(name, onType, field.Fields()) { Directives = directive.Directives() };
    var right = new FragmentAst(name, onType, field.Fields());

    (left != right).Should().BeTrue();
  }

  // InlineAst
  [Theory, RepeatData(Repeats)]
  public void InlineAst_Equality(string field)
  {
    var left = new InlineAst(field.Fields());
    var right = new InlineAst(field.Fields());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void InlineAst_WithOnType_Equality(string onType, string field)
  {
    var left = new InlineAst(field.Fields()) { OnType = onType };
    var right = new InlineAst(field.Fields()) { OnType = onType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void InlineAst_WithOnType_Inequality(string onType, string field)
  {
    var left = new InlineAst(field.Fields()) { OnType = onType };
    var right = new InlineAst(field.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void InlineAst_WithDirective_Equality(string field, string directive)
  {
    var left = new InlineAst(field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(field.Fields()) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void InlineAst_WithDirective_Inequality(string field, string directive)
  {
    var left = new InlineAst(field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(field.Fields());

    (left != right).Should().BeTrue();
  }

  // SpreadAst
  [Theory, RepeatData(Repeats)]
  public void SpreadAst_Equality(string name)
  {
    var left = new SpreadAst(name);
    var right = new SpreadAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void SpreadAst_WithDirective_Equality(string name, string directive)
  {
    var left = new SpreadAst(name) { Directives = directive.Directives() };
    var right = new SpreadAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void SpreadAst_WithDirective_Inequality(string name, string directive)
  {
    var left = new SpreadAst(name) { Directives = directive.Directives() };
    var right = new SpreadAst(name);

    (left != right).Should().BeTrue();
  }

  // VariableAst
  [Theory, RepeatData(Repeats)]
  public void VariableAst_Equality(string name)
  {
    var left = new VariableAst(name);
    var right = new VariableAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithType_Equality(string name, string varType)
  {
    var left = new VariableAst(name) { Type = varType };
    var right = new VariableAst(name) { Type = varType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithType_Inequality(string name, string varType)
  {
    var left = new VariableAst(name) { Type = varType };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithModifiers_Equality(string name)
  {
    var left = new VariableAst(name) { Modifers = TestMods() };
    var right = new VariableAst(name) { Modifers = TestMods() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithModifiers_Inequality(string name)
  {
    var left = new VariableAst(name) { Modifers = TestMods() };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithDirective_Equality(string name, string directive)
  {
    var left = new VariableAst(name) { Directives = directive.Directives() };
    var right = new VariableAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void VariableAst_WithDirective_Inequality(string name, string directive)
  {
    var left = new VariableAst(name) { Directives = directive.Directives() };
    var right = new VariableAst(name);

    (left != right).Should().BeTrue();
  }

  private ModifierAst[] TestMods()
    => new[] { ModifierAst.List, ModifierAst.Optional };
}
