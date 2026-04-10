namespace GqlPlus.Modelling.Objects;

internal class AlternateModeller(
  IModeller<IAstModifier, CollectionModel> collection,
  IModeller<IAstObjBase, ObjBaseModel> objBase
) : ModellerBase<IAstAlternate, AlternateModel>
{
  protected override AlternateModel ToModel(IAstAlternate ast, IMap<TypeKindModel> typeKinds)
  {
    CollectionModel[] collections = collection.ToModels(ast.Modifiers, typeKinds);
    ObjBaseModel baseModel = objBase.ToModel(ast, typeKinds);
    AlternateModel result = new(baseModel) {
      Collections = collections
    };
    return result;
  }
}
