namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjField<TObjBaseAst, TObjFieldAst, TObjBase, TObjField>(
  IModifierModeller modifier,
  IModeller<TObjBaseAst, TObjBase> objBase
) : ModellerBase<TObjFieldAst, TObjField>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>
  where TObjFieldAst : IGqlpObjectField<TObjBaseAst>
  where TObjBase : IObjBaseModel
  where TObjField : ObjFieldModel<TObjBase>
{
  protected override TObjField ToModel(TObjFieldAst field, IMap<TypeKindModel> typeKinds)
    => FieldModel(field, objBase.ToModel(field.Type, typeKinds), typeKinds) with {
      Aliases = [.. field.Aliases],
      Modifiers = modifier.ToModels<ModifierModel>(field.Modifiers, typeKinds),
    };

  protected abstract TObjField FieldModel(TObjFieldAst ast, TObjBase type, IMap<TypeKindModel> typeKinds);
}
