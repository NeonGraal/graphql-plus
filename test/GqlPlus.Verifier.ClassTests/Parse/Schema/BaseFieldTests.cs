namespace GqlPlus.Verifier.ClassTests.Parse.Schema;

public abstract class BaseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name, string fieldType)
  => Checks.WithMinimum(name, fieldType);

  internal abstract IBaseFieldChecks Checks { get; }
}
