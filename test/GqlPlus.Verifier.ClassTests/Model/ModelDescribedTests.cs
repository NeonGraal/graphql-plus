namespace GqlPlus.Verifier.Model;

public abstract class ModelDescribedTests
{
  [Theory, RepeatData(Repeats)]
  public void Model_Default(string input)
    => DescribedChecks.Model_Expected(
      DescribedChecks.ToModel(DescribedChecks.DescribedAst(input)),
      ExpectedDescription(input, "").Tidy());

  [Theory, RepeatData(Repeats)]
  public void Model_Description(string input, string contents)
    => DescribedChecks.Model_Expected(
      DescribedChecks.ToModel(DescribedChecks.DescribedAst(input) with { Description = contents }),
      ExpectedDescription(input, "description: " + DescribedChecks.YamlQuoted(contents)).Tidy());

  protected abstract string[] ExpectedDescription(string input, string description);
  internal abstract IModelDescribedChecks DescribedChecks { get; }
}
