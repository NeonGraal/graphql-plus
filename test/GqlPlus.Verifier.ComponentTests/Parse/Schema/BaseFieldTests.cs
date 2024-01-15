namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseFieldTests
  : BaseAliasedTests<FieldInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string name, string fieldType)
  => FieldChecks.WithModifiers(name, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithModifiersBad_ReturnsFalse(string name, string fieldType)
  => FieldChecks.WithModifiersBad(name, fieldType);

  internal abstract IBaseFieldChecks FieldChecks { get; }

  internal sealed override IBaseAliasedChecks<FieldInput> AliasChecks => FieldChecks;
}
