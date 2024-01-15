namespace GqlPlus.Verifier.Modelling;

public abstract class ModelDescribedTests<TInput>
  : ModelBaseTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Description(TInput input, string contents)
    => DescribedChecks.Model_Expected(
      DescribedChecks.ToModel(DescribedChecks.DescribedAst(input, contents)),
      ExpectedDescription(input, "description: " + DescribedChecks.YamlQuoted(contents)).Tidy());

  internal sealed override IModelBaseChecks<TInput> BaseChecks => DescribedChecks;
  protected sealed override string[] ExpectedBase(TInput input) => ExpectedDescription(input, "");

  internal abstract IModelDescribedChecks<TInput> DescribedChecks { get; }
  protected abstract string[] ExpectedDescription(TInput input, string description);
}
