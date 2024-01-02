namespace GqlPlus.Verifier.Ast;

public class FieldKeyAstTests
{
  [Fact]
  public void HashCode_WithNull()
    => _checks.HashCode(() => new FieldKeyAst(AstNulls.At));

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
  public void HashCode_WithEnumValue(string enumValue)
    => _checks.HashCode(enumValue.FieldKey);

  [Theory, RepeatData(Repeats)]
  public void String_WithNumber(decimal number)
    => _checks.String(
      () => FieldKey(number),
      $"( !k {number} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithString(string contents)
    => _checks.String(
      () => FieldKey(contents),
      $"( !k '{contents}' )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.String(() => FieldKey(enumType, enumValue),
      $"( !k {enumType}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(string enumValue)
    => _checks.String(
      enumValue.FieldKey,
      $"( !k {enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithNumber(decimal number)
    => _checks.Equality(
      () => FieldKey(number));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithNumber(decimal number1, decimal number2)
  {
    var left = FieldKey(number1);
    var right = FieldKey(number2);

    left.CompareTo(right).Should().Be(number1.CompareTo(number2));
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberString(decimal number, string contents)
  {
    var left = FieldKey(number);
    var right = FieldKey(contents);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberEnumValue(decimal number, string enumType, string enumValue)
  {
    var left = FieldKey(number);
    var right = FieldKey(enumType, enumValue);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithString(string contents)
    => _checks.Equality(
      () => FieldKey(contents));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithString(string contents1, string contents2)
  {
    var left = FieldKey(contents1);
    var right = FieldKey(contents2);
    var expected = string.Compare(contents1, contents2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithStringEnumValue(string contents, string enumType, string enumValue)
  {
    var left = FieldKey(contents);
    var right = FieldKey(enumType, enumValue);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Equality(
      () => FieldKey(enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumTypeAndValue(string enumType, string enumValue1, string enumValue2)
  {
    var left = FieldKey(enumType, enumValue1);
    var right = FieldKey(enumType, enumValue2);
    var expected = string.Compare(enumType + "." + enumValue1, enumType + "." + enumValue2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumTypeAndValue(string enumType, string enumValue)
  {
    if (enumType == enumValue) {
      return;
    }

    var left = FieldKey(enumType, enumValue);
    var right = FieldKey(enumValue, enumType);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(string enumValue)
    => _checks.Equality(
      enumValue.FieldKey);

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumValue(string enumValue1, string enumValue2)
  {
    var left = enumValue1.FieldKey();
    var right = enumValue2.FieldKey();
    var expected = string.Compare(enumValue1, enumValue2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumValue(string enumValue)
  {
    var left = enumValue.FieldKey();
    var right = FieldKey(enumValue, enumValue);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumType(string enumType)
    => _checks.Equality(
      () => FieldKey(enumType, "enumValue"));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumType(string enumType1, string enumType2)
  {
    var left = FieldKey(enumType1, "enumValue");
    var right = FieldKey(enumType2, "enumValue");
    var expected = string.Compare(enumType1 + ".enumValue", enumType2 + ".enumValue", StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumType(string enumType)
  {
    var left = FieldKey(enumType, "enumValue");
    var right = FieldKey(enumType, enumType + "enumValue");

    (left != right).Should().BeTrue();
  }

  internal BaseAstChecks<FieldKeyAst> _checks = new();

  private static FieldKeyAst FieldKey(string enumType, string enumValue)
    => new(AstNulls.At, enumType, enumValue);

  private static FieldKeyAst FieldKey(decimal number)
    => new(AstNulls.At, number);

  private static FieldKeyAst FieldKey(string contents)
    => new(AstNulls.At, contents);
}
