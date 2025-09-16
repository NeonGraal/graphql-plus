namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObject<TAst, TObjBaseAst, TObjFieldAst, TObjAltAst, TModel, TObjField>(
  TypeKindModel kind,
  ObjectModellers<TObjBaseAst, TObjFieldAst, TObjAltAst, TObjField> modellers
) : ModellerType<TAst, IGqlpObjBase, TModel>(kind)
  where TAst : IGqlpType<IGqlpObjBase>
  where TObjBaseAst : IGqlpObjBase
  where TObjFieldAst : IGqlpObjField
  where TObjAltAst : IGqlpObjAlternate
  where TModel : BaseTypeModel
  where TObjField : IObjFieldModel
{
  internal ObjBaseModel? ParentModel(TObjBaseAst? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? default : BaseModel(parent, typeKinds);

  internal ObjAlternateModel[] AlternatesModels(IEnumerable<TObjAltAst> alternates, IMap<TypeKindModel> typeKinds)
    => modellers.Alternate.ToModels(alternates, typeKinds);

  internal TObjField[] FieldsModels(IEnumerable<TObjFieldAst> fields, IMap<TypeKindModel> typeKinds)
    => modellers.Field.ToModels(fields, typeKinds);

  internal TypeParamModel[] TypeParamsModels(IEnumerable<IGqlpTypeParam> typeParams, IMap<TypeKindModel> typeKinds)
    => modellers.TypeParams.ToModels(typeParams, typeKinds);

  protected ObjBaseModel BaseModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => modellers.Base.ToModel<ObjBaseModel>(ast, typeKinds);
}

internal record class ObjectModellers<TObjBaseAst, TObjFieldAst, TObjAltAst, TObjField>(
  IModeller<IGqlpTypeParam, TypeParamModel> TypeParams,
  IModeller<TObjAltAst, ObjAlternateModel> Alternate,
  IModeller<TObjFieldAst, TObjField> Field,
  IModeller<TObjBaseAst, ObjBaseModel> Base
) where TObjBaseAst : IGqlpObjBase
  where TObjFieldAst : IGqlpObjField
  where TObjAltAst : IGqlpObjAlternate
  where TObjField : IObjFieldModel;
