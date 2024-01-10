namespace GqlPlus.Verifier.Model;

public abstract class ModelAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void Model_Default(string input)
    => AliasedChecks.Model_Expected(
      AliasedChecks.ToModel(AliasedChecks.AliasedAst(input)),
      ExpectedDescriptionAliases(input, "", "").Tidy());

  [Theory, RepeatData(Repeats)]
  public void Model_Description(string input, string contents)
    => AliasedChecks.Model_Expected(
      AliasedChecks.ToModel(AliasedChecks.AliasedAst(input) with { Description = contents }),
      ExpectedDescriptionAliases(input, "description: " + AliasedChecks.YamlQuoted(contents), "").Tidy());

  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(string input, string[] aliases)
    => AliasedChecks.Model_Expected(
      AliasedChecks.ToModel(AliasedChecks.AliasedAst(input) with { Aliases = aliases }),
      ExpectedDescriptionAliases(input, "", "aliases: [" + string.Join(", ", aliases) + "]").Tidy());

  protected abstract string[] ExpectedDescriptionAliases(string input, string description, string aliases);
  internal abstract IModelAliasedChecks AliasedChecks { get; }
}
