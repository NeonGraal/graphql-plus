using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public record class TypeOutputModel(
  string Name
) : TypeObjectModel<OutputBaseModel, OutputFieldModel>(TypeKindModel.Output, Name)
{
  protected override string? ParentName(BaseDescribedModel<OutputBaseModel>? parent)
    => parent?.Base.Output;
}

public record class OutputBaseModel(
  string Output
) : ObjBaseModel<OutputArgumentModel>
{
  internal DualBaseModel? Dual { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => Dual is null
    ? IsTypeParameter
      ? new(Output, "_TypeParameter")
      : base.Render(context)
        .Add("output", Output)
    : Dual.Render(context);
}

public record class OutputFieldModel(
  string Name,
  ObjRefModel<OutputBaseModel>? Type
) : ObjFieldModel<OutputBaseModel>(Name, Type)
{
  internal InputParameterModel[] Parameters { get; set; } = [];
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

  public bool IsTypeParameter => string.IsNullOrEmpty(EnumValue) && Ref?.BaseRef?.IsTypeParameter == true;

  internal override RenderStructure Render(IRenderContext context)
    => string.IsNullOrWhiteSpace(EnumValue)
    ? Ref.ThrowIfNull().Render(context)
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
  IAlternateModeller<OutputBaseAst, OutputBaseModel> alternate,
  IModeller<OutputFieldAst, OutputFieldModel> objField,
  IModeller<OutputBaseAst, OutputBaseModel> objBase
) : ModellerObject<OutputDeclAst, OutputBaseAst, OutputFieldAst, TypeOutputModel, OutputBaseModel, OutputFieldModel>(TypeKindModel.Output, alternate, objField, objBase)
{
  protected override TypeOutputModel ToModel(OutputDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class OutputBaseModeller(
  IModeller<DualBaseAst, DualBaseModel> dual
) : ModellerObjBase<OutputBaseAst, OutputBaseModel, OutputArgumentModel>
{
  internal override OutputArgumentModel NewArgument(OutputBaseAst ast, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(ast.EnumValue)
      ? new(ast.Name) { Ref = new(ToModel(ast, typeKinds)) }
      : new(ast.Name) { EnumValue = ast.EnumValue };

  protected override OutputBaseModel ToModel(OutputBaseAst ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Name, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new(ast.Name) {
      Dual = dual.ToModel(ast.ToDual(), typeKinds)
    }
    : new(ast.Name) {
      IsTypeParameter = ast.IsTypeParameter,
      TypeArguments = ModelArguments(ast, typeKinds),
    };
}

internal class OutputFieldModeller(
  IModifierModeller modifier,
  IModeller<InputParameterAst, InputParameterModel> parameter,
  IModeller<OutputBaseAst, OutputBaseModel> refBase
) : ModellerObjField<OutputBaseAst, OutputFieldAst, OutputBaseModel, OutputFieldModel>(modifier, refBase)
{
  protected override OutputFieldModel FieldModel(OutputFieldAst field, ObjRefModel<OutputBaseModel> type, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.Type.EnumValue)
      ? new(field.Name, type) {
        Parameters = parameter.ToModels(field.Parameters, typeKinds),
      }
      : new(field.Name, null) { // or should it be `type`
        Enum = new(field.Name, field.Type.Name, field.Type.EnumValue)
      };
}
