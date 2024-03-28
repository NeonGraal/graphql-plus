using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class TypeOutputModel(
  string Name
) : TypeObjectModel<OutputBaseModel, OutputFieldModel>(TypeKindModel.Output, Name)
{ }

public record class OutputBaseModel(
  string Output
) : ObjBaseModel<OutputArgumentModel>
{
  internal override RenderStructure Render(IRenderContext context)
    => IsTypeParameter
    ? new(Output)
    : base.Render(context)
      .Add("output", Output);
}

public record class OutputFieldModel(
  string Name,
  ObjRefModel<OutputBaseModel>? Type
) : FieldModel<OutputBaseModel>(Name, Type)
{
  internal ParameterModel[] Parameters { get; set; } = [];
  internal OutputEnumModel? Enum { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => Enum is null
      ? base.Render(context)
        .Add("parameters", Parameters.Render(context))
      : Enum.Render(context);
}

public record class OutputArgumentModel(
  string Name
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name), IObjBaseModel
{
  internal string? EnumValue { get; set; }
  internal ObjRefModel<OutputBaseModel>? Ref { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => string.IsNullOrWhiteSpace(EnumValue)
    ? Ref!.Render(context)
    : base.Render(context)
      .Add("value", EnumValue);
}

public record class OutputEnumModel(
  string Field,
  string Type,
  string Value
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Type)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("field", Field)
      .Add("value", Value);
}

internal class OutputModeller(
  IAlternateModeller<OutputReferenceAst, OutputBaseModel> alternate,
  IModeller<OutputFieldAst, OutputFieldModel> field,
  IModeller<OutputReferenceAst, OutputBaseModel> reference
) : ModellerObject<OutputDeclAst, OutputReferenceAst, OutputFieldAst, TypeOutputModel, OutputBaseModel, OutputFieldModel>(alternate, field, reference)
{
  internal override TypeOutputModel ToModel(OutputDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class OutputReferenceModeller
  : ModellerReference<OutputReferenceAst, OutputBaseModel, OutputArgumentModel>
{
  internal override OutputArgumentModel NewArgument(OutputReferenceAst ast, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(ast.EnumValue)
      ? new(ast.Name) { Ref = new(ToModel(ast, typeKinds)) }
      : new(ast.Name) { EnumValue = ast.EnumValue };

  internal override OutputBaseModel ToModel(OutputReferenceAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      IsTypeParameter = ast.IsTypeParameter,
      Arguments = ModelArguments(ast, typeKinds),
    };
}

internal class OutputFieldModeller(
  IModifierModeller modifier,
  IModeller<ParameterAst, ParameterModel> parameter,
  IModeller<OutputReferenceAst, OutputBaseModel> reference
) : ModellerBase<OutputFieldAst, OutputFieldModel>
{
  internal override OutputFieldModel ToModel(OutputFieldAst field, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.Type.EnumValue)
      ? new(field.Name, new(reference.ToModel(field.Type, typeKinds))) {
        Modifiers = modifier.ToModels<ModifierModel>(field.Modifiers, typeKinds),
        Parameters = parameter.ToModels(field.Parameters, typeKinds),
      }
      : new(field.Name, null) {
        Enum = new(field.Name, field.Type.Name, field.Type.EnumValue)
      };
}
