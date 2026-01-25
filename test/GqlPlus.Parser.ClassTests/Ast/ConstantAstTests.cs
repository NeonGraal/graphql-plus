using System.Collections.Immutable;

namespace GqlPlus.Ast;

public class ConstantAstTests
{
  [Fact]
  public void HashCode_WithNull()
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At) with { At = AstNulls.At });

  [Theory, RepeatData]
  public void HashCode_WithValue(string value)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, string.Empty, value)));

  [Theory, RepeatData]
  public void HashCode_WithEnumTypeAndValue(string enumType, string value)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, value)));

  [Theory, RepeatData]
  public void HashCode_WithEnumType(string enumType, string value)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, value)));

  [Theory, RepeatData]
  public void HashCode_WithValues(string value)
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At, value.ConstantList()));

  [Theory, RepeatData]
  public void HashCode_WithFields(string key, string value)
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At, value.ConstantObject(key)));

  [Theory, RepeatData]
  public void Text_WithValue(string value)
    => _checks.Text(
      () => new ConstantAst(value.FieldKey()),
      $"( !k {value} )");

  [Theory, RepeatData]
  public void Text_WithEnumTypeAndValue(string enumType, string value)
    => _checks.Text(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, value)),
      $"( !k {enumType}.{value} )");

  [Theory, RepeatData]
  public void Text_WithEnumType(string enumType, string value)
    => _checks.Text(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, value)),
      $"( !k {enumType}.{value} )");

  [Theory, RepeatData]
  public void Text_WithValues(string value)
    => _checks.Text(
      () => new ConstantAst(AstNulls.At, value.ConstantList()),
      $"( !c [ !k {value} !k {value} ] )");

  [Theory, RepeatData]
  public void Text_WithFields(string key, string value)
    => _checks.Text(
      () => new ConstantAst(AstNulls.At, value.ConstantObject(key)),
      $"( !c {{ ( !k {key} ):( !k {value} ) ( !k {value} ):( !k {key} ) }} )",
      key == value);

  [Theory, RepeatData]
  public void Equality_WithValue(string value)
    => _checks.Equality(
      () => new ConstantAst(value.FieldKey()));

  [Theory, RepeatData]
  public void Equality_WithEnumTypeAndValue(string enumType, string value)
    => _checks.Equality(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, value)));

  [Theory, RepeatData]
  public void Equality_WithEnumType(string enumType, string value)
    => _checks.Equality(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, value)));

  [Theory, RepeatData]
  public void Inequality_WithValue(string value)
    => _checks.InequalityBetween(value, value + "a",
      l => new ConstantAst(l.FieldKey()));

  [Theory, RepeatData]
  public void Inequality_WithEnumTypeAndValue(string enumType, string value)
    => _checks.Inequality(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, value)),
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, value, enumType)),
      enumType == value);

  [Theory, RepeatData]
  public void Inequality_WithEnumType(string enumType, string value)
    => _checks.InequalityBetween(enumType, enumType + "a",
      e => new ConstantAst(new FieldKeyAst(AstNulls.At, e, value)));

  [Theory, RepeatData]
  public void Equality_WithValues(string value)
    => _checks.Equality(
      () => new ConstantAst(AstNulls.At, value.ConstantList()));

  [Theory, RepeatData]
  public void Inequality_WithValues(string value)
    => _checks.Inequality(
      () => new ConstantAst(AstNulls.At, value.ConstantList()),
      () => new ConstantAst(value.FieldKey()));

  [Theory, RepeatData]
  public void Equality_WithFields(string key, string value)
    => _checks.Equality(
      () => new ConstantAst(AstNulls.At, value.ConstantObject(key)));

  [Theory, RepeatData]
  public void Inequality_WithFields(string key, string value)
    => _checks.Inequality(
      () => new ConstantAst(AstNulls.At, value.ConstantObject(key)),
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, key, value)));

  [Theory, RepeatData]
  public void Contains_WithFields(string key, string value)
  {
    ConstantAst constant = new(AstNulls.At, value.ConstantObject(key));
    IGqlpFields<IGqlpConstant> fields = constant.Fields;

    bool result = fields.Contains(key.FieldKey(), new ConstantAst(value.FieldKey()));

    result.ShouldBeTrue();
  }

  internal BaseAstChecks<IGqlpConstant> _checks = new();
}
