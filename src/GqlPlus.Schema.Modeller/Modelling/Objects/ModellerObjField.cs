namespace GqlPlus.Modelling;

internal abstract class ModellerObjField<TObjFieldAst, TObjField>(
  IModellerRepository modellers
) : ModellerBase<TObjFieldAst, TObjField>
  where TObjFieldAst : class, IAstObjField
  where TObjField : ObjFieldModel
{
  private readonly DeferOne<IModifierModeller> _modifier = modellers.ModifierModeller();
  private readonly Modeller<IAstObjBase, ObjBaseModel> _objBase = modellers.ModellerFor<IAstObjBase, ObjBaseModel>();

  protected override TObjField ToModel(TObjFieldAst field, IMap<TypeKindModel> typeKinds)
    => FieldModel(field, _objBase.ToModel(field.Type, typeKinds), typeKinds) with {
      Aliases = [.. field.Aliases],
      Modifiers = _modifier.I.ToModels<ModifierModel>(field.Modifiers, typeKinds),
    };

  protected abstract TObjField FieldModel(TObjFieldAst ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds);
}
