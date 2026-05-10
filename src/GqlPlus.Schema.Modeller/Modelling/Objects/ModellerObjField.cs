namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjField<TObjFieldAst, TObjField>(
  IModellerRepository modellers
) : ModellerBase<TObjFieldAst, TObjField>
  where TObjFieldAst : IAstObjField
  where TObjField : ObjFieldModel
{
  private readonly Defer<IModifierModeller>.L _modifier = modellers.ModifierModeller();
  private readonly Defer<IModeller<IAstObjBase, ObjBaseModel>>.L _objBase = modellers.ModellerFor<IAstObjBase, ObjBaseModel>();

  protected override TObjField ToModel(TObjFieldAst field, IMap<TypeKindModel> typeKinds)
    => FieldModel(field, _objBase.I.ToModel(field.Type, typeKinds), typeKinds) with {
      Aliases = [.. field.Aliases],
      Modifiers = _modifier.I.ToModels<ModifierModel>(field.Modifiers, typeKinds),
    };

  protected abstract TObjField FieldModel(TObjFieldAst ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds);
}
