namespace GqlPlus.Ast;

public class FieldKeyAstTests
  : AstAbbreviatedBaseTests
{
  [Theory, RepeatData]
  public void HashCode_WithNumber(decimal number)
    => _checks.HashCode(() => CreateFieldKey(number));

  [Theory, RepeatData]
  public void HashCode_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.HashCode(() => CreateFieldKey(enumType, enumValue));

  [Theory, RepeatData]
  public void Text_WithNumber(decimal number)
    => _checks.Text(
      () => CreateFieldKey(number),
      $"( !k {number} )");

  [Theory, RepeatData]
  public void Text_WithString(string contents)
    => _checks.Text(
      () => CreateFieldKey(contents),
      $"( !k '{contents}' )");

  [Theory, RepeatData]
  public void Text_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Text(() => CreateFieldKey(enumType, enumValue),
      $"( !k {enumType}.{enumValue} )");

  [Theory, RepeatData]
  public void Equality_WithNumber(decimal number)
    => _checks.Equality(
      () => CreateFieldKey(number));

  [Theory, RepeatData]
  public void Compare_WithNumber(decimal number1, decimal number2)
  {
    FieldKeyAst left = CreateFieldKey(number1);
    FieldKeyAst right = CreateFieldKey(number2);

    left.CompareTo(right).ShouldBe(number1.CompareTo(number2));
  }

  [Theory, RepeatData]
  public void Inequality_WithNumberString(decimal number, string contents)
  {
    FieldKeyAst left = CreateFieldKey(number);
    FieldKeyAst right = CreateFieldKey(contents);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Inequality_WithNumberEnumValue(decimal number, string enumType, string enumValue)
  {
    FieldKeyAst left = CreateFieldKey(number);
    FieldKeyAst right = CreateFieldKey(enumType, enumValue);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Compare_WithString(string contents1, string contents2)
  {
    FieldKeyAst left = CreateFieldKey(contents1);
    FieldKeyAst right = CreateFieldKey(contents2);
    int expected = string.Compare(contents1, contents2, StringComparison.Ordinal);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Inequality_WithStringEnumValue(string contents, string enumType, string enumValue)
  {
    FieldKeyAst left = CreateFieldKey(contents);
    FieldKeyAst right = CreateFieldKey(enumType, enumValue);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equality_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Equality(
      () => CreateFieldKey(enumType, enumValue));

  [Theory, RepeatData]
  public void Compare_WithEnumTypeAndValue(string enumType, string enumValue1, string enumValue2)
  {
    FieldKeyAst left = CreateFieldKey(enumType, enumValue1);
    FieldKeyAst right = CreateFieldKey(enumType, enumValue2);
    int expected = string.Compare(enumType + "." + enumValue1, enumType + "." + enumValue2, StringComparison.Ordinal);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Inequality_WithEnumTypeAndValue(string enumType, string enumValue)
  {
    if (enumType == enumValue) {
      return;
    }

    FieldKeyAst left = CreateFieldKey(enumType, enumValue);
    FieldKeyAst right = CreateFieldKey(enumValue, enumType);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equality_WithEnumValue(string enumValue)
    => _checks.Equality(enumValue.FieldKey);

  [Theory, RepeatData]
  public void Compare_WithEnumValue(string enumValue1, string enumValue2)
  {
    IGqlpFieldKey left = enumValue1.FieldKey();
    IGqlpFieldKey right = enumValue2.FieldKey();
    int expected = string.Compare(enumValue1, enumValue2, StringComparison.Ordinal);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Inequality_WithEnumValue(string enumValue)
  {
    IGqlpFieldKey left = enumValue.FieldKey();
    IGqlpFieldKey right = CreateFieldKey(enumValue, enumValue);

    (left != right).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equality_WithEnumType(string enumType)
    => _checks.Equality(
      () => CreateFieldKey(enumType, "enumValue"));

  [Theory, RepeatData]
  public void Compare_WithEnumType(string enumType1, string enumType2)
  {
    FieldKeyAst left = CreateFieldKey(enumType1, "enumValue");
    FieldKeyAst right = CreateFieldKey(enumType2, "enumValue");
    int expected = string.Compare(enumType1 + ".enumValue", enumType2 + ".enumValue", StringComparison.Ordinal);

    left.CompareTo(right).ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Inequality_WithEnumType(string enumType)
  {
    FieldKeyAst left = CreateFieldKey(enumType, "enumValue");
    FieldKeyAst right = CreateFieldKey(enumType, enumType + "enumValue");

    (left != right).ShouldBeTrue();
  }

  internal FieldKeyAstChecks _checks = new(CreateFieldKey);

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;

  private static FieldKeyAst CreateFieldKey(string enumType, string enumValue)
    => new(AstNulls.At, enumType, enumValue);

  private static FieldKeyAst CreateFieldKey(decimal number)
    => new(AstNulls.At, number);

  private static FieldKeyAst CreateFieldKey(string contents)
    => new(AstNulls.At, contents);
}

internal sealed class FieldKeyAstChecks(
  BaseAstChecks<IGqlpFieldKey>.CreateBy<string> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstAbbreviatedChecks<string, IGqlpFieldKey>(createInput, createExpression)
{
  protected override string AbbreviatedString(string input)
    => $"( !k '{input}' )";

  private static IGqlpFieldKey CloneFieldKey(IGqlpFieldKey original, string input)
    => (FieldKeyAst)original with { Text = input };
}
