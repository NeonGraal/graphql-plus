namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseFieldTests
  : BaseAliasedTests<FieldInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string name, string fieldType)
  => Checks.WithModifiers(name, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithModifiersBad_ReturnsFalse(string name, string fieldType)
  => Checks.WithModifiers(name, fieldType);

  internal abstract IBaseFieldChecks Checks { get; }

  internal override IBaseAliasedChecks<FieldInput> AliasChecks => Checks;
}
