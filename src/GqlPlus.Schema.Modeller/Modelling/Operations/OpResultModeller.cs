using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

internal class OpResultModeller
  : ModellerBase<IAstTypeRef, OpResultModel>
{
  protected override OpResultModel ToModel(IAstTypeRef ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name.TypeRef(TypeKindModel.Output));

  internal static OpResultModeller Factory(IModellerRepository _) => new();
}
