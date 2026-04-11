namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObject<TAst, TObjFieldAst, TModel, TObjField>(
  TypeKindModel kind,
  ObjectModellers<TObjFieldAst, TObjField> modellers
) : ModellerType<TAst, IAstObjBase, TModel>(kind)
  where TAst : IAstType<IAstObjBase>
  where TObjFieldAst : IAstObjField
  where TModel : BaseTypeModel
  where TObjField : IObjFieldModel
{
  internal ObjBaseModel? ParentModel(IAstObjBase? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? default : BaseModel(parent, typeKinds);

  internal AlternateModel[] AlternatesModels(IEnumerable<IAstAlternate> alternates, IMap<TypeKindModel> typeKinds)
    => modellers.Alternate.ToModels(alternates, typeKinds);

  internal TObjField[] FieldsModels(IEnumerable<TObjFieldAst> fields, IMap<TypeKindModel> typeKinds)
    => modellers.Field.ToModels(fields, typeKinds);

  internal TypeParamModel[] TypeParamsModels(IEnumerable<IAstTypeParam> typeParams, IMap<TypeKindModel> typeKinds)
    => modellers.TypeParams.ToModels(typeParams, typeKinds);

  protected ObjBaseModel BaseModel(IAstObjBase ast, IMap<TypeKindModel> typeKinds)
    => modellers.Base.ToModel<ObjBaseModel>(ast, typeKinds);
}

internal record class ObjectModellers<TObjFieldAst, TObjField>(
  IModeller<IAstTypeParam, TypeParamModel> TypeParams,
  IModeller<IAstAlternate, AlternateModel> Alternate,
  IModeller<TObjFieldAst, TObjField> Field,
  IModeller<IAstObjBase, ObjBaseModel> Base)
  where TObjFieldAst : IAstObjField
  where TObjField : IObjFieldModel;
