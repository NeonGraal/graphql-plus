namespace GqlPlus.Verifier.Ast.Schema;

public class InputReferenceAstTests : BaseNamedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithIsTypeParameter(string name)
      => _checks.HashCode(
        () => new InputReferenceAst(AstNulls.At, name) { IsTypeParameter = true });

  [Theory, RepeatData(Repeats)]
  public void String_WithIsTypeParameter(string name)
    => _checks.String(
      () => new InputReferenceAst(AstNulls.At, name) { IsTypeParameter = true },
      $"( ${name} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithIsTypeParameter(string name)
    => _checks.Equality(
      () => new InputReferenceAst(AstNulls.At, name) { IsTypeParameter = true });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenIsTypeParameters(string name, bool isTypeParam1)
    => _checks.InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => new InputReferenceAst(AstNulls.At, name) { IsTypeParameter = isTypeParam },
      false);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArguments(string name, string argument)
      => _checks.HashCode(
        () => new InputReferenceAst(AstNulls.At, name) { Arguments = argument.InputReferences() });

  [Theory, RepeatData(Repeats)]
  public void String_WithArguments(string name, string argument)
    => _checks.String(
      () => new InputReferenceAst(AstNulls.At, name) { Arguments = argument.InputReferences() },
      $"( {name} < {argument} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArguments(string name, string argument)
    => _checks.Equality(
      () => new InputReferenceAst(AstNulls.At, name) { Arguments = argument.InputReferences() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenArguments(string name, string argument1, string argument2)
    => _checks.InequalityBetween(argument1, argument2,
      argument => new InputReferenceAst(AstNulls.At, name) { Arguments = argument.InputReferences() },
      argument1 == argument2);

  protected override string InputString(string input)
    => $"( {input} )";

  private readonly BaseNamedAstChecks<InputReferenceAst> _checks
    = new(name => new InputReferenceAst(AstNulls.At, name));

  internal override IBaseNamedAstChecks NamedChecks => _checks;
}
