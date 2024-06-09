using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Modelling;

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
        DescribedChecks.ExpectedDescription(new(name, contents)));
  }

  internal sealed override ICheckModelBase<TName> BaseChecks => DescribedChecks;

  internal abstract ICheckDescribedModel<TName> DescribedChecks { get; }
}

internal abstract class CheckDescribedModel<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller,
  IRenderer<TModel> rendering
) : CheckDescribedModel<TName, TAst, TAst, TModel>(modeller, rendering)
  where TAst : IGqlpError, IGqlpDescribed
  where TModel : IRendering
{ }

internal abstract class CheckDescribedModel<TName, TSrc, TAst, TModel>(
  IModeller<TSrc, TModel> modeller,
  IRenderer<TModel> rendering
) : CheckModelBase<TName, TSrc, TAst, TModel>(modeller, rendering)
  , ICheckDescribedModel<TName>
  where TSrc : IGqlpError, IGqlpDescribed
  where TAst : IGqlpError, TSrc
  where TModel : IRendering
{
  protected abstract TAst NewDescribedAst(TName name, string description);
  protected abstract string[] ExpectedDescription(ExpectedDescriptionInput<TName> input);

  protected override TAst NewBaseAst(TName name) => NewDescribedAst(name, "");
  protected sealed override string[] ExpectedBase(TName name) => ExpectedDescription(new(name));

  IGqlpError ICheckDescribedModel<TName>.DescribedAst(TName name, string description) => NewDescribedAst(name, description);
  string[] ICheckDescribedModel<TName>.ExpectedDescription(ExpectedDescriptionInput<TName> input) => ExpectedDescription(input);
}

internal interface ICheckDescribedModel<TName>
  : ICheckModelBase<TName>
{
  IGqlpError DescribedAst(TName name, string description);
  string[] ExpectedDescription(ExpectedDescriptionInput<TName> input);
}

internal class ExpectedDescriptionInput<TName>(
  TName name,
  string? description = null)
{
  internal TName Name { get; } = name;
  public string[] Description { get; protected set; }
    = string.IsNullOrWhiteSpace(description) ? [] : ["description: " + description.YamlQuoted()];
}
