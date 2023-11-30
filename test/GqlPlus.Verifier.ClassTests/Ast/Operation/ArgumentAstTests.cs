namespace GqlPlus.Verifier.Ast.Operation;

public class ArgumentAstTests
{
  [Fact]
  public void HashCode_WithNull()
    => _checks.HashCode(
      () => new ArgumentAst(AstNulls.At) with { At = AstNulls.At });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithVariable(string variable)
    => _checks.HashCode(
      () => new ArgumentAst(AstNulls.At, variable));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithConstant(string enumType, string label)
    => _checks.HashCode(
      () => new FieldKeyAst(AstNulls.At, enumType, label));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithValues(string label)
    => _checks.HashCode(
      () => new ArgumentAst(AstNulls.At, label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string key, string label)
    => _checks.HashCode(
      () => new ArgumentAst(AstNulls.At, label.ArgumentObject(key)));

  [Theory, RepeatData(Repeats)]
  public void String_WithVariable(string variable)
    => _checks.String(
      () => new ArgumentAst(AstNulls.At, variable),
      $"( !a ${variable} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithConstant(string label)
    => _checks.String(
      () => new ConstantAst(label.FieldKey()),
      $"( !k {label} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithValues(string label)
    => _checks.String(
      () => new ArgumentAst(AstNulls.At, label.ArgumentList()),
      $"( !a [ !a ${label} !k {label} ] )");

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string key, string label)
    => _checks.String(
      () => new ArgumentAst(AstNulls.At, label.ArgumentObject(key)),
      $"( !a {{ ( !k {key} ):( !a ${label} ) ( !k {label} ):( !k {key} ) }} )",
      key == label);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithVariable(string variable)
    => _checks.Equality(
      () => new ArgumentAst(AstNulls.At, variable));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithVariable(string variable)
    => _checks.InequalityBetween(variable, variable + "a",
      v => new ArgumentAst(AstNulls.At, v), false);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithConstant(string enumType, string label)
    => _checks.Equality(
      () => new FieldKeyAst(AstNulls.At, enumType, label));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithConstant(string enumType, string label)
    => _checks.Inequality(
      () => new FieldKeyAst(AstNulls.At, enumType, label),
      () => new FieldKeyAst(AstNulls.At, label, enumType),
      enumType == label);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithValues(string label)
    => _checks.Equality(
      () => new ArgumentAst(AstNulls.At, label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithValues(string label)
    => _checks.Inequality(
      () => new ArgumentAst(AstNulls.At, label.ArgumentList()),
      () => new ArgumentAst(AstNulls.At, label));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string key, string label)
    => _checks.Equality(
      () => new ArgumentAst(AstNulls.At, label.ArgumentObject(key)));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithFields(string key, string label)
    => _checks.Inequality(
      () => new ArgumentAst(AstNulls.At, label.ArgumentObject(key)),
      () => new ArgumentAst(AstNulls.At, label));

  internal BaseAstChecks<string, ArgumentAst> _checks = new();
}
