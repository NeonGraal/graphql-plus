using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public record class TypeDualModel(
  string Name
) : TypeObjectModel<DualBaseModel, DualFieldModel>(TypeKindModel.Dual, Name)
{
  protected override string? ParentName(BaseDescribedModel<DualBaseModel>? parent)
    => parent?.Base.Dual;
}

public record class DualBaseModel(
  string Dual
) : ObjBaseModel<ObjRefModel<DualBaseModel>>
{
  internal override RenderStructure Render(IRenderContext context)
    => IsTypeParameter
    ? new(Dual, "_TypeParameter")
    : base.Render(context)
      .Add("dual", Dual);
}

public record class DualFieldModel(
  string Name,
  ObjRefModel<DualBaseModel> Type
) : ObjFieldModel<DualBaseModel>(Name, Type)
{ }

internal class DualModeller(
  IAlternateModeller<DualBaseAst, DualBaseModel> alternate,
  IModeller<DualFieldAst, DualFieldModel> objField,
  IModeller<DualBaseAst, DualBaseModel> objBase
) : ModellerObject<DualDeclAst, DualBaseAst, DualFieldAst, TypeDualModel, DualBaseModel, DualFieldModel>(TypeKindModel.Dual, alternate, objField, objBase)
{
  protected override TypeDualModel ToModel(DualDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class DualBaseModeller
  : ModellerObjBase<DualBaseAst, DualBaseModel>
{
  protected override DualBaseModel ToModel(DualBaseAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      IsTypeParameter = ast.IsTypeParameter,
      Arguments = ModelArguments(ast, typeKinds),
    };
}

internal class DualFieldModeller(
  IModifierModeller modifier,
  IModeller<DualBaseAst, DualBaseModel> refBase
) : ModellerObjField<DualBaseAst, DualFieldAst, DualBaseModel, DualFieldModel>(modifier, refBase)
{
  protected override DualFieldModel FieldModel(DualFieldAst ast, ObjRefModel<DualBaseModel> type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type);
}
