namespace GqlPlus.Verifier.ClassTests.Parse.Schema;

public abstract class BaseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name, string fieldType)
  => Checks.WithMinimum(name, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string name, string fieldType, string[] aliases)
  => Checks.WithAliases(name, fieldType, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string name, string fieldType)
  => Checks.WithModifiers(name, fieldType);

  internal abstract IBaseFieldChecks Checks { get; }
}
