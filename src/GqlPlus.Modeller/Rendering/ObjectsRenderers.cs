using System.Diagnostics.CodeAnalysis;
using GqlPlus.Resolving;

namespace GqlPlus.Rendering;

internal class ObjectBaseRenderer<TBase, TArg>(
  IRenderer<TArg> objArgument
) : BaseRenderer<TBase>
  where TBase : ObjBaseModel<TArg>
  where TArg : IObjArgumentModel
{
  internal override RenderStructure Render(TBase model)
    => base.Render(model)
      .Add("typeArguments", model.Arguments, objArgument);
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
  internal override RenderStructure Render(TField model)
    => base.Render(model)
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
  internal override RenderStructure Render(TAlt model)
    => base.Render(model)
      .Add("type", model.BaseType?.BaseAs<TBase>(), renderers.ObjBase)
      .Add("collections", model.Collections, renderers.Collection);
}

internal class ObjectForRenderer<TFor>(
  IRenderer<TFor> renderer
) : BaseRenderer<ObjectForModel<TFor>>
  where TFor : IModelBase
{
  internal override RenderStructure Render(ObjectForModel<TFor> model)
    => base.Render(model)
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
  IRenderer<DescribedModel> TypeParameter
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
  internal override RenderStructure Render(TObject model)
  {
    List<ModelBase> allAlternates = [];
    List<ModelBase> allFields = [];

    void AddMembers(ITypeObjectModel model)
    {
      allAlternates.AddRange(model.AllAlternates);
      allFields.AddRange(model.AllFields);
    }

    //ForParent<TObject, ITypeObjectModel>(model, context, AddMembers);
    AddMembers(model);

    RenderStructure ObjRender<TModel, TDual>(List<ModelBase> list, IRenderer<ObjectForModel<TModel>> renderer, IRenderer<ObjectForModel<TDual>> dual)
      where TModel : IModelBase
      where TDual : ModelBase
      => new(list.Select(o => o switch {
        ObjectForModel<TModel> modelFor => renderer.Render(modelFor),
        ObjectForModel<TDual> dualFor => dual.Render(dualFor),
        _ => throw new InvalidCastException("Invalid ObjectFor " + o.GetType().ExpandTypeName() + " in " + model.Name
            + " expected " + typeof(TModel).ExpandTypeName() + " or " + typeof(TDual).ExpandTypeName())
      }));

    return base.Render(model)
        .Add("typeParameters", model.TypeParameters, renderers.TypeParameter)
        .Add("fields", model.Fields, renderers.Field)
        .Add("allFields", ObjRender(allFields, renderers.ObjField, renderers.DualField))
        .Add("alternates", model.Alternates, renderers.Alternate)
        .Add("allAlternates", ObjRender(allAlternates, renderers.ObjAlternate, renderers.DualAlternate));
  }

  internal override bool GetParentModel<TInput, TResult>(TInput input, IResolveContext context, [NotNullWhen(true)] out TResult? result)
    where TResult : default
  {
    if (input.Parent?.Base.IsTypeParameter == false) {
      return base.GetParentModel(input, context, out result);
    }

    result = default;
    return false;
  }
}

internal class DualArgumentRenderer
  : BaseRenderer<DualArgumentModel>
{
  internal override RenderStructure Render(DualArgumentModel model)
    => model.IsTypeParameter
    ? new(model.Dual, "_TypeParameter")
    : base.Render(model)
      .Add("dual", model.Dual);
}

internal class DualBaseRenderer(
  IRenderer<DualArgumentModel> objArgument
) : ObjectBaseRenderer<DualBaseModel, DualArgumentModel>(objArgument)
{
  internal override RenderStructure Render(DualBaseModel model)
    => model.IsTypeParameter
    ? new(model.Dual, "_TypeParameter")
    : base.Render(model)
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

internal class InputArgumentRenderer(
  IRenderer<DualArgumentModel> dual
) : BaseRenderer<InputArgumentModel>
{
  internal override RenderStructure Render(InputArgumentModel model)
    => model.Dual is null
    ? model.IsTypeParameter
      ? new(model.Input, "_TypeParameter")
      : base.Render(model)
        .Add("input", model.Input)
    : dual.Render(model.Dual);
}

internal class InputBaseRenderer(
  IRenderer<InputArgumentModel> objArgument,
  IRenderer<DualBaseModel> dual
) : ObjectBaseRenderer<InputBaseModel, InputArgumentModel>(objArgument)
{
  internal override RenderStructure Render(InputBaseModel model)
    => model.Dual is null
    ? model.IsTypeParameter
      ? new(model.Input, "_TypeParameter")
      : base.Render(model)
        .Add("input", model.Input)
    : dual.Render(model.Dual);
}

internal class InputFieldRenderer(
  IRenderer<ConstantModel> constant,
  ModifierBaseRenderers<InputBaseModel> renderers
) : ObjectFieldRenderer<InputFieldModel, InputBaseModel>(renderers)
{
  internal override RenderStructure Render(InputFieldModel model)
    => base.Render(model)
      .Add("default", model.Default, constant);
}

internal class InputAlternateRenderer(
  CollectionBaseRenderers<InputBaseModel> renderers
) : ObjectAlternateRenderer<InputAlternateModel, InputBaseModel>(renderers)
{ }

internal class InputParameterRenderer(
  IRenderer<ConstantModel> constant,
  ModifierBaseRenderers<InputBaseModel> renderers
) : BaseRenderer<InputParameterModel>
{
  internal override RenderStructure Render(InputParameterModel model)
    => base.Render(model)
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

internal class OutputArgumentRenderer(
  IRenderer<DualArgumentModel> dual
) : TypeRefRenderer<OutputArgumentModel, SimpleKindModel>
{
  internal override RenderStructure Render(OutputArgumentModel model)
    => string.IsNullOrWhiteSpace(model.ThrowIfNull().EnumMember)
    ? model.Dual is null
      ? model.IsTypeParameter
        ? new(model.Output, "_TypeParameter")
        : RenderStructure.New(model.Tag)
          .Add("output", model.Output!)
      : dual.Render(model.Dual)
    : base.Render(model)
      .Add("member", model.EnumMember!);
}

internal class OutputBaseRenderer(
  IRenderer<OutputArgumentModel> objArgument,
  IRenderer<DualBaseModel> dual
) : ObjectBaseRenderer<OutputBaseModel, OutputArgumentModel>(objArgument)
{
  internal override RenderStructure Render(OutputBaseModel model)
    => model.Dual is null
    ? model.IsTypeParameter
      ? new(model.Output, "_TypeParameter")
      : base.Render(model)
        .Add("output", model.Output)
    : dual.Render(model.Dual);
}

internal class OutputEnumRenderer
  : TypeRefRenderer<OutputEnumModel, SimpleKindModel>
{
  internal override RenderStructure Render(OutputEnumModel model)
    => base.Render(model)
      .Add("field", model.Field)
      .Add("member", model.EnumMember);
}

internal class OutputFieldRenderer(
  IRenderer<OutputEnumModel> outputEnum,
  ModifierBaseRenderers<OutputBaseModel> renderers,
  IRenderer<InputParameterModel> parameter
) : ObjectFieldRenderer<OutputFieldModel, OutputBaseModel>(renderers)
{
  internal override RenderStructure Render(OutputFieldModel model)
    => model.Enum is null
      ? base.Render(model)
        .Add("parameters", model.Parameters, parameter)
      : outputEnum.Render(model.Enum);
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
