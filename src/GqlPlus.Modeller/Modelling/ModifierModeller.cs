namespace GqlPlus.Modelling;

internal class ModifierModeller
  : ModellerBase<IGqlpModifier, ModifierModel>
  , IModifierModeller
{
  protected override ModifierModel ToModel(IGqlpModifier ast, IMap<TypeKindModel> typeKinds)
    => new(ast.ModifierKind) {
      Key = ast.Key,
      KeyType = !string.IsNullOrWhiteSpace(ast.Key)
          && typeKinds.TryGetValue(ast.Key!, out TypeKindModel keyType)
          && keyType < TypeKindModel.LastSimple
        ? (SimpleKindModel)keyType : null,
      IsOptional = ast.IsOptional,
    };

  protected override T? TryModel<T>(IGqlpModifier? ast, IMap<TypeKindModel> typeKinds)
    where T : default
  {
    if (typeof(T).Equals(typeof(CollectionModel))) {
      if (ast is not null && ast.ModifierKind != ModifierKind.Optional) {
        return (T?)(object)ToModel(ast, typeKinds);
      }

      return default;
    } else {
      return base.TryModel<T>(ast, typeKinds);
    }
  }

  CollectionModel? IModeller<IGqlpModifier, CollectionModel>.TryModel(IGqlpModifier? ast, IMap<TypeKindModel> typeKinds)
    => TryModel<CollectionModel>(ast, typeKinds);
  CollectionModel IModeller<IGqlpModifier, CollectionModel>.ToModel(IGqlpModifier? ast, IMap<TypeKindModel> typeKinds)
    => ToModel<CollectionModel>(ast, typeKinds);
  IEnumerable<CollectionModel?> IModeller<IGqlpModifier, CollectionModel>.TryModels(IEnumerable<IGqlpModifier>? asts, IMap<TypeKindModel> typeKinds)
    => TryModels<CollectionModel>(asts, typeKinds);
  CollectionModel[] IModeller<IGqlpModifier, CollectionModel>.ToModels(IEnumerable<IGqlpModifier>? asts, IMap<TypeKindModel> typeKinds)
    => ToModels<CollectionModel>(asts, typeKinds);
}

public interface IModifierModeller
  : IModeller<IGqlpModifier, ModifierModel>
  , IModeller<IGqlpModifier, CollectionModel>
{ }
