namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObject<TAst, TObjFieldAst, TModel, TObjField>(
  TypeKindModel kind,
  ObjectModellers<TObjFieldAst, TObjField> modellers
) : ModellerType<TAst, IGqlpObjBase, TModel>(kind)
  where TAst : IGqlpType<IGqlpObjBase>
  where TObjFieldAst : IGqlpObjField
  where TModel : BaseTypeModel
  where TObjField : IObjFieldModel
{
  internal ObjBaseModel? ParentModel(IGqlpObjBase? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? default : BaseModel(parent, typeKinds);

  internal AlternateModel[] AlternatesModels(IEnumerable<IGqlpAlternate> alternates, IMap<TypeKindModel> typeKinds)
    => modellers.Alternate.ToModels(alternates, typeKinds);

  internal TObjField[] FieldsModels(IEnumerable<TObjFieldAst> fields, IMap<TypeKindModel> typeKinds)
    => modellers.Field.ToModels(fields, typeKinds);

  internal TypeParamModel[] TypeParamsModels(IEnumerable<IGqlpTypeParam> typeParams, IMap<TypeKindModel> typeKinds)
    => modellers.TypeParams.ToModels(typeParams, typeKinds);

  protected ObjBaseModel BaseModel(IGqlpObjBase ast, IMap<TypeKindModel> typeKinds)
    => modellers.Base.ToModel<ObjBaseModel>(ast, typeKinds);
}

internal record class ObjectModellers<TObjFieldAst, TObjField>(
  IModeller<IGqlpTypeParam, TypeParamModel> TypeParams,
  IModeller<IGqlpAlternate, AlternateModel> Alternate,
  IModeller<TObjFieldAst, TObjField> Field,
  IModeller<IGqlpObjBase, ObjBaseModel> Base)
  where TObjFieldAst : IGqlpObjField
  where TObjField : IObjFieldModel;
