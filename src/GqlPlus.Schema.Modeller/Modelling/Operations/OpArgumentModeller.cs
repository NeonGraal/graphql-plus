using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

internal class OpArgumentModeller
  : ModellerBase<IAstArg, OpArgumentModel>
{
  protected override OpArgumentModel ToModel(IAstArg ast, IMap<TypeKindModel> typeKinds)
    => new();

  internal static OpArgumentModeller Factory(IModellerRepository _) => new();
}
