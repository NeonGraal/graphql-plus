namespace GqlPlus.Verifier.ClassTests.Parse.Schema;

public abstract class BaseReferenceTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => Checks.WithMinimum(name);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameter_ReturnsCorrectAst(string name)
  => Checks.WithTypeParameter(name);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArguments_ReturnsCorrectAst(string name, string[] references)
  => Checks.WithTypeArguments(name, references);

  internal abstract IBaseReferenceChecks Checks { get; }
}
