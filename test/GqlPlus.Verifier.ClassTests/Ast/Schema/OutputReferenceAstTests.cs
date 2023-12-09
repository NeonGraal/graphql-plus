namespace GqlPlus.Verifier.Ast.Schema;

public class OutputReferenceAstTests : BaseNamedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(string name, string enumValue)
      => _checks.HashCode(
        () => new OutputReferenceAst(AstNulls.At, name) { EnumValue = enumValue });

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(string name, string enumValue)
    => _checks.String(
      () => new OutputReferenceAst(AstNulls.At, name) { EnumValue = enumValue },
      $"( {name}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(string name, string enumValue)
    => _checks.Equality(
      () => new OutputReferenceAst(AstNulls.At, name) { EnumValue = enumValue });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumValues(string name, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumValue => new OutputReferenceAst(AstNulls.At, name) { EnumValue = enumValue },
      enumValue1 == enumValue2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithIsTypeParameter(string name)
      => _checks.HashCode(
        () => new OutputReferenceAst(AstNulls.At, name) { IsTypeParameter = true });

  [Theory, RepeatData(Repeats)]
  public void String_WithIsTypeParameter(string name)
    => _checks.String(
      () => new OutputReferenceAst(AstNulls.At, name) { IsTypeParameter = true },
      $"( ${name} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithIsTypeParameter(string name)
    => _checks.Equality(
      () => new OutputReferenceAst(AstNulls.At, name) { IsTypeParameter = true });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenIsTypeParameters(string name, bool isTypeParam1)
    => _checks.InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => new OutputReferenceAst(AstNulls.At, name) { IsTypeParameter = isTypeParam },
      false);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArguments(string name, string argument)
      => _checks.HashCode(
        () => new OutputReferenceAst(AstNulls.At, name) { Arguments = argument.OutputReferences() });

  [Theory, RepeatData(Repeats)]
  public void String_WithArguments(string name, string argument)
    => _checks.String(
      () => new OutputReferenceAst(AstNulls.At, name) { Arguments = argument.OutputReferences() },
      $"( {name} < {argument} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArguments(string name, string argument)
    => _checks.Equality(
      () => new OutputReferenceAst(AstNulls.At, name) { Arguments = argument.OutputReferences() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenArguments(string name, string argument1, string argument2)
    => _checks.InequalityBetween(argument1, argument2,
      argument => new OutputReferenceAst(AstNulls.At, name) { Arguments = argument.OutputReferences() },
      argument1 == argument2);

  protected override string InputString(string input)
    => $"( {input} )";

  private readonly BaseNamedAstChecks<OutputReferenceAst> _checks
    = new(name => new OutputReferenceAst(AstNulls.At, name));

  internal override IBaseNamedAstChecks NamedChecks => _checks;
}
