using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class TestAliasedModel<TInput>
  : TestDescribedModel<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(TInput input, string[] aliases)
  {
    Skip.If(SkipIf(input));

    AliasedChecks.Model_Expected(
        AliasedChecks.ToModel(AliasedChecks.AliasedAst(input) with { Aliases = aliases }),
        ExpectedDescriptionAliases(input, "", "aliases: [" + string.Join(", ", aliases) + "]").Tidy());
  }

  internal sealed override ICheckDescribedModel<TInput> DescribedChecks => AliasedChecks;
  protected sealed override string[] ExpectedDescription(TInput input, string description)
    => ExpectedDescriptionAliases(input, description, "");

  internal abstract ICheckAliasedModel<TInput> AliasedChecks { get; }
  protected abstract string[] ExpectedDescriptionAliases(TInput input, string description, string aliases);
}

internal abstract class CheckAliasedModel<TInput, TAst, TModel>(
  IModeller<TAst, TModel> modeller
) : CheckDescribedModel<TInput, TAst, TModel>(modeller)
  , ICheckAliasedModel<TInput>
  where TAst : AstAliased
  where TModel : IRendering
{
  AstAliased ICheckAliasedModel<TInput>.AliasedAst(TInput input) => NewDescribedAst(input, "");
  IRendering ICheckAliasedModel<TInput>.ToModel(AstAliased aliased) => AstToModel((TAst)aliased);
}

internal interface ICheckAliasedModel<TInput> : ICheckDescribedModel<TInput>
{
  AstAliased AliasedAst(TInput input);
  IRendering ToModel(AstAliased aliased);
}
