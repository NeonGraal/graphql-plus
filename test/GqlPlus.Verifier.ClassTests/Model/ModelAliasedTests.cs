using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

public abstract class ModelAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void Model_Default(string input)
    => AliasedChecks.Model_Expected(
      AliasedChecks.ToModel(AliasedChecks.AliasedAst(input)),
      ExpectedDescriptionAliases(input, "", ""));

  [Theory, RepeatData(Repeats)]
  public void Model_Description(string input, string contents)
    => AliasedChecks.Model_Expected(
      AliasedChecks.ToModel(AliasedChecks.AliasedAst(input) with { Description = contents }),
      ExpectedDescriptionAliases(input, Environment.NewLine + "description: " + AliasedChecks.YamlQuoted(contents), ""));

  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(string input, string[] aliases)
    => AliasedChecks.Model_Expected(
      AliasedChecks.ToModel(AliasedChecks.AliasedAst(input) with { Aliases = aliases }),
      ExpectedDescriptionAliases(input, "", Environment.NewLine + "aliases: [" + string.Join(", ", aliases) + "]"));

  protected abstract string ExpectedDescriptionAliases(string input, string description, string aliases);
  internal abstract IModelAliasedChecks AliasedChecks { get; }
}
