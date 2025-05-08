namespace GqlPlus.Ast;

public class ConstantAstTests
{
  [Fact]
  public void HashCode_WithNull()
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At) with { At = AstNulls.At });

  [Theory, RepeatData]
  public void HashCode_WithEnumValue(string enumValue)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, "", enumValue)));

  [Theory, RepeatData]
  public void HashCode_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData]
  public void HashCode_WithEnumType(string enumType)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, "enumValue")));

  [Theory, RepeatData]
  public void HashCode_WithValues(string enumValue)
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData]
  public void HashCode_WithFields(string key, string enumValue)
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)));

  [Theory, RepeatData]
  public void String_WithEnumValue(string enumValue)
    => _checks.Text(
      () => new ConstantAst(enumValue.FieldKey()),
      $"( !k {enumValue} )");

  [Theory, RepeatData]
  public void String_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Text(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)),
      $"( !k {enumType}.{enumValue} )");

  [Theory, RepeatData]
  public void String_WithEnumType(string enumType)
    => _checks.Text(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, "enumValue")),
      $"( !k {enumType}.enumValue )");

  [Theory, RepeatData]
  public void String_WithValues(string enumValue)
    => _checks.Text(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantList()),
      $"( !c [ !k {enumValue} !k {enumValue} ] )");

  [Theory, RepeatData]
  public void String_WithFields(string key, string enumValue)
    => _checks.Text(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)),
      $"( !c {{ ( !k {key} ):( !k {enumValue} ) ( !k {enumValue} ):( !k {key} ) }} )",
      key == enumValue);

  [Theory, RepeatData]
  public void Equality_WithEnumValue(string enumValue)
    => _checks.Equality(
      () => new ConstantAst(enumValue.FieldKey()));

  [Theory, RepeatData]
  public void Equality_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Equality(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData]
  public void Equality_WithEnumType(string enumType)
    => _checks.Equality(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, "enumValue")));

  [Theory, RepeatData]
  public void Inequality_WithEnumValue(string enumValue)
    => _checks.InequalityBetween(enumValue, enumValue + "a",
      l => new ConstantAst(l.FieldKey()));

  [Theory, RepeatData]
  public void Inequality_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Inequality(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)),
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumValue, enumType)),
      enumType == enumValue);

  [Theory, RepeatData]
  public void Inequality_WithEnumType(string enumType)
    => _checks.InequalityBetween(enumType, enumType + "a",
      e => new ConstantAst(new FieldKeyAst(AstNulls.At, e, "enumValue")));

  [Theory, RepeatData]
  public void Equality_WithValues(string enumValue)
    => _checks.Equality(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData]
  public void Inequality_WithValues(string enumValue)
    => _checks.Inequality(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantList()),
      () => new ConstantAst(enumValue.FieldKey()));

  [Theory, RepeatData]
  public void Equality_WithFields(string key, string enumValue)
    => _checks.Equality(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)));

  [Theory, RepeatData]
  public void Inequality_WithFields(string key, string enumValue)
    => _checks.Inequality(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)),
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, key, enumValue)));

  internal BaseAstChecks<IGqlpConstant> _checks = new();
}
