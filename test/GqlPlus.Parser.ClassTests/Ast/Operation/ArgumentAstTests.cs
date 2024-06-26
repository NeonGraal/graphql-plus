namespace GqlPlus.Ast.Operation;

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
  public void HashCode_WithConstant(string enumType, string enumValue)
    => _checks.HashCode(
      () => new(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithValues(string enumValue)
    => _checks.HashCode(
      () => new ArgumentAst(AstNulls.At, enumValue.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string key, string enumValue)
    => _checks.HashCode(
      () => new ArgumentAst(AstNulls.At, enumValue.ArgumentObject(key)));

  [Theory, RepeatData(Repeats)]
  public void String_WithVariable(string variable)
    => _checks.Text(
      () => new ArgumentAst(AstNulls.At, variable),
      $"( !a ${variable} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithConstant(string enumValue)
    => _checks.Text(
      () => new(new ConstantAst(enumValue.FieldKey())),
      $"( !k {enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithValues(string enumValue)
    => _checks.Text(
      () => new ArgumentAst(AstNulls.At, enumValue.ArgumentList()),
      $"( !a [ !a ${enumValue} !k {enumValue} ] )");

  [SkippableTheory, RepeatData(Repeats)]
  public void String_WithFields(string key, string enumValue)
    => _checks.Text(
      () => new ArgumentAst(AstNulls.At, enumValue.ArgumentObject(key)),
      $"( !a {{ ( !k {key} ):( !a ${enumValue} ) ( !k {enumValue} ):( !k {key} ) }} )",
      key == enumValue);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithVariable(string variable)
    => _checks.Equality(
      () => new ArgumentAst(AstNulls.At, variable));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithVariable(string variable)
    => _checks.InequalityBetween(variable, variable + "a",
      v => new ArgumentAst(AstNulls.At, v));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithConstant(string enumType, string enumValue)
    => _checks.Equality(
      () => new(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_WithConstant(string enumType, string enumValue)
    => _checks.Inequality(
      () => new(new FieldKeyAst(AstNulls.At, enumType, enumValue)),
      () => new(new FieldKeyAst(AstNulls.At, enumValue, enumType)),
      enumType == enumValue);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithValues(string enumValue)
    => _checks.Equality(
      () => new ArgumentAst(AstNulls.At, enumValue.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithValues(string enumValue)
    => _checks.Inequality(
      () => new ArgumentAst(AstNulls.At, enumValue.ArgumentList()),
      () => new ArgumentAst(AstNulls.At, enumValue));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string key, string enumValue)
    => _checks.Equality(
      () => new ArgumentAst(AstNulls.At, enumValue.ArgumentObject(key)));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithFields(string key, string enumValue)
    => _checks.Inequality(
      () => new ArgumentAst(AstNulls.At, enumValue.ArgumentObject(key)),
      () => new ArgumentAst(AstNulls.At, enumValue));

  internal BaseAstChecks<ArgumentAst> _checks = new();
}
