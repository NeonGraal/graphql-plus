using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

public abstract class ModelDescribedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Default(TInput input)
    => DescribedChecks.Model_Expected(
      DescribedChecks.ToModel(DescribedChecks.DescribedAst(input, "")),
      ExpectedDescription(input, "").Tidy());

  [Theory, RepeatData(Repeats)]
  public void Model_Description(TInput input, string contents)
    => DescribedChecks.Model_Expected(
      DescribedChecks.ToModel(DescribedChecks.DescribedAst(input, contents)),
      ExpectedDescription(input, "description: " + DescribedChecks.YamlQuoted(contents)).Tidy());

  protected abstract string[] ExpectedDescription(TInput input, string description);
  internal abstract IModelDescribedChecks<TInput> DescribedChecks { get; }
}
