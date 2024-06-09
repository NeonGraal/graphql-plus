namespace GqlPlus.Rendering;

internal class ObjectBaseRenderer<TBase>
  : ObjectBaseRenderer<TBase, TBase>
  where TBase : ObjBaseModel<TBase>, IObjBaseModel
{
  public ObjectBaseRenderer()
    => _typeArgument = this;
}

internal class ObjectBaseRenderer<TBase, TArg>
  : BaseRenderer<TBase>
  where TBase : ObjBaseModel<TArg>
  where TArg : IObjBaseModel
{
  protected IRenderer<TArg>? _typeArgument;

  protected ObjectBaseRenderer()
    => _typeArgument = default;

  public ObjectBaseRenderer(IRenderer<TArg> typeArgument)
    => _typeArgument = typeArgument;

  internal override RenderStructure Render(TBase model, IRenderContext context)
    => base.Render(model, context)
      .Add("typeArguments", model.TypeArguments.Render(_typeArgument!, context));
}

internal class ObjectFieldRenderer<TField, TBase>(
  IRenderer<ModifierModel> modifier,
  IRenderer<TBase> objBase
) : AliasedRenderer<TField>
  where TField : ObjFieldModel<TBase>
  where TBase : IObjBaseModel
{
  internal override RenderStructure Render(TField model, IRenderContext context)
    => base.Render(model, context)
      .Add("modifiers", model.Modifiers.Render(modifier, context, flow: true))
      .Add("type", model.Type, objBase, context);
}

internal class DualBaseRenderer
  : ObjectBaseRenderer<DualBaseModel>
{
  internal override RenderStructure Render(DualBaseModel model, IRenderContext context)
    => model.IsTypeParameter
    ? new(model.Dual, "_TypeParameter")
    : base.Render(model, context)
      .Add("dual", model.Dual);
}

internal class DualFieldRenderer(
  IRenderer<ModifierModel> modifier,
  IRenderer<DualBaseModel> objBase
) : ObjectFieldRenderer<DualFieldModel, DualBaseModel>(modifier, objBase)
{ }

internal class InputBaseRenderer(
  IRenderer<DualBaseModel> dual
) : ObjectBaseRenderer<InputBaseModel>
{
  internal override RenderStructure Render(InputBaseModel model, IRenderContext context)
    => model.Dual is null
    ? model.IsTypeParameter
      ? new(model.Input, "_TypeParameter")
      : base.Render(model, context)
        .Add("input", model.Input)
    : dual.Render(model.Dual, context);
}

internal class InputFieldRenderer(
  IRenderer<ConstantModel> constant,
  IRenderer<ModifierModel> modifier,
  IRenderer<InputBaseModel> objBase
) : ObjectFieldRenderer<InputFieldModel, InputBaseModel>(modifier, objBase)
{
  internal override RenderStructure Render(InputFieldModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("default", model.Default, constant, context);
}

internal class InputParameterRenderer(
  IRenderer<ConstantModel> constant,
  IRenderer<ModifierModel> modifier
) : BaseRenderer<InputParameterModel>
{
  internal override RenderStructure Render(InputParameterModel model, IRenderContext context)
    => base.Render(model, context)
      .Add(model.Type, context)
      .Add("modifiers", model.Modifiers.Render(modifier, context, flow: true))
      .Add("default", model.DefaultValue, constant, context);
}

internal class OutputBaseRenderer(
  IRenderer<DualBaseModel> dual,
  IRenderer<OutputArgumentModel> typeArgument
) : ObjectBaseRenderer<OutputBaseModel, OutputArgumentModel>(typeArgument)
{
  internal override RenderStructure Render(OutputBaseModel model, IRenderContext context)
    => model.Dual is null
    ? model.IsTypeParameter
      ? new(model.Output, "_TypeParameter")
      : base.Render(model, context)
        .Add("output", model.Output)
    : dual.Render(model.Dual, context);
}

internal class OutputFieldRenderer(
  IRenderer<OutputEnumModel> outputEnum,
  IRenderer<ModifierModel> modifier,
  IRenderer<OutputBaseModel> objBase,
  IRenderer<InputParameterModel> parameter
) : ObjectFieldRenderer<OutputFieldModel, OutputBaseModel>(modifier, objBase)
{
  internal override RenderStructure Render(OutputFieldModel model, IRenderContext context)
    => model.Enum is null
      ? base.Render(model, context)
        .Add("parameters", model.Parameters.Render(parameter, context))
      : outputEnum.Render(model.Enum, context);
}
