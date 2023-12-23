namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseAliasedTests<I>
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(I input)
  => AliasChecks.WithMinimum(input);

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(I input, string[] aliases)
  => AliasChecks.WithAliases(input, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithAliasesBad_ReturnsFalse(I input, string[] aliases)
  => AliasChecks.WithAliasesBad(input, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithAliasesNone_ReturnsFalse(I input)
  => AliasChecks.WithAliasesNone(input);

  internal abstract IBaseAliasedChecks<I> AliasChecks { get; }
}
