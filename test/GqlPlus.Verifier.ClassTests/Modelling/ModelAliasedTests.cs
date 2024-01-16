using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class ModelAliasedTests<TInput> : ModelDescribedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(TInput input, string[] aliases)
    => AliasedChecks.Model_Expected(
      AliasedChecks.ToModel(AliasedChecks.AliasedAst(input) with { Aliases = aliases }),
      ExpectedDescriptionAliases(input, "", "aliases: [" + string.Join(", ", aliases) + "]").Tidy());

  internal sealed override IModelDescribedChecks<TInput> DescribedChecks => AliasedChecks;
  protected sealed override string[] ExpectedDescription(TInput input, string description)
    => ExpectedDescriptionAliases(input, description, "");

  internal abstract IModelAliasedChecks<TInput> AliasedChecks { get; }
  protected abstract string[] ExpectedDescriptionAliases(TInput input, string description, string aliases);
}

internal abstract class ModelAliasedChecks<TInput, TAst>
  : ModelDescribedChecks<TInput, TAst>, IModelAliasedChecks<TInput>
  where TAst : AstAliased
{
  AstAliased IModelAliasedChecks<TInput>.AliasedAst(TInput input) => NewDescribedAst(input, "");
  IRendering IModelAliasedChecks<TInput>.ToModel(AstAliased aliased) => AstToModel((TAst)aliased);
}

internal interface IModelAliasedChecks<TInput> : IModelDescribedChecks<TInput>
{
  AstAliased AliasedAst(TInput input);
  IRendering ToModel(AstAliased aliased);
}
