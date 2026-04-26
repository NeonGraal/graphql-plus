namespace GqlPlus.Modelling.Objects;

internal class AlternateModeller(
  IModellerRepository modellers
) : ModellerBase<IAstAlternate, AlternateModel>
{
  private readonly IModeller<IAstModifier, CollectionModel> _collection = modellers.ModellerFor<IAstModifier, CollectionModel>();
  private readonly IModeller<IAstObjBase, ObjBaseModel> _objBase = modellers.ModellerFor<IAstObjBase, ObjBaseModel>();

  protected override AlternateModel ToModel(IAstAlternate ast, IMap<TypeKindModel> typeKinds)
  {
    CollectionModel[] collections = _collection.ToModels(ast.Modifiers, typeKinds);
    ObjBaseModel baseModel = _objBase.ToModel(ast, typeKinds);
    AlternateModel result = new(baseModel) {
      Collections = collections
    };
    return result;
  }

  internal static AlternateModeller Factory(IModellerRepository r) => new(r);
}
