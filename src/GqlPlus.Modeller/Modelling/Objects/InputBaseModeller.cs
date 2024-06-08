namespace GqlPlus.Modelling.Objects;

internal class InputBaseModeller(
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpInputBase, InputBaseModel>
{
  protected override InputBaseModel ToModel(IGqlpInputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Input, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new(ast.Input) {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Input) {
      IsTypeParameter = ast.IsTypeParameter,
      TypeArguments = ModelArguments(ast, typeKinds),
    };
}
