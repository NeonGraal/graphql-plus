using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal abstract class ModelAliasedChecks<TAst>
  : ModelDescribedChecks<TAst>, IModelAliasedChecks
  where TAst : AstAliased
{
  AstAliased IModelAliasedChecks.AliasedAst(string input) => NewAst(input);
  IRendering IModelAliasedChecks.ToModel(AstAliased aliased) => AstToModel((TAst)aliased);
}

internal interface IModelAliasedChecks : IModelDescribedChecks
{
  AstAliased AliasedAst(string input);
  IRendering ToModel(AstAliased aliased);
}
