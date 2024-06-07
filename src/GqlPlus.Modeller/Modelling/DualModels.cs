using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public record class TypeDualModel(
  string Name
) : TypeObjectModel<DualBaseModel, DualFieldModel>(TypeKindModel.Dual, Name)
{
  protected override string BaseName(DualBaseModel? objBase)
    => objBase?.Dual ?? "";

  protected override DualFieldModel NewField(DualFieldModel field, DualBaseModel typeModel, ModifierModel[] modifiers)
    => new(field.ThrowIfNull().Name, typeModel) {
      Aliases = field.Aliases,
      Description = field.Description,
      Modifiers = modifiers,
    };
}

public record class DualBaseModel(
  string Dual
) : ObjBaseModel<DualBaseModel>
{
  internal override RenderStructure Render(IRenderContext context)
    => IsTypeParameter
    ? new(Dual, "_TypeParameter")
    : base.Render(context)
      .Add("dual", Dual);
}

public record class DualFieldModel(
  string Name,
  DualBaseModel Type
) : ObjFieldModel<DualBaseModel>(Name, Type)
{ }

internal class DualModeller(
  IAlternateModeller<IGqlpDualBase, DualBaseModel> alternate,
  IModeller<IGqlpDualField, DualFieldModel> objField,
  IModeller<IGqlpDualBase, DualBaseModel> objBase
) : ModellerObject<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, TypeDualModel, DualBaseModel, DualFieldModel>(TypeKindModel.Dual, alternate, objField, objBase)
{
  protected override TypeDualModel ToModel(IGqlpDualObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class DualBaseModeller
  : ModellerObjBase<IGqlpDualBase, DualBaseModel>
{
  protected override DualBaseModel ToModel(IGqlpDualBase ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Dual) {
      IsTypeParameter = ast.IsTypeParameter,
      TypeArguments = ModelArguments(ast, typeKinds),
    };
}

internal class DualFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpDualBase, DualBaseModel> objBase
) : ModellerObjField<IGqlpDualBase, IGqlpDualField, DualBaseModel, DualFieldModel>(modifier, objBase)
{
  protected override DualFieldModel FieldModel(IGqlpDualField ast, DualBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type);
}
