namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjField<TObjBaseAst, TObjFieldAst, TObjField>(
  IModifierModeller modifier,
  IModeller<TObjBaseAst, ObjBaseModel> objBase
) : ModellerBase<TObjFieldAst, TObjField>
  where TObjBaseAst : IGqlpObjBase
  where TObjFieldAst : IGqlpObjField<TObjBaseAst>
  where TObjField : ObjFieldModel
{
  protected override TObjField ToModel(TObjFieldAst field, IMap<TypeKindModel> typeKinds)
    => FieldModel(field, objBase.ToModel(field.BaseType, typeKinds), typeKinds) with {
      Aliases = [.. field.Aliases],
      Modifiers = modifier.ToModels<ModifierModel>(field.Modifiers, typeKinds),
    };

  protected abstract TObjField FieldModel(TObjFieldAst ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds);
}
