namespace GqlPlus.Verifier.Ast;

public class FieldKeyAstTests
{
  [Fact]
  public void HashCode_WithNull()
    => _checks.HashCode(() => new FieldKeyAst(AstNulls.At) with { At = AstNulls.At });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithNumber(decimal number)
    => _checks.HashCode(() => new FieldKeyAst(AstNulls.At, number));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithString(string contents)
    => _checks.HashCode(() => new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.HashCode(() => new FieldKeyAst(AstNulls.At, enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(string enumValue)
    => _checks.HashCode(enumValue.FieldKey);

  [Theory, RepeatData(Repeats)]
  public void String_WithNumber(decimal number)
    => _checks.String(
      () => new FieldKeyAst(AstNulls.At, number),
      $"( !k {number} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithString(string contents)
    => _checks.String(
      () => new FieldKeyAst(AstNulls.At, contents),
      $"( !k '{contents}' )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.String(() => new FieldKeyAst(AstNulls.At, enumType, enumValue),
      $"( !k {enumType}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(string enumValue)
    => _checks.String(
      enumValue.FieldKey,
      $"( !k {enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithNumber(decimal number)
    => _checks.Equality(
      () => new FieldKeyAst(AstNulls.At, number));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithNumber(decimal number1, decimal number2)
  {
    var left = new FieldKeyAst(AstNulls.At, number1);
    var right = new FieldKeyAst(AstNulls.At, number2);

    left.CompareTo(right).Should().Be(number1.CompareTo(number2));
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberString(decimal number, string contents)
  {
    var left = new FieldKeyAst(AstNulls.At, number);
    var right = new FieldKeyAst(AstNulls.At, contents);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithNumberEnumValue(decimal number, string enumType, string enumValue)
  {
    var left = new FieldKeyAst(AstNulls.At, number);
    var right = new FieldKeyAst(AstNulls.At, enumType, enumValue);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithString(string contents)
    => _checks.Equality(
      () => new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithString(string contents1, string contents2)
  {
    var left = new FieldKeyAst(AstNulls.At, contents1);
    var right = new FieldKeyAst(AstNulls.At, contents2);
    var expected = string.Compare(contents1, contents2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithStringEnumValue(string contents, string enumType, string enumValue)
  {
    var left = new FieldKeyAst(AstNulls.At, contents);
    var right = new FieldKeyAst(AstNulls.At, enumType, enumValue);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Equality(
      () => new FieldKeyAst(AstNulls.At, enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumTypeAndValue(string enumType, string enumValue1, string enumValue2)
  {
    var left = new FieldKeyAst(AstNulls.At, enumType, enumValue1);
    var right = new FieldKeyAst(AstNulls.At, enumType, enumValue2);
    var expected = string.Compare(enumType + "." + enumValue1, enumType + "." + enumValue2, StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumTypeAndValue(string enumType, string enumValue)
  {
    if (enumType == enumValue) {
      return;
    }

    var left = new FieldKeyAst(AstNulls.At, enumType, enumValue);
    var right = new FieldKeyAst(AstNulls.At, enumValue, enumType);

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
    var right = new FieldKeyAst(AstNulls.At, enumValue, enumValue);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumType(string enumType)
    => _checks.Equality(
      () => new FieldKeyAst(AstNulls.At, enumType, "enumValue"));

  [Theory, RepeatData(Repeats)]
  public void Compare_WithEnumType(string enumType1, string enumType2)
  {
    var left = new FieldKeyAst(AstNulls.At, enumType1, "enumValue");
    var right = new FieldKeyAst(AstNulls.At, enumType2, "enumValue");
    var expected = string.Compare(enumType1 + ".enumValue", enumType2 + ".enumValue", StringComparison.Ordinal);

    left.CompareTo(right).Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumType(string enumType)
  {
    var left = new FieldKeyAst(AstNulls.At, enumType, "enumValue");
    var right = new FieldKeyAst(AstNulls.At, enumType, enumType + "enumValue");

    (left != right).Should().BeTrue();
  }

  internal BaseAstChecks<string, FieldKeyAst> _checks = new();
}
