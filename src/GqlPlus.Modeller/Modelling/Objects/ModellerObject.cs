namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObject<TAst, TObjBaseAst, TObjFieldAst, TObjAltAst, TModel, TObjBase, TObjField, TObjAlt>(
  TypeKindModel kind,
  IModeller<TObjAltAst, TObjAlt> alternate,
  IModeller<TObjFieldAst, TObjField> objField,
  IModeller<TObjBaseAst, TObjBase> objBase
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
  internal ObjDescribedModel<TObjBase>? ParentModel(TObjBaseAst? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? null : new(BaseModel(parent, typeKinds), parent.Description);

  internal TObjAlt[] AlternatesModels(IEnumerable<TObjAltAst> alternates, IMap<TypeKindModel> typeKinds)
    => alternate.ToModels(alternates, typeKinds);

  internal TObjField[] FieldsModels(IEnumerable<TObjFieldAst> fields, IMap<TypeKindModel> typeKinds)
    => objField.ToModels(fields, typeKinds);

  internal DescribedModel[] TypeParametersModels(IEnumerable<IGqlpTypeParameter> typeParameters)
    => [.. typeParameters.Select(p => new DescribedModel(p.Name) { Description = p.Description })];

  protected TObjBase BaseModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => objBase.ToModel<TObjBase>(ast, typeKinds);
}
