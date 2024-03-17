using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class TestDescribedModel<TInput>
  : TestModelBase<TInput>
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

  internal sealed override ICheckModelBase<TInput> BaseChecks => DescribedChecks;
  protected sealed override string[] ExpectedBase(TInput input) => ExpectedDescription(input, "");

  internal abstract ICheckDescribedModel<TInput> DescribedChecks { get; }
  protected abstract string[] ExpectedDescription(TInput input, string description);
}

internal abstract class CheckDescribedModel<TInput, TAst, TModel>(
  IModeller<TAst, TModel> modeller
) : CheckModelBase<TInput, TAst, TModel>(modeller)
  , ICheckDescribedModel<TInput>
  where TAst : AstAbbreviated, IAstDescribed
  where TModel : IRendering
{
  protected abstract TAst NewDescribedAst(TInput input, string description);

  protected override TAst NewBaseAst(TInput input) => NewDescribedAst(input, "");

  AstAbbreviated ICheckDescribedModel<TInput>.DescribedAst(TInput input, string description) => NewDescribedAst(input, description);
}

internal interface ICheckDescribedModel<TInput>
  : ICheckModelBase<TInput>
{
  AstAbbreviated DescribedAst(TInput input, string description);
}
