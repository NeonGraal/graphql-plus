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
        AliasedChecks.ExpectedDescriptionAliases(new(input, ["aliases: [" + string.Join(", ", aliases) + "]"])).Tidy());
  }

  internal sealed override ICheckDescribedModel<TInput> DescribedChecks => AliasedChecks;

  internal abstract ICheckAliasedModel<TInput> AliasedChecks { get; }
}

internal abstract class CheckAliasedModel<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller
) : CheckDescribedModel<TName, TAst, TModel>(modeller)
  , ICheckAliasedModel<TName>
  where TAst : AstAliased
  where TModel : IRendering
{
  protected abstract string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<TName> input);

  protected override string[] ExpectedDescription(ExpectedDescriptionInput<TName> input)
    => ExpectedDescriptionAliases(new(input));

  AstAliased ICheckAliasedModel<TName>.AliasedAst(TName name) => NewDescribedAst(name, "");
  string[] ICheckAliasedModel<TName>.ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<TName> input) => ExpectedDescriptionAliases(input);
  IRendering ICheckAliasedModel<TName>.ToModel(AstAliased aliased) => AstToModel((TAst)aliased);
}

internal interface ICheckAliasedModel<TName>
  : ICheckDescribedModel<TName>
{
  AstAliased AliasedAst(TName name);
  IRendering ToModel(AstAliased aliased);
  string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<TName> input);
}

internal record struct ExpectedDescriptionAliasesInput<TName>(
  TName Name,
  IEnumerable<string>? Aliases = null,
  IEnumerable<string>? Description = null)
{
  public ExpectedDescriptionAliasesInput(ExpectedDescriptionInput<TName> input)
    : this(input.Name, Description: input.Description)
  { }
}
