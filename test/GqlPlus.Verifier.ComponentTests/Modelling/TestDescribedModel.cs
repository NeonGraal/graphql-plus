using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class TestDescribedModel<TName>
  : TestModelBase<TName>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Description(TName name, string contents)
  {
    if (SkipIf(name)) {
      return;
    }

    DescribedChecks.Model_Expected(
        DescribedChecks.ToModel(DescribedChecks.DescribedAst(name, contents)),
        DescribedChecks.ExpectedDescription(new(name, contents)).Tidy());
  }

  internal sealed override ICheckModelBase<TName> BaseChecks => DescribedChecks;

  internal abstract ICheckDescribedModel<TName> DescribedChecks { get; }
}

internal abstract class CheckDescribedModel<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller
) : CheckModelBase<TName, TAst, TModel>(modeller)
  , ICheckDescribedModel<TName>
  where TAst : AstAbbreviated, IAstDescribed
  where TModel : IRendering
{
  protected abstract TAst NewDescribedAst(TName name, string description);
  protected abstract string[] ExpectedDescription(ExpectedDescriptionInput<TName> input);

  protected override TAst NewBaseAst(TName name) => NewDescribedAst(name, "");
  protected sealed override string[] ExpectedBase(TName name) => ExpectedDescription(new(name));

  AstAbbreviated ICheckDescribedModel<TName>.DescribedAst(TName name, string description) => NewDescribedAst(name, description);
  string[] ICheckDescribedModel<TName>.ExpectedDescription(ExpectedDescriptionInput<TName> input) => ExpectedDescription(input);
}

internal interface ICheckDescribedModel<TName>
  : ICheckModelBase<TName>
{
  AstAbbreviated DescribedAst(TName name, string description);
  string[] ExpectedDescription(ExpectedDescriptionInput<TName> input);
}

internal class ExpectedDescriptionInput<TName>(
  TName name,
  string? description = null)
{
  internal TName Name { get; } = name;
  public string[] Description { get; protected set; }
    = description.ExpectedDescription();
}
