using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

internal class OpFragmentModeller
  : ModellerBase<IAstFragment, OpFragmentModel>
{
  protected override OpFragmentModel ToModel(IAstFragment ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Identifier, ast.OnType.TypeRef(TypeKindModel.Output), "");

  internal static OpFragmentModeller Factory(IModellerRepository _) => new();
}
