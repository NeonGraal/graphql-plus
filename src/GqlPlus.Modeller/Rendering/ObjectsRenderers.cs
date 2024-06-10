using System.Diagnostics.CodeAnalysis;

using YamlDotNet.Core.Tokens;

namespace GqlPlus.Rendering;

internal class AlternateRenderer<TBase>(
  IRenderer<CollectionModel> collection,
  IRenderer<ObjDescribedModel<TBase>> type
) : BaseRenderer<AlternateModel<TBase>>
  where TBase : IObjBaseModel
{
  internal override RenderStructure Render(AlternateModel<TBase> model, IRenderContext context)
    => base.Render(model, context)
      .Add("type", type.Render(model.Type, context))
      .Add("collections", model.Collections.Render(collection, context));
}

internal class ObjectBaseRenderer<TBase>
  : BaseRenderer<TBase>
  where TBase : ObjBaseModel<TBase>
{
  internal override RenderStructure Render(TBase model, IRenderContext context)
    => base.Render(model, context)
      .Add("typeArguments", model.TypeArguments.Render(this, context));
}

internal record class ObjectFieldRenderers<TBase>(
  IRenderer<ModifierModel> Modifier,
  IRenderer<ObjDescribedModel<TBase>> ObjBase
) where TBase : IObjBaseModel;

internal class ObjectFieldRenderer<TField, TBase>(
  ObjectFieldRenderers<TBase> renderers
) : AliasedRenderer<TField>
  where TField : ObjFieldModel<TBase>
  where TBase : IObjBaseModel
{
  internal override RenderStructure Render(TField model, IRenderContext context)
    => base.Render(model, context)
      .Add("modifiers", model.Modifiers.Render(renderers.Modifier, context, flow: true))
      .Add("type", model.Type, renderers.ObjBase, context);
}

internal class ObjectForRenderer<TFor>(
  IRenderer<TFor> renderer
) : BaseRenderer<ObjectForModel<TFor>>
  where TFor : ModelBase
{
  internal override RenderStructure Render(ObjectForModel<TFor> model, IRenderContext context)
    => base.Render(model, context)
      .Add(model.For, renderer, context)
      .Add("object", model.Obj);
}

internal record class TypeObjectRenderers<TField, TBase>(
  IRenderer<AlternateModel<TBase>> Alternate,
  IRenderer<ObjectForModel<AlternateModel<TBase>>> ObjAlternate,
  IRenderer<TField> Field,
  IRenderer<ObjectForModel<TField>> ObjField,
  IRenderer<DescribedModel> TypeParameter
)
  where TBase : IObjBaseModel
  where TField : ModelBase;

internal abstract class TypeObjectRenderer<TObject, TField, TBase>(
  TypeObjectRenderers<TField, TBase> renderers
) : ChildTypeRenderer<TObject, ObjDescribedModel<TBase>>
  where TObject : TypeObjectModel<TBase, TField>
  where TBase : IObjBaseModel
  where TField : ModelBase
{
  internal override RenderStructure Render(TObject model, IRenderContext context)
  {
    List<ModelBase> allAlternates = [];
    List<ModelBase> allFields = [];

    void AddMembers(ITypeObjectModel model)
    {
      allAlternates.AddRange(model.AllAlternates);
      allFields.AddRange(model.AllFields);
    }

    ForParent<TObject, ITypeObjectModel>(model, context, AddMembers);
    AddMembers(model);

    RenderStructure ObjRender<TModel>(List<ModelBase> list, IRenderer<ObjectForModel<TModel>> renderer)
      where TModel : ModelBase
      => list.Cast<ObjectForModel<TModel>>().Render(renderer, context);

    return base.Render(model, context)
        .Add("typeParameters", model.TypeParameters.Render(renderers.TypeParameter, context))
        .Add("fields", model.Fields.Render(renderers.Field, context))
        .Add("allFields", ObjRender(allFields, renderers.ObjField))
        .Add("alternates", model.Alternates.Render(renderers.Alternate, context))
        .Add("allAlternates", ObjRender(allAlternates, renderers.ObjAlternate));
  }

  internal override bool GetParentModel<TInput, TResult>(TInput input, IRenderContext context, [NotNullWhen(true)] out TResult? result)
    where TResult : default
  {
    if (input.Parent?.Base.IsTypeParameter == false) {
      return base.GetParentModel(input, context, out result);
    }

    result = default;
    return false;
  }
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
  ObjectFieldRenderers<DualBaseModel> renderers
) : ObjectFieldRenderer<DualFieldModel, DualBaseModel>(renderers)
{ }

internal class TypeDualRenderer(
  TypeObjectRenderers<DualFieldModel, DualBaseModel> renderers
) : TypeObjectRenderer<TypeDualModel, DualFieldModel, DualBaseModel>(renderers)
{
  protected override string? ParentName(ObjDescribedModel<DualBaseModel>? parent)
    => parent?.Base.Dual;
}

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
  ObjectFieldRenderers<InputBaseModel> renderers
) : ObjectFieldRenderer<InputFieldModel, InputBaseModel>(renderers)
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

internal class TypeInputRenderer(
  TypeObjectRenderers<InputFieldModel, InputBaseModel> renderers
) : TypeObjectRenderer<TypeInputModel, InputFieldModel, InputBaseModel>(renderers)
{
  protected override string? ParentName(ObjDescribedModel<InputBaseModel>? parent)
    => parent?.Base.Input;
}

internal class OutputArgumentAndBaseRenderer(
  IRenderer<DualBaseModel> dual
) : TypeRefRenderer<OutputArgumentModel, SimpleKindModel>
  , IRenderer<OutputBaseModel>
{
  public RenderStructure Render(OutputBaseModel model, IRenderContext context)
    => RenderBase(model, context);

  private RenderStructure RenderBase(OutputBaseModel model, IRenderContext context)
    => model.Dual is null
    ? model.IsTypeParameter
      ? new(model.Output, "_TypeParameter")
      : RenderStructure.New(model.Tag)
        .Add("typeArguments", model.TypeArguments.Render(this, context))
        .Add("output", model.Output)
    : dual.Render(model.Dual, context);

  internal override RenderStructure Render(OutputArgumentModel model, IRenderContext context)
    => string.IsNullOrWhiteSpace(model.EnumMember)
    ? RenderBase(model.Ref.ThrowIfNull(), context)
    : base.Render(model, context)
      .Add("member", model.EnumMember);
}

internal class OutputEnumRenderer
  : TypeRefRenderer<OutputEnumModel, SimpleKindModel>
{
  internal override RenderStructure Render(OutputEnumModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("field", model.Field)
      .Add("member", model.EnumMember);
}

internal class OutputFieldRenderer(
  IRenderer<OutputEnumModel> outputEnum,
  ObjectFieldRenderers<OutputBaseModel> renderers,
  IRenderer<InputParameterModel> parameter
) : ObjectFieldRenderer<OutputFieldModel, OutputBaseModel>(renderers)
{
  internal override RenderStructure Render(OutputFieldModel model, IRenderContext context)
    => model.Enum is null
      ? base.Render(model, context)
        .Add("parameters", model.Parameters.Render(parameter, context))
      : outputEnum.Render(model.Enum, context);
}

internal class TypeOutputRenderer(
  TypeObjectRenderers<OutputFieldModel, OutputBaseModel> renderers
) : TypeObjectRenderer<TypeOutputModel, OutputFieldModel, OutputBaseModel>(renderers)
{
  protected override string? ParentName(ObjDescribedModel<OutputBaseModel>? parent)
    => parent?.Base.Output;
}
