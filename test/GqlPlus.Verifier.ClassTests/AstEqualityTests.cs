using GqlPlus.Verifier.Ast;
using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class AstEqualityTests
{
  [Theory, RepeatData(10)]
  public void DefinitionAst_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var leftField = new FieldAst(field);
    FieldAst[] leftSelections = new[] { leftField };
    var left = new DefinitionAst(name, onType) { Selections = leftSelections };

    var rightField = new FieldAst(field);
    FieldAst[] rightSelections = new[] { rightField };
    var right = new DefinitionAst(name, onType) { Selections = rightSelections };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
    leftSelections.Should().NotBeSameAs(rightSelections);
    leftField.Should().NotBeSameAs(rightField);
  }

  [Theory, RepeatData(10)]
  public void FieldAst_WithAlias_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string alias)
  {
    var left = new FieldAst(name) { Alias = alias };
    var right = new FieldAst(name) { Alias = alias };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(10)]
  public void FieldAst_WithSelection_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var leftField = new FieldAst(field);
    FieldAst[] leftSelections = new[] { leftField };
    var left = new FieldAst(name) { Selections = leftSelections };

    var rightField = new FieldAst(field);
    FieldAst[] rightSelections = new[] { rightField };
    var right = new FieldAst(name) { Selections = rightSelections };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
    leftSelections.Should().NotBeSameAs(rightSelections);
    leftField.Should().NotBeSameAs(rightField);
  }

  [Theory, RepeatData(10)]
  public void InlineAst_Equality(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var leftField = new FieldAst(field);
    FieldAst[] leftSelections = new[] { leftField };
    var left = new InlineAst { Selections = leftSelections };

    var rightField = new FieldAst(field);
    FieldAst[] rightSelections = new[] { rightField };
    var right = new InlineAst { Selections = rightSelections };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
    leftSelections.Should().NotBeSameAs(rightSelections);
    leftField.Should().NotBeSameAs(rightField);
  }

  [Theory, RepeatData(10)]
  public void InlineAst_WithOnType_Equality(
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var leftField = new FieldAst(field);
    FieldAst[] leftSelections = new[] { leftField };
    var left = new InlineAst { OnType = onType, Selections = leftSelections };

    var rightField = new FieldAst(field);
    FieldAst[] rightSelections = new[] { rightField };
    var right = new InlineAst { OnType = onType, Selections = rightSelections };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
    leftSelections.Should().NotBeSameAs(rightSelections);
    leftField.Should().NotBeSameAs(rightField);
  }

  [Theory, RepeatData(10)]
  public void NamedAst_Equality(
    [RegularExpression(IdentifierPattern)] string name)
  {
    var left = new NamedAst(name);
    var right = new NamedAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(10)]
  public void VariableAst_Equality(
    [RegularExpression(IdentifierPattern)] string name)
  {
    var left = new VariableAst(name);
    var right = new VariableAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(10)]
  public void VariableAst_WithType_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string varType)
  {
    var left = new VariableAst(name) { Type = varType };
    var right = new VariableAst(name) { Type = varType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(10)]
  public void VariableAst_WithModifiers_Equality(
    [RegularExpression(IdentifierPattern)] string name)
  {
    var leftMods = new[] { ModifierAst.List, ModifierAst.Optional };
    var left = new VariableAst(name) { Modifers = leftMods };

    var rightMods = new[] { ModifierAst.List, ModifierAst.Optional };
    var right = new VariableAst(name) { Modifers = rightMods };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
    leftMods.Should().NotBeSameAs(rightMods);
  }
}
