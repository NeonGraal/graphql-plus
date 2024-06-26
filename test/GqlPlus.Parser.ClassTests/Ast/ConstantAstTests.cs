namespace GqlPlus.Ast;

public class ConstantAstTests
{
  [Fact]
  public void HashCode_WithNull()
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At) with { At = AstNulls.At });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(string enumValue)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, "", enumValue)));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumType(string enumType)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, "enumValue")));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithValues(string enumValue)
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string key, string enumValue)
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)));

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(string enumValue)
    => _checks.Text(
      () => new ConstantAst(enumValue.FieldKey()),
      $"( !k {enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Text(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)),
      $"( !k {enumType}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumType(string enumType)
    => _checks.Text(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, "enumValue")),
      $"( !k {enumType}.enumValue )");

  [Theory, RepeatData(Repeats)]
  public void String_WithValues(string enumValue)
    => _checks.Text(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantList()),
      $"( !c [ !k {enumValue} !k {enumValue} ] )");

  [SkippableTheory, RepeatData(Repeats)]
  public void String_WithFields(string key, string enumValue)
    => _checks.Text(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)),
      $"( !c {{ ( !k {key} ):( !k {enumValue} ) ( !k {enumValue} ):( !k {key} ) }} )",
      key == enumValue);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(string enumValue)
    => _checks.Equality(
      () => new(enumValue.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Equality(
      () => new(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumType(string enumType)
    => _checks.Equality(
      () => new(new FieldKeyAst(AstNulls.At, enumType, "enumValue")));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumValue(string enumValue)
    => _checks.InequalityBetween(enumValue, enumValue + "a",
      l => new(l.FieldKey()));

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_WithEnumTypeAndValue(string enumType, string enumValue)
    => _checks.Inequality(
      () => new(new FieldKeyAst(AstNulls.At, enumType, enumValue)),
      () => new(new FieldKeyAst(AstNulls.At, enumValue, enumType)),
      enumType == enumValue);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumType(string enumType)
    => _checks.InequalityBetween(enumType, enumType + "a",
      e => new(new FieldKeyAst(AstNulls.At, e, "enumValue")));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithValues(string enumValue)
    => _checks.Equality(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithValues(string enumValue)
    => _checks.Inequality(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantList()),
      () => new(enumValue.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string key, string enumValue)
    => _checks.Equality(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithFields(string key, string enumValue)
    => _checks.Inequality(
      () => new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)),
      () => new(new FieldKeyAst(AstNulls.At, key, enumValue)));

  internal BaseAstChecks<ConstantAst> _checks = new();
}
