namespace GqlPlus.Ast;

public class FieldKeyAstTests : AstAbbreviatedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithNumber(decimal number)
    => _checks.HashCode(() => FieldKey(number));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithString(string contents)
    => _checks.HashCode(() => FieldKey(contents));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.HashCode(() => FieldKey(enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void String_WithNumber(decimal number)
    => _checks.Text(
      () => FieldKey(number),
      $"( !k {number} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithString(string contents)
    => _checks.Text(
      () => FieldKey(contents),
      $"( !k '{contents}' )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Text(() => FieldKey(enumType, enumValue),
      $"( !k {enumType}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithNumber(decimal number)
    => _checks.Equality(
      () => FieldKey(number));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithNumber(decimal number1, decimal number2)
  {
    FieldKeyAst left = FieldKey(number1);
    FieldKeyAst right = FieldKey(number2);

    left.CompareTo(right).Should().Be(number1.CompareTo(number2));
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberString(decimal number, string contents)
  {
    FieldKeyAst left = FieldKey(number);
    FieldKeyAst right = FieldKey(contents);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberEnumValue(decimal number, string enumType, string enumValue)
  {
    FieldKeyAst left = FieldKey(number);
    FieldKeyAst right = FieldKey(enumType, enumValue);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithString(string contents)
    => _checks.Equality(
      () => FieldKey(contents));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithString(string contents1, string contents2)
  {
    FieldKeyAst left = FieldKey(contents1);
    FieldKeyAst right = FieldKey(contents2);
    int expected = string.Compare(contents1, contents2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithStringEnumValue(string contents, string enumType, string enumValue)
  {
    FieldKeyAst left = FieldKey(contents);
    FieldKeyAst right = FieldKey(enumType, enumValue);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Equality(
      () => FieldKey(enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumTypeAndValue(string enumType, string enumValue1, string enumValue2)
  {
    FieldKeyAst left = FieldKey(enumType, enumValue1);
    FieldKeyAst right = FieldKey(enumType, enumValue2);
    int expected = string.Compare(enumType + "." + enumValue1, enumType + "." + enumValue2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumTypeAndValue(string enumType, string enumValue)
  {
    if (enumType == enumValue) {
      return;
    }

    FieldKeyAst left = FieldKey(enumType, enumValue);
    FieldKeyAst right = FieldKey(enumValue, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(string enumValue)
    => _checks.Equality(enumValue.FieldKey);

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumValue(string enumValue1, string enumValue2)
  {
    IGqlpFieldKey left = enumValue1.FieldKey();
    IGqlpFieldKey right = enumValue2.FieldKey();
    int expected = string.Compare(enumValue1, enumValue2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumValue(string enumValue)
  {
    IGqlpFieldKey left = enumValue.FieldKey();
    IGqlpFieldKey right = FieldKey(enumValue, enumValue);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumType(string enumType)
    => _checks.Equality(
      () => FieldKey(enumType, "enumValue"));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumType(string enumType1, string enumType2)
  {
    FieldKeyAst left = FieldKey(enumType1, "enumValue");
    FieldKeyAst right = FieldKey(enumType2, "enumValue");
    int expected = string.Compare(enumType1 + ".enumValue", enumType2 + ".enumValue", StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumType(string enumType)
  {
    FieldKeyAst left = FieldKey(enumType, "enumValue");
    FieldKeyAst right = FieldKey(enumType, enumType + "enumValue");

    (left != right).Should().BeTrue();
  }

  internal AstAbbreviatedChecks<string, IGqlpFieldKey> _checks = new(value => value.FieldKey());

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;

  private static FieldKeyAst FieldKey(string enumType, string enumValue)
    => new(AstNulls.At, enumType, enumValue);

  private static FieldKeyAst FieldKey(decimal number)
    => new(AstNulls.At, number);

  private static FieldKeyAst FieldKey(string contents)
    => new(AstNulls.At, contents);
}
