namespace GqlPlus.Verifier.Ast;

public class ConstantAstTests
{
  [Fact]
  public void HashCode_WithNull()
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithLabel(string label)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, "", label)));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumLabel(string enumType, string label)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, label)));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumType(string enumType)
    => _checks.HashCode(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, "label")));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithValues(string label)
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At, label.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string key, string label)
    => _checks.HashCode(
      () => new ConstantAst(AstNulls.At, label.ConstantObject(key)));

  [Theory, RepeatData(Repeats)]
  public void String_WithLabel(string label)
    => _checks.String(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, "", label)),
      $"( !K {label} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumLabel(string enumType, string label)
    => _checks.String(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, label)),
      $"( !K {enumType}.{label} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumType(string enumType)
    => _checks.String(
      () => new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, "label")),
      $"( !K {enumType}.label )");

  [Theory, RepeatData(Repeats)]
  public void String_WithValues(string label)
    => _checks.String(
      () => new ConstantAst(AstNulls.At, label.ConstantList()),
      $"( !C [ !K {label} !K {label} ] )");

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string key, string label)
    => _checks.String(
      () => new ConstantAst(AstNulls.At, label.ConstantObject(key)),
      $"( !C {{ ( !K {key} ):( !K {label} ) ( !K {label} ):( !K {key} ) }} )",
      key == label);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithLabel(string label)
    => _checks.Equality(
      () => new FieldKeyAst(AstNulls.At, "", label));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumLabel(string enumType, string label)
    => _checks.Equality(
      () => new FieldKeyAst(AstNulls.At, enumType, label));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumType(string enumType)
    => _checks.Equality(
      () => new FieldKeyAst(AstNulls.At, enumType, "label"));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithLabel(string label)
    => _checks.InequalityBetween(label, label + "a",
      l => new FieldKeyAst(AstNulls.At, "", l));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumLabel(string enumType, string label)
    => _checks.Inequality(
      () => new FieldKeyAst(AstNulls.At, enumType, label),
      () => new FieldKeyAst(AstNulls.At, label, enumType),
      enumType == label);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithEnumType(string enumType)
    => _checks.InequalityBetween(enumType, enumType + "a",
      e => new FieldKeyAst(AstNulls.At, e, "label"));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithValues(string label)
    => _checks.Equality(
      () => new ConstantAst(AstNulls.At, label.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithValues(string label)
    => _checks.Inequality(
      () => new ConstantAst(AstNulls.At, label.ConstantList()),
      () => new FieldKeyAst(AstNulls.At, "", label));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string key, string label)
    => _checks.Equality(
      () => new ConstantAst(AstNulls.At, label.ConstantObject(key)));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithFields(string key, string label)
    => _checks.Inequality(
      () => new ConstantAst(AstNulls.At, label.ConstantObject(key)),
      () => new FieldKeyAst(AstNulls.At, key, label));

  internal BaseAstChecks<ConstantAst> _checks = new();
}
