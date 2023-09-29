using GqlPlus.Verifier.Ast;
using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class AstEqualityTests
{
  [Theory, RepeatAutoData(10)]
  public void DefinitionAst_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var leftField = new FieldAst(field);
    var leftSelections = new[] { leftField };
    var left = new DefinitionAst(name, onType) { Selections = leftSelections };

    var rightField = new FieldAst(field); 
    var rightSelections = new[] { rightField };
    var right = new DefinitionAst(name, onType) { Selections = rightSelections };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
    leftSelections.Should().NotBeSameAs(rightSelections);
    leftField.Should().NotBeSameAs(rightField);
  }

  [Theory, RepeatAutoData(10)]
  public void FieldAst_WithAlias_Equality(
    [RegularExpression(IdentifierPattern)] string name,
    [RegularExpression(IdentifierPattern)] string alias)
  {
    var left = new FieldAst(name) { Alias = alias };
    var right = new FieldAst(name) { Alias = alias };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatAutoData(10)]
  public void InlineAst_Equality(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var leftField = new FieldAst(field);
    var leftSelections = new[] { leftField };
    var left = new InlineAst { Selections = leftSelections };

    var rightField = new FieldAst(field);
    var rightSelections = new[] { rightField };
    var right = new InlineAst { Selections = rightSelections };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
    leftSelections.Should().NotBeSameAs(rightSelections);
    leftField.Should().NotBeSameAs(rightField);
  }

  [Theory, RepeatAutoData(10)]
  public void InlineAst_WithOnType_Equality(
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var leftField = new FieldAst(field);
    var leftSelections = new[] { leftField };
    var left = new InlineAst { OnType = onType, Selections = leftSelections };

    var rightField = new FieldAst(field);
    var rightSelections = new[] { rightField };
    var right = new InlineAst { OnType = onType, Selections = rightSelections };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
    leftSelections.Should().NotBeSameAs(rightSelections);
    leftField.Should().NotBeSameAs(rightField);
  }

  [Theory, RepeatAutoData(10)]
  public void NamedAst_Equality(
    [RegularExpression(IdentifierPattern)] string name)
  {
    var left = new NamedAst(name);
    var right = new NamedAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }
}
