using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Objects;

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
  OutputBaseModel? Type
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
  internal string? EnumMember { get; set; }
  internal OutputBaseModel? Ref { get; set; }

  public bool IsTypeParameter => string.IsNullOrEmpty(EnumMember) && Ref?.IsTypeParameter == true;

  internal override RenderStructure Render(IRenderContext context)
    => string.IsNullOrWhiteSpace(EnumMember)
    ? Ref.ThrowIfNull().Render(context)
    : base.Render(context)
      .Add("member", EnumMember);
}

public record class OutputEnumModel(
  string Field,
  string Type,
  string EnumMember
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Type)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("field", Field)
      .Add("member", EnumMember);
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
    => string.IsNullOrWhiteSpace(ast.EnumMember)
      ? new(ast.Output) { Ref = ToModel(ast, typeKinds) }
      : new(ast.Output) { EnumMember = ast.EnumMember };

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
  protected override OutputFieldModel FieldModel(IGqlpOutputField field, OutputBaseModel type, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.Type.EnumMember)
      ? new(field.Name, type) {
        Parameters = parameter.ToModels(field.Parameters, typeKinds),
      }
      : new(field.Name, null) { // or should it be `type`
        Enum = new(field.Name, field.Type.Output, field.Type.EnumMember)
      };
}
