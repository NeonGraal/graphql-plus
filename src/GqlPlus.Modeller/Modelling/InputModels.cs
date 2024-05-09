using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public record class TypeInputModel(
  string Name
) : TypeObjectModel<InputBaseModel, InputFieldModel>(TypeKindModel.Input, Name)
{
  protected override string? ParentName(BaseDescribedModel<InputBaseModel>? parent)
    => parent?.Base.Input;
}

public record class InputBaseModel(
  string Input
) : ObjBaseModel<ObjRefModel<InputBaseModel>>
{
  internal DualBaseModel? Dual { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => Dual is null
    ? IsTypeParameter
      ? new(Input, "_TypeParameter")
      : base.Render(context)
        .Add("input", Input)
    : Dual.Render(context);
}

public record class InputFieldModel(
  string Name,
  ObjRefModel<InputBaseModel> Type
) : ObjFieldModel<InputBaseModel>(Name, Type)
{
  internal ConstantModel? Default { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("default", Default?.Render(context));
}

internal class InputModeller(
  IAlternateModeller<InputBaseAst, InputBaseModel> alternate,
  IModeller<InputFieldAst, InputFieldModel> objField,
  IModeller<InputBaseAst, InputBaseModel> objBase
) : ModellerObject<InputDeclAst, InputBaseAst, InputFieldAst, TypeInputModel, InputBaseModel, InputFieldModel>(TypeKindModel.Input, alternate, objField, objBase)
{
  protected override TypeInputModel ToModel(InputDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class InputBaseModeller(
  IModeller<DualBaseAst, DualBaseModel> dual
) : ModellerObjBase<InputBaseAst, InputBaseModel>
{
  protected override InputBaseModel ToModel(InputBaseAst ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Name, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new(ast.Name) {
      Dual = dual.ToModel(ast.ToDual(), typeKinds)
    }
    : new(ast.Name) {
      IsTypeParameter = ast.IsTypeParameter,
      Arguments = ModelArguments(ast, typeKinds),
    };
}

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<InputBaseAst, InputBaseModel> refBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerObjField<InputBaseAst, InputFieldAst, InputBaseModel, InputFieldModel>(modifier, refBase)
{
  protected override InputFieldModel FieldModel(InputFieldAst ast, ObjRefModel<InputBaseModel> type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type) {
      Default = constant.TryModel(ast.Default, typeKinds),
    };
}
