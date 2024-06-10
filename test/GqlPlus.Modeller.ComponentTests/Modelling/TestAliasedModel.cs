using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;

namespace GqlPlus.Modelling;

public abstract class TestAliasedModel<TInput>
  : TestDescribedModel<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(TInput input, string[] aliases)
  {
    Skip.If(SkipIf(input));

    AliasedChecks.Model_Expected(
        AliasedChecks.ToModel(AliasedChecks.AliasedAst(input, aliases)),
        AliasedChecks.ExpectedDescriptionAliases(new(input, aliases)));
  }

  internal sealed override ICheckDescribedModel<TInput> DescribedChecks => AliasedChecks;

  internal abstract ICheckAliasedModel<TInput> AliasedChecks { get; }
}

internal abstract class CheckAliasedModel<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller,
  IRenderer<TModel> rendering
) : CheckAliasedModel<TName, TAst, TAst, TModel>(modeller, rendering)
  where TAst : IGqlpAliased
  where TModel : IModelBase
{ }

internal abstract class CheckAliasedModel<TName, TSrc, TAst, TModel>(
  IModeller<TSrc, TModel> modeller,
  IRenderer<TModel> rendering
) : CheckDescribedModel<TName, TSrc, TAst, TModel>(modeller, rendering)
  , ICheckAliasedModel<TName>
  where TSrc : IGqlpError, IGqlpDescribed
  where TAst : IGqlpAliased, TSrc
  where TModel : IModelBase
{
  protected abstract string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<TName> input);

  protected override string[] ExpectedDescription(ExpectedDescriptionInput<TName> input)
    => ExpectedDescriptionAliases(new(input));

  IGqlpAliased ICheckAliasedModel<TName>.AliasedAst(TName name, string[]? aliases)
    => NewAliasedAst(name, aliases: aliases);
  string[] ICheckAliasedModel<TName>.ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<TName> input) => ExpectedDescriptionAliases(input);
  IModelBase ICheckAliasedModel<TName>.ToModel(IGqlpAliased aliased) => AstToModel((TAst)aliased);

  protected override TAst NewDescribedAst(TName name, string description)
    => NewAliasedAst(name, description);

  protected abstract TAst NewAliasedAst(TName name, string? description = null, string[]? aliases = null);
}

internal interface ICheckAliasedModel<TName>
  : ICheckDescribedModel<TName>
{
  IGqlpAliased AliasedAst(TName name, string[]? aliases = null);
  IModelBase ToModel(IGqlpAliased aliased);
  string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<TName> input);
}

internal class ExpectedDescriptionAliasesInput<TName>(
  TName name,
  IEnumerable<string>? aliases = null,
  string? description = null
) : ExpectedDescriptionInput<TName>(name, description)
{
  public string[] Aliases { get; protected set; }
    = aliases is null ? [] : [aliases.YamlJoin("aliases: [", "]")];

  internal ExpectedDescriptionAliasesInput(ExpectedDescriptionInput<TName> input)
    : this(input.Name)
    => Description = input.Description;
}
