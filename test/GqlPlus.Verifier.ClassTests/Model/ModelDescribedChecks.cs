using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

internal abstract class ModelDescribedChecks<TAst>
  : ModelBaseChecks, IModelDescribedChecks
  where TAst : AstDescribed
{
  protected abstract TAst NewAst(string input);
  protected abstract IRendering AstToModel(TAst aliased);

  AstDescribed IModelDescribedChecks.DescribedAst(string input) => NewAst(input);
  IRendering IModelDescribedChecks.ToModel(AstDescribed aliased) => AstToModel((TAst)aliased);
}

internal interface IModelDescribedChecks : IModelBaseChecks
{
  AstDescribed DescribedAst(string input);
  IRendering ToModel(AstDescribed aliased);
}
