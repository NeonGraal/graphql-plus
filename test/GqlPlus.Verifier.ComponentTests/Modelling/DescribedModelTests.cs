using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class DescribedModelTests<TInput>
  : ModelBaseTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Description(TInput input, string contents)
  {
    if (SkipIf(input)) {
      return;
    }

    DescribedChecks.Model_Expected(
        DescribedChecks.ToModel(DescribedChecks.DescribedAst(input, contents)),
        ExpectedDescription(input, "description: " + DescribedChecks.YamlQuoted(contents)).Tidy());
  }

  internal sealed override IModelBaseChecks<TInput> BaseChecks => DescribedChecks;
  protected sealed override string[] ExpectedBase(TInput input) => ExpectedDescription(input, "");

  internal abstract IDescribedModelChecks<TInput> DescribedChecks { get; }
  protected abstract string[] ExpectedDescription(TInput input, string description);
}

internal abstract class DescribedModelChecks<TInput, TAst, TModel>(
  IModeller<TAst, TModel> modeller
) : ModelBaseChecks<TInput, TAst, TModel>(modeller)
  , IDescribedModelChecks<TInput>
  where TAst : AstAbbreviated, IAstDescribed
  where TModel : IRendering
{
  protected abstract TAst NewDescribedAst(TInput input, string description);

  protected override TAst NewBaseAst(TInput input) => NewDescribedAst(input, "");

  AstAbbreviated IDescribedModelChecks<TInput>.DescribedAst(TInput input, string description) => NewDescribedAst(input, description);
}

internal interface IDescribedModelChecks<TInput> : IModelBaseChecks<TInput>
{
  AstAbbreviated DescribedAst(TInput input, string description);
}
