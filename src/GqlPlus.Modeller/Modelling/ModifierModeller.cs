using GqlPlus.Ast;

namespace GqlPlus.Modelling;

internal class ModifierModeller
  : ModellerBase<IAstModifier, ModifierModel>
  , IModifierModeller
{
  protected override ModifierModel ToModel(IAstModifier ast, IMap<TypeKindModel> typeKinds)
    => new(ast.ModifierKind) {
      Key = ast.Key,
      KeyType = !string.IsNullOrWhiteSpace(ast.Key)
          && typeKinds.TryGetValue(ast.Key, out TypeKindModel keyType)
          && keyType < TypeKindModel.LastSimple
        ? (SimpleKindModel)keyType : null,
      IsOptional = ast.IsOptional,
    };

  protected override T? TryModel<T>(IAstModifier? ast, IMap<TypeKindModel> typeKinds)
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

  CollectionModel? IModeller<IAstModifier, CollectionModel>.TryModel(IAstModifier? ast, IMap<TypeKindModel> typeKinds)
    => TryModel<CollectionModel>(ast, typeKinds);
  CollectionModel IModeller<IAstModifier, CollectionModel>.ToModel(IAstModifier? ast, IMap<TypeKindModel> typeKinds)
    => ToModel<CollectionModel>(ast, typeKinds);
  IEnumerable<CollectionModel?> IModeller<IAstModifier, CollectionModel>.TryModels(IEnumerable<IAstModifier>? asts, IMap<TypeKindModel> typeKinds)
    => TryModels<CollectionModel>(asts, typeKinds);
  CollectionModel[] IModeller<IAstModifier, CollectionModel>.ToModels(IEnumerable<IAstModifier>? asts, IMap<TypeKindModel> typeKinds)
    => ToModels<CollectionModel>(asts, typeKinds);
}

public interface IModifierModeller
  : IModeller<IAstModifier, ModifierModel>
  , IModeller<IAstModifier, CollectionModel>
{ }
