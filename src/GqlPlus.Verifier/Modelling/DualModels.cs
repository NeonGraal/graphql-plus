using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class TypeDualModel(
  string Name
) : TypeObjectModel<DualBaseModel, DualFieldModel>(TypeKindModel.Dual, Name)
{
  internal override string? ParentName => Parent?.Base.Dual;
}

public record class DualBaseModel(
  string Dual
) : ObjBaseModel<ObjRefModel<DualBaseModel>>
{
  internal override RenderStructure Render(IRenderContext context)
    => IsTypeParameter
    ? new(Dual)
    : base.Render(context)
      .Add("dual", Dual);
}

public record class DualFieldModel(
  string Name,
  ObjRefModel<DualBaseModel> Type
) : FieldModel<DualBaseModel>(Name, Type)
{ }

internal class DualModeller(
  IAlternateModeller<DualReferenceAst, DualBaseModel> alternate,
  IModeller<DualFieldAst, DualFieldModel> field,
  IModeller<DualReferenceAst, DualBaseModel> reference
) : ModellerObject<DualDeclAst, DualReferenceAst, DualFieldAst, TypeDualModel, DualBaseModel, DualFieldModel>(TypeKindModel.Dual, alternate, field, reference)
{
  protected override TypeDualModel ToModel(DualDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class DualReferenceModeller
  : ModellerReference<DualReferenceAst, DualBaseModel>
{
  protected override DualBaseModel ToModel(DualReferenceAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      IsTypeParameter = ast.IsTypeParameter,
      Arguments = ModelArguments(ast, typeKinds),
    };
}

internal class DualFieldModeller(
  IModifierModeller modifier,
  IModeller<DualReferenceAst, DualBaseModel> reference
) : ModellerBase<DualFieldAst, DualFieldModel>
{
  protected override DualFieldModel ToModel(DualFieldAst field, IMap<TypeKindModel> typeKinds)
    => new(field.Name, new(reference.ToModel(field.Type, typeKinds))) {
      Modifiers = modifier.ToModels<ModifierModel>(field.Modifiers, typeKinds),
    };
}
