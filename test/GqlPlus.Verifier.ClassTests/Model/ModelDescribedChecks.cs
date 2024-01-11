using AutoFixture;
using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

internal abstract class ModelDescribedChecks<TInput, TAst>
  : ModelBaseChecks, IModelDescribedChecks<TInput>
  where TAst : IAstDescribed
{
  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);

  protected abstract TAst NewAst(TInput input, string description);
  protected abstract IRendering AstToModel(TAst ast);

  IAstDescribed IModelDescribedChecks<TInput>.DescribedAst(TInput input, string description) => NewAst(input, description);
  IRendering IModelDescribedChecks<TInput>.ToModel(IAstDescribed ast) => AstToModel((TAst)ast);
}

internal interface IModelDescribedChecks<TInput> : IModelBaseChecks
{
  IAstDescribed DescribedAst(TInput input, string description);
  IRendering ToModel(IAstDescribed ast);
}
