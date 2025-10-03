namespace GqlPlus.Ast;

public class EnumValueAstTests : AstAbbreviatedTests
{
  [Theory, RepeatData]
  public void HashCode_WithLabel(string enumLabel)
    => _checks.HashCode(() => EnumValue(enumLabel));

  [Theory, RepeatData]
  public void HashCode_WithTypeAndLabel(string enumType, string enumLabel)
    => _checks.HashCode(() => EnumValue(enumType, enumLabel));

  [Theory, RepeatData]
  public void String_WithLabel(string enumLabel)
    => _checks.Text(
      () => EnumValue(enumLabel),
      $"( !e {enumLabel} )");

  [Theory, RepeatData]
  public void String_WithTypeAndLabel(string enumType, string enumLabel)
    => _checks.Text(
      () => EnumValue(enumType, enumLabel),
      $"( !e {enumType}.{enumLabel} )");

  [Theory, RepeatData]
  public void Equality_WithLabel(string enumLabel)
    => _checks.Equality(() => EnumValue(enumLabel));

  [Theory, RepeatData]
  public void Equality_WithTypeAndLabel(string enumType, string enumLabel)
    => _checks.Equality(() => EnumValue(enumType, enumLabel));

  [Theory, RepeatData]
  public void Inequality_WithDifferentLabels(string enumLabel1, string enumLabel2)
  {
    if (enumLabel1 == enumLabel2) {
      return;
    }

    EnumValueAst left = EnumValue(enumLabel1);
    EnumValueAst right = EnumValue(enumLabel2);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Inequality_WithDifferentTypes(string enumType1, string enumType2, string enumLabel)
  {
    if (enumType1 == enumType2) {
      return;
    }

    EnumValueAst left = EnumValue(enumType1, enumLabel);
    EnumValueAst right = EnumValue(enumType2, enumLabel);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Inequality_WithLabelVsTypeAndLabel(string enumLabel, string enumType)
  {
    EnumValueAst left = EnumValue(enumLabel);
    EnumValueAst right = EnumValue(enumType, enumLabel);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Compare_JustLabels(string label1, string label2)
  {
    EnumValueAst left = EnumValue(label1);
    EnumValueAst right = EnumValue(label2);
    int expected = string.Compare(label1, label2, StringComparison.Ordinal);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Compare_WithLabels(string type, string label1, string label2)
  {
    EnumValueAst left = EnumValue(type, label1);
    EnumValueAst right = EnumValue(type, label2);
    int expected = string.Compare(type + "." + label1, type + "." + label2, StringComparison.Ordinal);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Compare_WithTypes(string label, string type1, string type2)
  {
    EnumValueAst left = EnumValue(type1, label);
    EnumValueAst right = EnumValue(type2, label);
    int expected = string.Compare(type1, type2, StringComparison.Ordinal);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void EnumValue_WithLabel_ReturnsLabel(string enumLabel)
  {
    EnumValueAst enumValue = EnumValue(enumLabel);

    enumValue.EnumValue.ShouldBe(enumLabel);
  }

  [Theory, RepeatData]
  public void EnumValue_WithTypeAndLabel_ReturnsTypeAndLabel(string enumType, string enumLabel)
  {
    EnumValueAst enumValue = EnumValue(enumType, enumLabel);

    enumValue.EnumValue.ShouldBe($"{enumType}.{enumLabel}");
  }

  [Theory, RepeatData]
  public void EnumType_WithLabel_ReturnsNull(string enumLabel)
  {
    EnumValueAst enumValue = EnumValue(enumLabel);

    ((IGqlpEnumValue)enumValue).EnumType.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void EnumType_WithTypeAndLabel_ReturnsType(string enumType, string enumLabel)
  {
    EnumValueAst enumValue = EnumValue(enumType, enumLabel);

    ((IGqlpEnumValue)enumValue).EnumType.ShouldBe(enumType);
  }

  [Theory, RepeatData]
  public void EnumLabel_WithLabel_ReturnsLabel(string enumLabel)
  {
    EnumValueAst enumValue = EnumValue(enumLabel);

    ((IGqlpEnumValue)enumValue).EnumLabel.ShouldBe(enumLabel);
  }

  [Theory, RepeatData]
  public void EnumLabel_WithTypeAndLabel_ReturnsLabel(string enumType, string enumLabel)
  {
    EnumValueAst enumValue = EnumValue(enumType, enumLabel);

    ((IGqlpEnumValue)enumValue).EnumLabel.ShouldBe(enumLabel);
  }

  [Theory, RepeatData]
  public void Equals_IGqlpEnumValue_WithSameValues_ReturnsTrue(string enumType, string enumLabel)
  {
    EnumValueAst enumValue1 = EnumValue(enumType, enumLabel);
    EnumValueAst enumValue2 = EnumValue(enumType, enumLabel);

    enumValue1.Equals((IGqlpEnumValue)enumValue2).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_IGqlpEnumValue_WithDifferentValues_ReturnsFalse(string enumType1, string enumType2, string enumLabel)
  {
    if (enumType1 == enumType2) {
      return;
    }

    EnumValueAst enumValue1 = EnumValue(enumType1, enumLabel);
    EnumValueAst enumValue2 = EnumValue(enumType2, enumLabel);

    enumValue1.Equals((IGqlpEnumValue)enumValue2).ShouldBeFalse();
  }

  internal AstAbbreviatedChecks<string, IGqlpEnumValue> _checks = new(value => new EnumValueAst(AstNulls.At, value));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;

  private static EnumValueAst EnumValue(string enumLabel)
    => new(AstNulls.At, enumLabel);

  private static EnumValueAst EnumValue(string enumType, string enumLabel)
    => new(AstNulls.At, enumType, enumLabel);
}
