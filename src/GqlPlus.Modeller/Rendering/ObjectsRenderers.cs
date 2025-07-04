﻿namespace GqlPlus.Rendering;

internal class ObjectBaseRenderer<TBase, TArg>(
  IRenderer<TArg> objArg
) : DescribedRenderer<TBase>
  where TBase : ObjBaseModel<TArg>
  where TArg : IObjTypeArgModel
{
  internal override Structured Render(TBase model)
    => base.Render(model)
      .AddIf(model.IsTypeParam, onFalse: s => s.AddList("typeArgs", model.Args, objArg));
}

internal class TypeParamRenderer(
  IRenderer<TypeRefModel<TypeKindModel>> typeKind
) : NamedRenderer<TypeParamModel>
{
  internal override Structured Render(TypeParamModel model)
    => base.Render(model)
      .AddRendered("constraint", model.Constraint, typeKind);
}

internal record class FieldRenderers<TBase>(
  IRenderer<ModifierModel> Modifier,
  IRenderer<TBase> ObjBase
) where TBase : IObjBaseModel;

internal class ObjectFieldRenderer<TField, TBase>(
  FieldRenderers<TBase> renderers
) : AliasedRenderer<TField>
  where TField : IObjFieldModel
  where TBase : class, IObjBaseModel
{
  internal override Structured Render(TField model)
    => base.Render(model)
      .AddList("modifiers", model.Modifiers, renderers.Modifier, flow: true)
      .AddRendered("type", model.BaseType as TBase, renderers.ObjBase);
}

internal record class AlternateRenderers<TObjBase>(
  IRenderer<CollectionModel> Collection,
  IRenderer<TObjBase> ObjBase
) where TObjBase : IObjBaseModel;

internal class ObjectAlternateRenderer<TAlt, TObjBase>(
  AlternateRenderers<TObjBase> renderers
) : BaseRenderer<TAlt>()
  where TAlt : ObjAlternateModel<TObjBase>
  where TObjBase : IObjBaseModel
{
  internal override Structured Render(TAlt model)
    => base.Render(model)
      .AddRendered("type", model.Type, renderers.ObjBase)
      .AddList("collections", model.Collections, renderers.Collection);
}

internal class ObjectForRenderer<TFor>(
  IRenderer<TFor> renderer
) : BaseRenderer<ObjectForModel<TFor>>
  where TFor : IModelBase
{
  internal override Structured Render(ObjectForModel<TFor> model)
    => base.Render(model)
      .IncludeRendered(model.For, renderer)
      .Add("object", model.Obj);
}

internal record class TypeObjectRenderers<TBase, TField, TAlt>(
  IRenderer<TBase> Parent,
  IRenderer<TField> Field,
  IRenderer<ObjectForModel<TField>> ObjField,
  IRenderer<ObjectForModel<DualFieldModel>> DualField,
  IRenderer<TAlt> Alternate,
  IRenderer<ObjectForModel<TAlt>> ObjAlternate,
  IRenderer<ObjectForModel<DualAlternateModel>> DualAlternate,
  IRenderer<TypeParamModel> TypeParam
)
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel;

internal abstract class TypeObjectRenderer<TObject, TBase, TField, TAlt>(
  TypeObjectRenderers<TBase, TField, TAlt> renderers
) : ChildTypeRenderer<TObject, TBase>(renderers.Parent)
  where TObject : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
{
  internal override Structured Render(TObject model)
  {
    List<ModelBase> allAlternates = [];
    List<ModelBase> allFields = [];

    //void AddMembers(ITypeObjectModel model)
    //{
    //  allAlternates.AddRange(model.AllAlternates);
    //  allFields.AddRange(model.AllFields);
    //}

    //ForParent<TObject, ITypeObjectModel>(model, context, AddMembers);
    // AddMembers(model);

    Structured ObjRender<TModel, TDual>(ModelBase[] list, IRenderer<ObjectForModel<TModel>> renderer, IRenderer<ObjectForModel<TDual>> dual)
      where TModel : IModelBase
      where TDual : ModelBase
      => new(list.Select(o => o switch {
        ObjectForModel<TModel> modelFor => renderer.Render(modelFor),
        ObjectForModel<TDual> dualFor => dual.Render(dualFor),
        _ => throw new InvalidCastException("Invalid ObjectFor " + o.GetType().ExpandTypeName() + " in " + model.Name
            + " expected " + typeof(TModel).ExpandTypeName() + " or " + typeof(TDual).ExpandTypeName())
      }));

    return base.Render(model)
        .AddList("typeParams", model.TypeParams, renderers.TypeParam)
        .AddList("fields", model.Fields, renderers.Field)
        .Add("allFields", ObjRender(model.AllFields, renderers.ObjField, renderers.DualField))
        .AddList("alternates", model.Alternates, renderers.Alternate)
        .Add("allAlternates", ObjRender(model.AllAlternates, renderers.ObjAlternate, renderers.DualAlternate));
  }
}

internal class DualArgRenderer
  : DescribedRenderer<DualArgModel>
{
  internal override Structured Render(DualArgModel model)
    => base.Render(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Dual),
        f => f.Add("dual", model.Dual));
}

internal class DualBaseRenderer(
  IRenderer<DualArgModel> objArg
) : ObjectBaseRenderer<DualBaseModel, DualArgModel>(objArg)
{
  internal override Structured Render(DualBaseModel model)
    => base.Render(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Dual),
        f => f.Add("dual", model.Dual));
}

internal class DualFieldRenderer(
  FieldRenderers<DualBaseModel> renderers
) : ObjectFieldRenderer<DualFieldModel, DualBaseModel>(renderers)
{ }

internal class TypeDualRenderer(
  TypeObjectRenderers<DualBaseModel, DualFieldModel, DualAlternateModel> renderers
) : TypeObjectRenderer<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel>(renderers)
{ }

internal class InputArgRenderer(
  IRenderer<DualArgModel> dual
) : DescribedRenderer<InputArgModel>
{
  internal override Structured Render(InputArgModel model)
    => model.Dual is null
    ? base.Render(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Input),
        f => f.Add("input", model.Input))
    : dual.Render(model.Dual);
}

internal class InputDualRenderer<TObj>(
  IRenderer<InputArgModel> objArg,
  IRenderer<DualBaseModel> dual
) : ObjectBaseRenderer<TObj, InputArgModel>(objArg)
  where TObj : InputBaseModel
{
  internal override Structured Render(TObj model)
    => model.Dual is null
      ? base.Render(model)
        .AddIf(model.IsTypeParam,
          t => t.Add("typeParam", model.Input),
          f => f.Add("input", model.Input))
      : dual.Render(model.Dual);
}

internal class InputBaseRenderer(
  IRenderer<InputArgModel> objArg,
  IRenderer<DualBaseModel> dual
) : InputDualRenderer<InputBaseModel>(objArg, dual)
{ }

internal class InputFieldRenderer(
  IRenderer<ConstantModel> constant,
  FieldRenderers<InputBaseModel> renderers
) : ObjectFieldRenderer<InputFieldModel, InputBaseModel>(renderers)
{
  internal override Structured Render(InputFieldModel model)
    => base.Render(model)
      .AddRendered("default", model.Default, constant);
}

internal class InputParamRenderer(
  IRenderer<InputArgModel> objArg,
  IRenderer<DualBaseModel> dual,
  IRenderer<ModifierModel> modifier,
  IRenderer<ConstantModel> constant
) : InputDualRenderer<InputParamModel>(objArg, dual)
{
  internal override Structured Render(InputParamModel model)
    => base.Render(model)
      .AddList("modifiers", model.Modifiers, modifier, flow: true)
      .AddRendered("default", model.DefaultValue, constant);
}

internal class TypeInputRenderer(
  TypeObjectRenderers<InputBaseModel, InputFieldModel, InputAlternateModel> renderers
) : TypeObjectRenderer<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>(renderers)
{ }

internal class OutputArgRenderer(
  IRenderer<DualArgModel> dual,
  IRenderer<TypeRefModel<SimpleKindModel>> label
) : DescribedRenderer<OutputArgModel>
{
  internal override Structured Render(OutputArgModel model)
    => string.IsNullOrWhiteSpace(model.ThrowIfNull().EnumLabel)
    ? model.Dual is null
      ? base.Render(model)
        .AddIf(model.IsTypeParam,
          t => t.Add("typeParam", model.Output ?? model.Name),
          f => f.Add("output", model.Output ?? model.Name))
      : dual.Render(model.Dual)
    : label.Render(model)
      .Add("label", model.EnumLabel!);
}

internal class OutputBaseRenderer(
  IRenderer<OutputArgModel> objArg,
  IRenderer<DualBaseModel> dual
) : ObjectBaseRenderer<OutputBaseModel, OutputArgModel>(objArg)
{
  internal override Structured Render(OutputBaseModel model)
    => model.Dual is null
      ? base.Render(model)
        .AddIf(model.IsTypeParam,
          t => t.Add("typeParam", model.Output),
          f => f.Add("output", model.Output))
      : dual.Render(model.Dual);
}

internal class OutputEnumRenderer
  : TypeRefRenderer<OutputEnumModel, SimpleKindModel>
{
  internal override Structured Render(OutputEnumModel model)
    => base.Render(model)
      .Add("field", model.Field)
      .Add("label", model.EnumLabel);
}

internal class OutputFieldRenderer(
  IRenderer<OutputEnumModel> outputEnum,
  FieldRenderers<OutputBaseModel> renderers,
  IRenderer<InputParamModel> parameter
) : ObjectFieldRenderer<OutputFieldModel, OutputBaseModel>(renderers)
{
  internal override Structured Render(OutputFieldModel model)
    => model.Enum is null
      ? base.Render(model)
        .AddList("parameters", model.Params, parameter)
      : outputEnum.Render(model.Enum);
}

internal class TypeOutputRenderer(
  TypeObjectRenderers<OutputBaseModel, OutputFieldModel, OutputAlternateModel> renderers
) : TypeObjectRenderer<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>(renderers)
{ }
