using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjField<TObjFieldAst, TObjField>(
  IModifierModeller modifier,
  IModeller<IAstObjBase, ObjBaseModel> objBase
) : ModellerBase<TObjFieldAst, TObjField>
  where TObjFieldAst : IAstObjField
  where TObjField : ObjFieldModel
{
  protected override TObjField ToModel(TObjFieldAst field, IMap<TypeKindModel> typeKinds)
    => FieldModel(field, objBase.ToModel(field.Type, typeKinds), typeKinds) with {
      Aliases = [.. field.Aliases],
      Modifiers = modifier.ToModels<ModifierModel>(field.Modifiers, typeKinds),
    };

  protected abstract TObjField FieldModel(TObjFieldAst ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds);
}
