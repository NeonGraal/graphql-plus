using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

internal class OpDirectiveModeller
  : ModellerBase<IAstDirective, OpDirectiveModel>
{
  protected override OpDirectiveModel ToModel(IAstDirective ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Identifier, "");

  internal static OpDirectiveModeller Factory(IModellerRepository _) => new();
}
