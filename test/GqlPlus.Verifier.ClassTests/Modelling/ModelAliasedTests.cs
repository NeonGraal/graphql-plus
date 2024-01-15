namespace GqlPlus.Verifier.Modelling;

public abstract class ModelAliasedTests<TInput> : ModelDescribedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(TInput input, string[] aliases)
    => AliasedChecks.Model_Expected(
      AliasedChecks.ToModel(AliasedChecks.AliasedAst(input) with { Aliases = aliases }),
      ExpectedDescriptionAliases(input, "", "aliases: [" + string.Join(", ", aliases) + "]").Tidy());

  internal sealed override IModelDescribedChecks<TInput> DescribedChecks => AliasedChecks;
  protected sealed override string[] ExpectedDescription(TInput input, string description)
    => ExpectedDescriptionAliases(input, description, "");

  internal abstract IModelAliasedChecks<TInput> AliasedChecks { get; }
  protected abstract string[] ExpectedDescriptionAliases(TInput input, string description, string aliases);
}
