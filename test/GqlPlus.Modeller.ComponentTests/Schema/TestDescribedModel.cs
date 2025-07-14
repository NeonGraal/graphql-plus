using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling;

namespace GqlPlus.Schema;

public abstract class TestDescribedModel<TName, TModel>(
  ICheckDescribedModel<TName, TModel> describedChecks
) : TestModelBase<TName, TModel>(describedChecks)
  where TModel : IModelBase
{
  [Theory, RepeatData]
  public void Model_Description(TName name, string contents)
  {
    Assert.SkipWhen(SkipIf(name), SkipReason);

    describedChecks.Model_Expected(
        describedChecks.ToModel(describedChecks.DescribedAst(name, contents)),
        describedChecks.ExpectedDescription(new(name, contents)));
  }
}

internal abstract class CheckDescribedModel<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller,
  IEncoder<TModel> encoding
) : CheckDescribedModel<TName, TAst, TAst, TModel>(modeller, encoding)
  where TAst : IGqlpError, IGqlpDescribed
  where TModel : IModelBase
{ }

internal abstract class CheckDescribedModel<TName, TSrc, TAst, TModel>(
  IModeller<TSrc, TModel> modeller,
  IEncoder<TModel> encoding
) : CheckModelBase<TName, TSrc, TAst, TModel>(modeller, encoding)
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

public interface ICheckDescribedModel<TName, TModel>
  : ICheckModelBase<TName, TModel>
  where TModel : IModelBase
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
    = string.IsNullOrWhiteSpace(description) ? [] : ["description: " + description.Quoted("'")];
}
