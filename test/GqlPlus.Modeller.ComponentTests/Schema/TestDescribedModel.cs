using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling;

namespace GqlPlus.Schema;

public abstract class TestDescribedModel<TName, TRender>(
  ICheckDescribedModel<TName, TRender> describedChecks
) : TestModelBase<TName, TRender>(describedChecks)
  where TRender : IModelBase
{
  [Theory, RepeatData(Repeats)]
  public void Model_Description(TName name, string contents)
  {
    if (SkipIf(name)) {
      return;
    }

    describedChecks.Model_Expected(
        describedChecks.ToModel(describedChecks.DescribedAst(name, contents)),
        describedChecks.ExpectedDescription(new(name, contents)));
  }
}

internal abstract class CheckDescribedModel<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller,
  IRenderer<TModel> rendering
) : CheckDescribedModel<TName, TAst, TAst, TModel>(modeller, rendering)
  where TAst : IGqlpError, IGqlpDescribed
  where TModel : IModelBase
{ }

internal abstract class CheckDescribedModel<TName, TSrc, TAst, TModel>(
  IModeller<TSrc, TModel> modeller,
  IRenderer<TModel> rendering
) : CheckModelBase<TName, TSrc, TAst, TModel>(modeller, rendering)
  , ICheckDescribedModel<TName, TModel>
  where TSrc : IGqlpError, IGqlpDescribed
  where TAst : IGqlpError, TSrc
  where TModel : IModelBase
{
  protected abstract TAst NewDescribedAst(TName name, string description);
  protected abstract string[] ExpectedDescription(ExpectedDescriptionInput<TName> input);

  protected override TAst NewBaseAst(TName name) => NewDescribedAst(name, "");
  protected sealed override string[] ExpectedBase(TName name) => ExpectedDescription(new(name));

  IGqlpError ICheckDescribedModel<TName, TModel>.DescribedAst(TName name, string description) => NewDescribedAst(name, description);
  string[] ICheckDescribedModel<TName, TModel>.ExpectedDescription(ExpectedDescriptionInput<TName> input) => ExpectedDescription(input);
}

public interface ICheckDescribedModel<TName, TRender>
  : ICheckModelBase<TName, TRender>
  where TRender : IModelBase
{
  IGqlpError DescribedAst(TName name, string description);
  string[] ExpectedDescription(ExpectedDescriptionInput<TName> input);
}

public class ExpectedDescriptionInput<TName>(
  TName name,
  string? description = null)
{
  internal TName Name { get; } = name;
  public string Description { get; protected set; } = description ?? string.Empty;
#pragma warning disable CA1819 // Properties should not return arrays
  public string[] ExpectedDescription { get; protected set; }
#pragma warning restore CA1819 // Properties should not return arrays
    = string.IsNullOrWhiteSpace(description) ? [] : ["description: " + description.YamlQuoted()];
}
