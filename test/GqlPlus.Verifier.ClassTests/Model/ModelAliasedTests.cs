namespace GqlPlus.Verifier.Model;

public abstract class ModelAliasedTests : ModelDescribedTests
{
  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(string input, string[] aliases)
    => AliasedChecks.Model_Expected(
      AliasedChecks.ToModel(AliasedChecks.AliasedAst(input) with { Aliases = aliases }),
      ExpectedDescriptionAliases(input, "", "aliases: [" + string.Join(", ", aliases) + "]").Tidy());

  internal override IModelDescribedChecks DescribedChecks => AliasedChecks;
  protected override string[] ExpectedDescription(string input, string description)
    => ExpectedDescriptionAliases(input, description, "");

  protected abstract string[] ExpectedDescriptionAliases(string input, string description, string aliases);
  internal abstract IModelAliasedChecks AliasedChecks { get; }
}
