namespace GqlPlus.Models;

public record class TypeOutputModel(
  string Name
) : TypeObjectModel<OutputBaseModel, OutputFieldModel>(TypeKindModel.Output, Name)
{
  protected override string? ParentName(ObjDescribedModel<OutputBaseModel>? parent)
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
  ObjDescribedModel<OutputBaseModel>? Type
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
