using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal abstract class ModelAliasedChecks<TInput, TAst>
  : ModelDescribedChecks<TInput, TAst>, IModelAliasedChecks<TInput>
  where TAst : AstAliased
{
  AstAliased IModelAliasedChecks<TInput>.AliasedAst(TInput input) => NewAst(input, "");
  IRendering IModelAliasedChecks<TInput>.ToModel(AstAliased aliased) => AstToModel((TAst)aliased);
}

internal interface IModelAliasedChecks<TInput> : IModelDescribedChecks<TInput>
{
  AstAliased AliasedAst(TInput input);
  IRendering ToModel(AstAliased aliased);
}
