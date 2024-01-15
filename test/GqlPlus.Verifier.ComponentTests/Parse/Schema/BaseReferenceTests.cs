namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseReferenceTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => ReferenceChecks.WithMinimum(name);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameter_ReturnsCorrectAst(string name)
  => ReferenceChecks.WithTypeParameter(name);

  [Fact]
  public void WithTypeParameterBad_ReturnsFalse()
  => ReferenceChecks.WithTypeParameterBad();

  [Theory, RepeatData(Repeats)]
  public void WithTypeArguments_ReturnsCorrectAst(string name, string[] references)
  => ReferenceChecks.WithTypeArguments(name, references);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsBad_ReturnsCorrectAst(string name, string[] references)
  => ReferenceChecks.WithTypeArgumentsBad(name, references);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsNone_ReturnsFalse(string name)
  => ReferenceChecks.WithTypeArgumentsNone(name);

  internal abstract IBaseReferenceChecks ReferenceChecks { get; }
}
