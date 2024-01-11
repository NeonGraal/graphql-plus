using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

internal abstract class ModelDescribedChecks<TInput, TAst>
  : ModelBaseChecks<TInput, TAst>, IModelDescribedChecks<TInput>
  where TAst : AstBase, IAstDescribed
{
  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);

  protected abstract TAst NewDescribedAst(TInput input, string description);

  protected override TAst NewBaseAst(TInput input) => NewDescribedAst(input, "");

  AstBase IModelDescribedChecks<TInput>.DescribedAst(TInput input, string description) => NewDescribedAst(input, description);
}

internal interface IModelDescribedChecks<TInput> : IModelBaseChecks<TInput>
{
  AstBase DescribedAst(TInput input, string description);
}
