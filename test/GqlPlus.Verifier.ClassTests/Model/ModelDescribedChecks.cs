using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

internal abstract class ModelDescribedChecks<TInput, TAst>
  : ModelBaseChecks, IModelDescribedChecks<TInput>
  where TAst : AstDescribed
{
  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);

  protected abstract TAst NewAst(TInput input);
  protected abstract IRendering AstToModel(TAst ast);

  AstDescribed IModelDescribedChecks<TInput>.DescribedAst(TInput input) => NewAst(input);
  IRendering IModelDescribedChecks<TInput>.ToModel(AstDescribed ast) => AstToModel((TAst)ast);
}

internal interface IModelDescribedChecks<TInput> : IModelBaseChecks
{
  AstDescribed DescribedAst(TInput input);
  IRendering ToModel(AstDescribed ast);
}
