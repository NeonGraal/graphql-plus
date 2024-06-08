namespace GqlPlus.Modelling.Objects;

internal class DualBaseModeller
  : ModellerObjBase<IGqlpDualBase, DualBaseModel>
{
  protected override DualBaseModel ToModel(IGqlpDualBase ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Dual) {
      IsTypeParameter = ast.IsTypeParameter,
      TypeArguments = ModelArguments(ast, typeKinds),
    };
}
