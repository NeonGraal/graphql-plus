namespace GqlPlus.Modelling.Objects;

internal class AlternateModeller(
  IModellerRepository modellers
) : ModellerBase<IAstAlternate, AlternateModel>
{
  private readonly DeferOne<IModeller<IAstModifier, CollectionModel>> _collection = modellers.ModellerFor<IAstModifier, CollectionModel>();
  private readonly DeferOne<IModeller<IAstObjBase, ObjBaseModel>> _objBase = modellers.ModellerFor<IAstObjBase, ObjBaseModel>();

  protected override AlternateModel ToModel(IAstAlternate ast, IMap<TypeKindModel> typeKinds)
  {
    CollectionModel[] collections = _collection.I.ToModels(ast.Modifiers, typeKinds);
    ObjBaseModel baseModel = _objBase.I.ToModel(ast, typeKinds);
    AlternateModel result = new(baseModel) {
      Collections = collections
    };
    return result;
  }

  internal static AlternateModeller Factory(IModellerRepository r) => new(r);
}
