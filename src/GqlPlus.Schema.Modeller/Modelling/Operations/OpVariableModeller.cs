using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

internal class OpVariableModeller
  : ModellerBase<IAstVariable, OpVariableModel>
{
  protected override OpVariableModel ToModel(IAstVariable ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Identifier, ast.Type.TypeRef(TypeKindModel.Input), null, "");

  internal static OpVariableModeller Factory(IModellerRepository _) => new();
}
