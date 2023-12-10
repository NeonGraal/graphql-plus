namespace GqlPlus.Verifier.Ast.Schema;

public class AlternateAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode(string argument)
    => _checks.HashCode(() => Alternate(argument));

  [Theory, RepeatData(Repeats)]
  public void String(string argument)
    => _checks.String(
      () => Alternate(argument),
      $"( !AI {argument} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithKey(string argument)
    => _checks.Equality(() => Alternate(argument));

  [Theory, RepeatData(Repeats)]
  public void Inequality(string argument1, string argument2)
    => _checks.InequalityBetween(argument1, argument2, Alternate, argument1 == argument2);

  private static AlternateAst<InputReferenceAst> Alternate(string argument)
    => new(new(AstNulls.At, argument));

  internal BaseAstChecks<AlternateAst<InputReferenceAst>> _checks = new();
}
