namespace GqlPlus.Verifier.Modelling;

public abstract class ModelBaseTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Default(TInput input)
    => BaseChecks.Model_Expected(
      BaseChecks.ToModel(BaseChecks.BaseAst(input)),
      ExpectedBase(input).Tidy());

  protected abstract string[] ExpectedBase(TInput input);
  internal abstract IModelBaseChecks<TInput> BaseChecks { get; }
}
