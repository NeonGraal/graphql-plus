namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseReferenceTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => Checks.WithMinimum(name);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameter_ReturnsCorrectAst(string name)
  => Checks.WithTypeParameter(name);

  [Fact]
  public void WithTypeParameterBad_ReturnsFalse()
  => Checks.WithTypeParameterBad();

  [Theory, RepeatData(Repeats)]
  public void WithTypeArguments_ReturnsCorrectAst(string name, string[] references)
  => Checks.WithTypeArguments(name, references);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsBad_ReturnsCorrectAst(string name, string[] references)
  => Checks.WithTypeArgumentsBad(name, references);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsNone_ReturnsFalse(string name)
  => Checks.WithTypeArgumentsNone(name);

  internal abstract IBaseReferenceChecks Checks { get; }
}
