namespace GqlPlus.Ast;

public partial class EnumValueAstTests
{
  private const string TestLabel = "testLabel";

  [Theory, RepeatData]
  public void HashCode_WithLabel(string enumLabel)
    => _checks.HashCode(() => CreateEnumValue(enumLabel));

  [Theory, RepeatData]
  public void HashCode_WithTypeAndLabel(string enumType, string enumLabel)
    => _checks.HashCode(() => CreateEnumValue(enumType, enumLabel));

  [Theory, RepeatData]
  public void Text_WithLabel(string enumLabel)
    => _checks.Text(
      () => CreateEnumValue(enumLabel),
      $"( !e {enumLabel} )");

  [Theory, RepeatData]
  public void Text_WithTypeAndLabel(string enumType, string enumLabel)
    => _checks.Text(
      () => CreateEnumValue(enumType, enumLabel),
      $"( !e {enumType}.{enumLabel} )");

  [Theory, RepeatData]
  public void Equality_WithLabel(string enumLabel)
    => _checks.Equality(() => CreateEnumValue(enumLabel));

  [Theory, RepeatData]
  public void Equality_WithTypeAndLabel(string enumType, string enumLabel)
    => _checks.Equality(() => CreateEnumValue(enumType, enumLabel));

  [Theory, RepeatData]
  public void Inequality_WithDifferentLabels(string enumLabel1, string enumLabel2)
  {
    if (enumLabel1 == enumLabel2) {
      return;
    }

    EnumValueAst left = CreateEnumValue(enumLabel1);
    EnumValueAst right = CreateEnumValue(enumLabel2);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Inequality_WithDifferentTypes(string enumType1, string enumType2, string enumLabel)
  {
    if (enumType1 == enumType2) {
      return;
    }

    EnumValueAst left = CreateEnumValue(enumType1, enumLabel);
    EnumValueAst right = CreateEnumValue(enumType2, enumLabel);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Inequality_WithLabelVsTypeAndLabel(string enumLabel, string enumType)
  {
    EnumValueAst left = CreateEnumValue(enumLabel);
    EnumValueAst right = CreateEnumValue(enumType, enumLabel);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Compare_JustLabels(string label1, string label2)
  {
    EnumValueAst left = CreateEnumValue(label1);
    EnumValueAst right = CreateEnumValue(label2);
    int expected = label1.Compare(label2);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Compare_WithLabels(string type, string label1, string label2)
  {
    EnumValueAst left = CreateEnumValue(type, label1);
    EnumValueAst right = CreateEnumValue(type, label2);
    int expected = (type + "." + label1).Compare(type + "." + label2);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Compare_WithTypes(string type1, string type2)
  {
    EnumValueAst left = CreateEnumValue(type1, TestLabel);
    EnumValueAst right = CreateEnumValue(type2, TestLabel);
    int expected = (type1 + "." + TestLabel).Compare(type2 + "." + TestLabel);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void EnumValue_WithLabel_ReturnsLabel(string enumLabel)
  {
    EnumValueAst enumValue = CreateEnumValue(enumLabel);

    enumValue.EnumValue.ShouldBe(enumLabel);
  }

  [Theory, RepeatData]
  public void EnumValue_WithTypeAndLabel_ReturnsTypeAndLabel(string enumType, string enumLabel)
  {
    EnumValueAst enumValue = CreateEnumValue(enumType, enumLabel);

    enumValue.EnumValue.ShouldBe($"{enumType}.{enumLabel}");
  }

  [Theory, RepeatData]
  public void EnumType_WithLabel_ReturnsNull(string enumLabel)
  {
    EnumValueAst enumValue = CreateEnumValue(enumLabel);

    ((IGqlpEnumValue)enumValue).EnumType.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void EnumType_WithTypeAndLabel_ReturnsType(string enumType, string enumLabel)
  {
    EnumValueAst enumValue = CreateEnumValue(enumType, enumLabel);

    ((IGqlpEnumValue)enumValue).EnumType.ShouldBe(enumType);
  }

  [Theory, RepeatData]
  public void EnumLabel_WithLabel_ReturnsLabel(string enumLabel)
  {
    EnumValueAst enumValue = CreateEnumValue(enumLabel);

    ((IGqlpEnumValue)enumValue).EnumLabel.ShouldBe(enumLabel);
  }

  [Theory, RepeatData]
  public void EnumLabel_WithTypeAndLabel_ReturnsLabel(string enumType, string enumLabel)
  {
    EnumValueAst enumValue = CreateEnumValue(enumType, enumLabel);

    ((IGqlpEnumValue)enumValue).EnumLabel.ShouldBe(enumLabel);
  }

  [Theory, RepeatData]
  public void Equals_IGqlpEnumValue_WithSameValues_ReturnsTrue(string enumType, string enumLabel)
  {
    EnumValueAst enumValue1 = CreateEnumValue(enumType, enumLabel);
    EnumValueAst enumValue2 = CreateEnumValue(enumType, enumLabel);

    enumValue1.Equals((IGqlpEnumValue)enumValue2).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_IGqlpEnumValue_WithDifferentValues_ReturnsFalse(string enumType1, string enumType2, string enumLabel)
  {
    if (enumType1 == enumType2) {
      return;
    }

    EnumValueAst enumValue1 = CreateEnumValue(enumType1, enumLabel);
    EnumValueAst enumValue2 = CreateEnumValue(enumType2, enumLabel);

    enumValue1.Equals((IGqlpEnumValue)enumValue2).ShouldBeFalse();
  }

  internal AstAbbreviatedChecks<string, EnumValueAst> _checks
    = new(CreateEnumValue);

  [CheckTests]
  internal IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, EnumValueAst>(
      CreateEnumValue,
      (original, input) => original with { Label = input });

  private static EnumValueAst CreateEnumValue(string enumLabel)
    => new(AstNulls.At, enumLabel);

  private static EnumValueAst CreateEnumValue(string enumType, string enumLabel)
    => new(AstNulls.At, enumType, enumLabel);
}
