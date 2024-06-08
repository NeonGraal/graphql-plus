namespace GqlPlus.Models;

public record class TypeInputModel(
  string Name
) : TypeObjectModel<InputBaseModel, InputFieldModel>(TypeKindModel.Input, Name)
{
  protected override string? ParentName(BaseDescribedModel<InputBaseModel>? parent)
    => parent?.Base.Input;
}

public record class InputBaseModel(
  string Input
) : ObjBaseModel<InputBaseModel>
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
  InputBaseModel Type
) : ObjFieldModel<InputBaseModel>(Name, Type)
{
  internal ConstantModel? Default { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("default", Default?.Render(context));
}

public record class InputParameterModel(
  BaseDescribedModel<InputBaseModel> Type
) : ModelBase
{
  internal ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add(Type, context)
      .Add("modifiers", Modifiers.Render(context, flow: true))
      .Add("default", DefaultValue?.Render(context));
}
