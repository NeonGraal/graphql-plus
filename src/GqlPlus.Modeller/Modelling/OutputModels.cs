using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public record class TypeOutputModel(
  string Name
) : TypeObjectModel<OutputBaseModel, OutputFieldModel>(TypeKindModel.Output, Name)
{
  protected override string BaseName(OutputBaseModel? objBase)
    => objBase?.Output ?? "";

  protected override OutputFieldModel NewField(OutputFieldModel field, ObjRefModel<OutputBaseModel> typeModel, IEnumerable<ModifierModel> modifiers)
    => new(field.ThrowIfNull().Name, typeModel) {
      Parameters = field.Parameters,
      Aliases = field.Aliases,
      Description = field.Description,
      Modifiers = [.. modifiers],
      EnumValue = field.EnumValue,
    };
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
  internal OutputEnumModel? EnumValue { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => EnumValue is null
      ? base.Render(context)
        .Add("parameters", Parameters.Render(context))
      : EnumValue.Render(context);
}

public record class OutputArgumentModel(
  string Name
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
  , IObjBaseModel
{
  internal string? EnumValue { get; set; }
  internal ObjRefModel<OutputBaseModel>? Ref { get; set; }

  public bool IsTypeParameter => string.IsNullOrEmpty(EnumValue) && Ref?.BaseRef?.IsTypeParameter == true;
  public IObjBaseModel? BaseRef => Ref;

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
  IAlternateModeller<IGqlpOutputBase, OutputBaseModel> alternate,
  IModeller<IGqlpOutputField, OutputFieldModel> objField,
  IModeller<IGqlpOutputBase, OutputBaseModel> objBase
) : ModellerObject<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, TypeOutputModel, OutputBaseModel, OutputFieldModel>(TypeKindModel.Output, alternate, objField, objBase)
{
  protected override TypeOutputModel ToModel(IGqlpOutputObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class OutputBaseModeller(
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpOutputBase, OutputBaseModel, OutputArgumentModel>
{
  internal override OutputArgumentModel NewArgument(IGqlpOutputBase ast, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(ast.EnumValue)
      ? new(ast.Output) { Ref = new(ToModel(ast, typeKinds)) }
      : new(ast.Output) { EnumValue = ast.EnumValue };

  protected override OutputBaseModel ToModel(IGqlpOutputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Output, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new(ast.Output) {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Output) {
      IsTypeParameter = ast.IsTypeParameter,
      TypeArguments = ModelArguments(ast, typeKinds),
    };
}

internal class OutputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputParameter, InputParameterModel> parameter,
  IModeller<IGqlpOutputBase, OutputBaseModel> refBase
) : ModellerObjField<IGqlpOutputBase, IGqlpOutputField, OutputBaseModel, OutputFieldModel>(modifier, refBase)
{
  protected override OutputFieldModel FieldModel(IGqlpOutputField field, ObjRefModel<OutputBaseModel> type, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.Type.EnumValue)
      ? new(field.Name, type) {
        Parameters = parameter.ToModels(field.Parameters, typeKinds),
      }
      : new(field.Name, null) { // or should it be `type`
        EnumValue = new(field.Name, field.Type.Output, field.Type.EnumValue)
      };
}
