namespace GqlPlus.Modelling;

internal abstract class ModellerObject<TAst, TObjFieldAst, TModel, TObjField>(
  TypeKindModel kind,
  IModellerRepository modellers
) : ModellerType<TAst, IAstObjBase, TModel>(kind)
  where TAst : class, IAstType<IAstObjBase>
  where TObjFieldAst : class, IAstObjField
  where TModel : BaseTypeModel
  where TObjField : class, IObjFieldModel
{
  private readonly Modeller<IAstAlternate, AlternateModel> _alternate = modellers.ModellerFor<IAstAlternate, AlternateModel>();
  private readonly Modeller<TObjFieldAst, TObjField> _field = modellers.ModellerFor<TObjFieldAst, TObjField>();
  private readonly Modeller<IAstTypeParam, TypeParamModel> _typeParams = modellers.ModellerFor<IAstTypeParam, TypeParamModel>();
  private readonly Modeller<IAstObjBase, ObjBaseModel> _base = modellers.ModellerFor<IAstObjBase, ObjBaseModel>();

  internal ObjBaseModel? ParentModel(IAstObjBase? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? default : BaseModel(parent, typeKinds);

  internal AlternateModel[] AlternatesModels(IEnumerable<IAstAlternate> alternates, IMap<TypeKindModel> typeKinds)
    => _alternate.ToModels(alternates, typeKinds);

  internal TObjField[] FieldsModels(IEnumerable<TObjFieldAst> fields, IMap<TypeKindModel> typeKinds)
    => _field.ToModels(fields, typeKinds);

  internal TypeParamModel[] TypeParamsModels(IEnumerable<IAstTypeParam> typeParams, IMap<TypeKindModel> typeKinds)
    => _typeParams.ToModels(typeParams, typeKinds);

  protected ObjBaseModel BaseModel(IAstObjBase ast, IMap<TypeKindModel> typeKinds)
    => _base.ToModel<ObjBaseModel>(ast, typeKinds);
}
