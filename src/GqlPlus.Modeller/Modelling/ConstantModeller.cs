namespace GqlPlus.Modelling;

internal class ConstantModeller(
  IModeller<IGqlpFieldKey, SimpleModel> value
) : ModellerBase<IGqlpConstant, ConstantModel>
{
  protected override ConstantModel ToModel(IGqlpConstant ast, IMap<TypeKindModel> typeKinds)
    => ast.Fields.Count > 0 ? new(ToModel(ast.Fields, typeKinds))
    : ast.Values.Any() ? new(ast.Values.Select(v => ToModel(v, typeKinds)))
    : ast.Value is not null ? new(value.ToModel(ast.Value, typeKinds))
    : new(new SimpleModel());

  private Dictionary<SimpleModel, ConstantModel> ToModel(IGqlpFields<IGqlpConstant> constant, IMap<TypeKindModel> typeKinds)
    => constant.ToDictionary(
      p => value.ToModel(p.Key, typeKinds),
      p => ToModel(p.Value, typeKinds));
}
