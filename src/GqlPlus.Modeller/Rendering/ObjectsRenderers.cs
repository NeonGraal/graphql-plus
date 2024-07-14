﻿using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Rendering;

internal class ObjectBaseRenderer<TBase, TArg>(
  IRenderer<TArg> objArg
) : BaseRenderer<TBase>
  where TBase : ObjBaseModel<TArg>
  where TArg : IObjArgModel
{
  internal override RenderStructure Render(TBase model, IRenderContext context)
    => base.Render(model, context)
      .Add("typeArgs", model.Args, objArg);
}

internal record class ModifierBaseRenderers<TBase>(
  IRenderer<ModifierModel> Modifier,
  IRenderer<ObjDescribedModel<TBase>> ObjBase
) where TBase : IObjBaseModel;

internal class ObjectFieldRenderer<TField, TBase>(
  ModifierBaseRenderers<TBase> renderers
) : AliasedRenderer<TField>
  where TField : IObjFieldModel
  where TBase : IObjBaseModel
{
  internal override RenderStructure Render(TField model, IRenderContext context)
    => base.Render(model, context)
      .Add("modifiers", model.Modifiers, renderers.Modifier, flow: true)
      .Add("type", model.BaseType?.BaseAs<TBase>(), renderers.ObjBase);
}

internal record class CollectionBaseRenderers<TBase>(
  IRenderer<CollectionModel> Collection,
  IRenderer<ObjDescribedModel<TBase>> ObjBase
) where TBase : IObjBaseModel;

internal class ObjectAlternateRenderer<TAlt, TBase>(
  CollectionBaseRenderers<TBase> renderers
) : BaseRenderer<TAlt>
  where TAlt : IObjAlternateModel
  where TBase : IObjBaseModel
{
  internal override RenderStructure Render(TAlt model, IRenderContext context)
    => base.Render(model, context)
      .Add("type", model.BaseType?.BaseAs<TBase>(), renderers.ObjBase)
      .Add("collections", model.Collections, renderers.Collection);
}

internal class ObjectForRenderer<TFor>(
  IRenderer<TFor> renderer
) : BaseRenderer<ObjectForModel<TFor>>
  where TFor : IModelBase
{
  internal override RenderStructure Render(ObjectForModel<TFor> model, IRenderContext context)
    => base.Render(model, context)
      .Add(model.For, renderer)
      .Add("object", model.Obj);
}

internal record class TypeObjectRenderers<TBase, TField, TAlt>(
  IRenderer<ObjDescribedModel<TBase>> Parent,
  IRenderer<TField> Field,
  IRenderer<ObjectForModel<TField>> ObjField,
  IRenderer<ObjectForModel<DualFieldModel>> DualField,
  IRenderer<TAlt> Alternate,
  IRenderer<ObjectForModel<TAlt>> ObjAlternate,
  IRenderer<ObjectForModel<DualAlternateModel>> DualAlternate,
  IRenderer<DescribedModel> TypeParam
)
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel;

internal abstract class TypeObjectRenderer<TObject, TBase, TField, TAlt>(
  TypeObjectRenderers<TBase, TField, TAlt> renderers
) : ChildTypeRenderer<TObject, ObjDescribedModel<TBase>>(renderers.Parent)
  where TObject : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
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

    RenderStructure ObjRender<TModel, TDual>(List<ModelBase> list, IRenderer<ObjectForModel<TModel>> renderer, IRenderer<ObjectForModel<TDual>> dual)
      where TModel : IModelBase
      where TDual : ModelBase
      => new(list.Select(o => o switch {
        ObjectForModel<TModel> modelFor => renderer.Render(modelFor, context),
        ObjectForModel<TDual> dualFor => dual.Render(dualFor, context),
        _ => throw new InvalidCastException("Invalid ObjectFor " + o.GetType().ExpandTypeName() + " in " + model.Name
            + " expected " + typeof(TModel).ExpandTypeName() + " or " + typeof(TDual).ExpandTypeName())
      }));

    return base.Render(model, context)
        .Add("typeParams", model.TypeParams, renderers.TypeParam)
        .Add("fields", model.Fields, renderers.Field)
        .Add("allFields", ObjRender(allFields, renderers.ObjField, renderers.DualField))
        .Add("alternates", model.Alternates, renderers.Alternate)
        .Add("allAlternates", ObjRender(allAlternates, renderers.ObjAlternate, renderers.DualAlternate));
  }

  internal override bool GetParentModel<TInput, TResult>(TInput input, IRenderContext context, [NotNullWhen(true)] out TResult? result)
    where TResult : default
  {
    if (input.Parent?.Base.IsTypeParam == false) {
      return base.GetParentModel(input, context, out result);
    }

    result = default;
    return false;
  }
}

internal class DualArgRenderer
  : BaseRenderer<DualArgModel>
{
  internal override RenderStructure Render(DualArgModel model, IRenderContext context)
    => model.IsTypeParam
    ? new(model.Dual, "_TypeParam")
    : base.Render(model, context)
      .Add("dual", model.Dual);
}

internal class DualBaseRenderer(
  IRenderer<DualArgModel> objArg
) : ObjectBaseRenderer<DualBaseModel, DualArgModel>(objArg)
{
  internal override RenderStructure Render(DualBaseModel model, IRenderContext context)
    => model.IsTypeParam
    ? new(model.Dual, "_TypeParam")
    : base.Render(model, context)
      .Add("dual", model.Dual);
}

internal class DualFieldRenderer(
  ModifierBaseRenderers<DualBaseModel> renderers
) : ObjectFieldRenderer<DualFieldModel, DualBaseModel>(renderers)
{ }

internal class DualAlternateRenderer(
  CollectionBaseRenderers<DualBaseModel> renderers
) : ObjectAlternateRenderer<DualAlternateModel, DualBaseModel>(renderers)
{ }

internal class TypeDualRenderer(
  TypeObjectRenderers<DualBaseModel, DualFieldModel, DualAlternateModel> renderers
) : TypeObjectRenderer<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel>(renderers)
{
  protected override string? ParentName(ObjDescribedModel<DualBaseModel>? parent)
    => parent?.Base.Dual;
}

internal class InputArgRenderer(
  IRenderer<DualArgModel> dual
) : BaseRenderer<InputArgModel>
{
  internal override RenderStructure Render(InputArgModel model, IRenderContext context)
    => model.Dual is null
    ? model.IsTypeParam
      ? new(model.Input, "_TypeParam")
      : base.Render(model, context)
        .Add("input", model.Input)
    : dual.Render(model.Dual, context);
}

internal class InputBaseRenderer(
  IRenderer<InputArgModel> objArg,
  IRenderer<DualBaseModel> dual
) : ObjectBaseRenderer<InputBaseModel, InputArgModel>(objArg)
{
  internal override RenderStructure Render(InputBaseModel model, IRenderContext context)
    => model.Dual is null
    ? model.IsTypeParam
      ? new(model.Input, "_TypeParam")
      : base.Render(model, context)
        .Add("input", model.Input)
    : dual.Render(model.Dual, context);
}

internal class InputFieldRenderer(
  IRenderer<ConstantModel> constant,
  ModifierBaseRenderers<InputBaseModel> renderers
) : ObjectFieldRenderer<InputFieldModel, InputBaseModel>(renderers)
{
  internal override RenderStructure Render(InputFieldModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("default", model.Default, constant);
}

internal class InputAlternateRenderer(
  CollectionBaseRenderers<InputBaseModel> renderers
) : ObjectAlternateRenderer<InputAlternateModel, InputBaseModel>(renderers)
{ }

internal class InputParamRenderer(
  IRenderer<ConstantModel> constant,
  ModifierBaseRenderers<InputBaseModel> renderers
) : BaseRenderer<InputParamModel>
{
  internal override RenderStructure Render(InputParamModel model, IRenderContext context)
    => base.Render(model, context)
      .Add(model.Type, renderers.ObjBase)
      .Add("modifiers", model.Modifiers, renderers.Modifier, flow: true)
      .Add("default", model.DefaultValue, constant);
}

internal class TypeInputRenderer(
  TypeObjectRenderers<InputBaseModel, InputFieldModel, InputAlternateModel> renderers
) : TypeObjectRenderer<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>(renderers)
{
  protected override string? ParentName(ObjDescribedModel<InputBaseModel>? parent)
    => parent?.Base.Input;
}

internal class OutputArgRenderer(
  IRenderer<DualArgModel> dual
) : TypeRefRenderer<OutputArgModel, SimpleKindModel>
{
  internal override RenderStructure Render(OutputArgModel model, IRenderContext context)
    => string.IsNullOrWhiteSpace(model.ThrowIfNull().EnumMember)
    ? model.Dual is null
      ? model.IsTypeParam
        ? new(model.Output, "_TypeParam")
        : RenderStructure.New(model.Tag, context)
          .Add("output", model.Output!)
      : dual.Render(model.Dual, context)
    : base.Render(model, context)
      .Add("member", model.EnumMember!);
}

internal class OutputBaseRenderer(
  IRenderer<OutputArgModel> objArg,
  IRenderer<DualBaseModel> dual
) : ObjectBaseRenderer<OutputBaseModel, OutputArgModel>(objArg)
{
  internal override RenderStructure Render(OutputBaseModel model, IRenderContext context)
    => model.Dual is null
    ? model.IsTypeParam
      ? new(model.Output, "_TypeParam")
      : base.Render(model, context)
        .Add("output", model.Output)
    : dual.Render(model.Dual, context);
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
  ModifierBaseRenderers<OutputBaseModel> renderers,
  IRenderer<InputParamModel> parameter
) : ObjectFieldRenderer<OutputFieldModel, OutputBaseModel>(renderers)
{
  internal override RenderStructure Render(OutputFieldModel model, IRenderContext context)
    => model.Enum is null
      ? base.Render(model, context)
        .Add("parameters", model.Params, parameter)
      : outputEnum.Render(model.Enum, context);
}

internal class OutputAlternateRenderer(
  CollectionBaseRenderers<OutputBaseModel> renderers
) : ObjectAlternateRenderer<OutputAlternateModel, OutputBaseModel>(renderers)
{ }

internal class TypeOutputRenderer(
  TypeObjectRenderers<OutputBaseModel, OutputFieldModel, OutputAlternateModel> renderers
) : TypeObjectRenderer<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>(renderers)
{
  protected override string? ParentName(ObjDescribedModel<OutputBaseModel>? parent)
    => parent?.Base.Output;
}
