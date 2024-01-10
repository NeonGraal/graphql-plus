using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal abstract class ModelAliasedChecks<TAst> : ModelBaseChecks, IModelAliasedChecks
  where TAst : AstAliased
{
  protected abstract TAst NewAliasedAst(string input);
  protected abstract IRendering AstToModel(TAst aliased);

  AstAliased IModelAliasedChecks.AliasedAst(string input) => NewAliasedAst(input);
  IRendering IModelAliasedChecks.ToModel(AstAliased aliased) => AstToModel((TAst)aliased);
}

internal interface IModelAliasedChecks : IModelBaseChecks
{
  AstAliased AliasedAst(string input);
  IRendering ToModel(AstAliased aliased);
}
