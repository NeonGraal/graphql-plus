namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObject<TAst, TObjBaseAst, TObjFieldAst, TObjAltAst, TModel, TObjBase, TObjField, TObjAlt>(
  TypeKindModel kind,
  ObjectModellers<TObjBaseAst, TObjFieldAst, TObjAltAst, TObjBase, TObjField, TObjAlt> modellers
) : ModellerType<TAst, IGqlpObjBase, TModel>(kind)
  where TAst : IGqlpType<IGqlpObjBase>
  where TObjBaseAst : IGqlpObjBase
  where TObjFieldAst : IGqlpObjField
  where TObjAltAst : IGqlpObjAlternate
  where TModel : BaseTypeModel
  where TObjBase : IObjBaseModel
  where TObjField : IObjFieldModel
  where TObjAlt : IObjAlternateModel
{
  internal TObjBase? ParentModel(TObjBaseAst? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? default : BaseModel(parent, typeKinds);

  internal TObjAlt[] AlternatesModels(IEnumerable<TObjAltAst> alternates, IMap<TypeKindModel> typeKinds)
    => modellers.Alternate.ToModels(alternates, typeKinds);

  internal TObjField[] FieldsModels(IEnumerable<TObjFieldAst> fields, IMap<TypeKindModel> typeKinds)
    => modellers.Field.ToModels(fields, typeKinds);

  internal TypeParamModel[] TypeParamsModels(IEnumerable<IGqlpTypeParam> typeParams, IMap<TypeKindModel> typeKinds)
    => modellers.TypeParams.ToModels(typeParams, typeKinds);

  protected TObjBase BaseModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => modellers.Base.ToModel<TObjBase>(ast, typeKinds);
}

internal record class ObjectModellers<TObjBaseAst, TObjFieldAst, TObjAltAst, TObjBase, TObjField, TObjAlt>(
  IModeller<IGqlpTypeParam, TypeParamModel> TypeParams,
  IModeller<TObjAltAst, TObjAlt> Alternate,
  IModeller<TObjFieldAst, TObjField> Field,
  IModeller<TObjBaseAst, TObjBase> Base
) where TObjBaseAst : IGqlpObjBase
  where TObjFieldAst : IGqlpObjField
  where TObjAltAst : IGqlpObjAlternate
  where TObjBase : IObjBaseModel
  where TObjField : IObjFieldModel
  where TObjAlt : IObjAlternateModel;
