using GqlPlus.Ast;

namespace GqlPlus.Modelling;

internal class ConstantModeller(
  IModeller<IAstFieldKey, SimpleModel> value
) : ModellerBase<IAstConstant, ConstantModel>
{
  protected override ConstantModel ToModel(IAstConstant ast, IMap<TypeKindModel> typeKinds)
    => ast.Fields.Count > 0 ? new(ToModel(ast.Fields, typeKinds))
    : ast.Values.Any() ? new(ast.Values.Select(v => ToModel(v, typeKinds)))
    : ast.Value is not null ? new(value.ToModel(ast.Value, typeKinds))
    : new(new SimpleModel(""));

  private Dictionary<SimpleModel, ConstantModel> ToModel(IAstFields<IAstConstant> constant, IMap<TypeKindModel> typeKinds)
    => constant.ToDictionary(
      p => value.ToModel(p.Key, typeKinds),
      p => ToModel(p.Value, typeKinds));
}
