using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class TypeInputModel(
  string Name
) : TypeObjectModel<InputBaseModel, InputFieldModel>(TypeKindModel.Input, Name)
{ }

public record class InputBaseModel(
  string Input
) : ObjBaseModel<ObjRefModel<InputBaseModel>>
{
  internal override RenderStructure Render(IRenderContext context)
    => IsTypeParameter
    ? new(Input)
    : base.Render(context)
      .Add("input", Input);
}

public record class InputFieldModel(
  string Name,
  ObjRefModel<InputBaseModel> Type
) : FieldModel<InputBaseModel>(Name, Type)
{
  internal ConstantModel? Default { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("default", Default?.Render(context));
}

internal class InputModeller(
  IAlternateModeller<InputReferenceAst, InputBaseModel> alternate,
  IModeller<InputFieldAst, InputFieldModel> field,
  IModeller<InputReferenceAst, InputBaseModel> reference
) : ModellerObject<InputDeclAst, InputReferenceAst, InputFieldAst, TypeInputModel, InputBaseModel, InputFieldModel>(alternate, field, reference)
{
  internal override TypeInputModel ToModel(InputDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class InputReferenceModeller
  : ModellerReference<InputReferenceAst, InputBaseModel>
{
  internal override InputBaseModel ToModel(InputReferenceAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      IsTypeParameter = ast.IsTypeParameter,
      Arguments = ModelArguments(ast, typeKinds),
    };
}

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<InputReferenceAst, InputBaseModel> reference,
  IModeller<ConstantAst, ConstantModel> constant
) : ModellerBase<InputFieldAst, InputFieldModel>
{
  internal override InputFieldModel ToModel(InputFieldAst field, IMap<TypeKindModel> typeKinds)
    => new(field.Name, new(reference.ToModel(field.Type, typeKinds))) {
      Modifiers = modifier.ToModels<ModifierModel>(field.Modifiers, typeKinds),
      Default = constant.TryModel(field.Default, typeKinds),
    };
}
