using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

public class ArgAstTests
{
  [Fact]
  public void HashCode_WithNull()
    => _checks.HashCode(
      () => new ArgAst(AstNulls.At) with { At = AstNulls.At });

  [Theory, RepeatData]
  public void HashCode_WithVariable(string variable)
    => _checks.HashCode(
      () => new ArgAst(AstNulls.At, variable));

  [Theory, RepeatData]
  public void HashCode_WithConstant(string enumType, string enumValue)
    => _checks.HashCode(
      () => new ArgAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData]
  public void HashCode_WithValues(string enumValue)
    => _checks.HashCode(
      () => new ArgAst(AstNulls.At, enumValue.ArgList()));

  [Theory, RepeatData]
  public void HashCode_WithFields(string key, string enumValue)
    => _checks.HashCode(
      () => new ArgAst(AstNulls.At, enumValue.ArgObject(key)));

  [Theory, RepeatData]
  public void Text_WithVariable(string variable)
    => _checks.Text(
      () => new ArgAst(AstNulls.At, variable),
      $"( !a ${variable} )");

  [Theory, RepeatData]
  public void Text_WithConstant(string enumValue)
    => _checks.Text(
      () => new ArgAst(new ConstantAst(enumValue.FieldKey())),
      $"( !k {enumValue} )");

  [Theory, RepeatData]
  public void Text_WithValues(string enumValue)
    => _checks.Text(
      () => new ArgAst(AstNulls.At, enumValue.ArgList()),
      $"( !a [ !a ${enumValue} !k {enumValue} ] )");

  [Theory, RepeatData]
  public void Text_WithFields(string key, string enumValue)
    => _checks.Text(
      () => new ArgAst(AstNulls.At, enumValue.ArgObject(key)),
      $"( !a {{ ( !k {key} ):( !a ${enumValue} ) ( !k {enumValue} ):( !k {key} ) }} )",
      key == enumValue);

  [Theory, RepeatData]
  public void Clone(string variable)
  {
    ArgAst item = new(AstNulls.At, variable);
    _checks.Equality(
        () => item,
        () => item with { Variable = variable });
  }

  [Theory, RepeatData]
  public void Equality_WithVariable(string variable)
    => _checks.Equality(
      () => new ArgAst(AstNulls.At, variable));

  [Theory, RepeatData]
  public void Inequality_WithVariable(string variable)
    => _checks.InequalityBetween(variable, variable + "a",
      v => new ArgAst(AstNulls.At, v));

  [Theory, RepeatData]
  public void Equality_WithConstant(string enumType, string enumValue)
    => _checks.Equality(
      () => new ArgAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData]
  public void Inequality_WithConstant(string enumType, string enumValue)
    => _checks.Inequality(
      () => new ArgAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)),
      () => new ArgAst(new FieldKeyAst(AstNulls.At, enumValue, enumType)),
      enumType == enumValue);

  [Theory, RepeatData]
  public void Equality_WithValues(string enumValue)
    => _checks.Equality(
      () => new ArgAst(AstNulls.At, enumValue.ArgList()));

  [Theory, RepeatData]
  public void Inequality_WithValues(string enumValue)
    => _checks.Inequality(
      () => new ArgAst(AstNulls.At, enumValue.ArgList()),
      () => new ArgAst(AstNulls.At, enumValue));

  [Theory, RepeatData]
  public void Equality_WithFields(string key, string enumValue)
    => _checks.Equality(
      () => new ArgAst(AstNulls.At, enumValue.ArgObject(key)));

  [Theory, RepeatData]
  public void Inequality_WithFields(string key, string enumValue)
    => _checks.Inequality(
      () => new ArgAst(AstNulls.At, enumValue.ArgObject(key)),
      () => new ArgAst(AstNulls.At, enumValue));

  internal BaseAstChecks<IGqlpArg> _checks = new();
}
