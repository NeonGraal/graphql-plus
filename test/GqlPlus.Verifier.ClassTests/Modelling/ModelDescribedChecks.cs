using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Modelling;

internal abstract class ModelDescribedChecks<TInput, TAst>
  : ModelBaseChecks<TInput, TAst>, IModelDescribedChecks<TInput>
  where TAst : AstAbbreviated, IAstDescribed
{
  protected abstract TAst NewDescribedAst(TInput input, string description);

  protected override TAst NewBaseAst(TInput input) => NewDescribedAst(input, "");

  AstAbbreviated IModelDescribedChecks<TInput>.DescribedAst(TInput input, string description) => NewDescribedAst(input, description);
}

internal interface IModelDescribedChecks<TInput> : IModelBaseChecks<TInput>
{
  AstAbbreviated DescribedAst(TInput input, string description);
}
