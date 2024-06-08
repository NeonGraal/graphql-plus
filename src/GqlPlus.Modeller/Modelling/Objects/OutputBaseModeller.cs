namespace GqlPlus.Modelling.Objects;

internal class OutputBaseModeller(
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpOutputBase, OutputBaseModel, OutputArgumentModel>
{
  internal override OutputArgumentModel NewArgument(IGqlpOutputBase ast, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(ast.EnumMember)
      ? new(ast.Output) { Ref = ToModel(ast, typeKinds) }
      : new(ast.Output) { EnumMember = ast.EnumMember };

  protected override OutputBaseModel ToModel(IGqlpOutputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Output, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new(ast.Output) {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Output) {
      IsTypeParameter = ast.IsTypeParameter,
      TypeArguments = ModelArguments(ast, typeKinds),
    };
}
