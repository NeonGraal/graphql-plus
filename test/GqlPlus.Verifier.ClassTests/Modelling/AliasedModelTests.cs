using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class AliasedModelTests<TInput>
  : DescribedModelTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(TInput input, string[] aliases)
  {
    Skip.If(SkipIf(input));

    AliasedChecks.Model_Expected(
        AliasedChecks.ToModel(AliasedChecks.AliasedAst(input) with { Aliases = aliases }),
        ExpectedDescriptionAliases(input, "", "aliases: [" + string.Join(", ", aliases) + "]").Tidy());
  }

  internal sealed override IDescribedModelChecks<TInput> DescribedChecks => AliasedChecks;
  protected sealed override string[] ExpectedDescription(TInput input, string description)
    => ExpectedDescriptionAliases(input, description, "");

  internal abstract IAliasedModelChecks<TInput> AliasedChecks { get; }
  protected abstract string[] ExpectedDescriptionAliases(TInput input, string description, string aliases);
}

internal abstract class AliasedModelChecks<TInput, TAst, TModel>(
  IModeller<TAst> modeller
) : DescribedModelChecks<TInput, TAst, TModel>(modeller)
  , IAliasedModelChecks<TInput>
  where TAst : AstAliased
  where TModel : IRendering
{
  AstAliased IAliasedModelChecks<TInput>.AliasedAst(TInput input) => NewDescribedAst(input, "");
  IRendering IAliasedModelChecks<TInput>.ToModel(AstAliased aliased) => AstToModel((TAst)aliased);
}

internal interface IAliasedModelChecks<TInput> : IDescribedModelChecks<TInput>
{
  AstAliased AliasedAst(TInput input);
  IRendering ToModel(AstAliased aliased);
}
