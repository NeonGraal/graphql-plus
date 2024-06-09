using GqlPlus.Ast;

namespace GqlPlus.Rendering;

internal class ObjectBaseRenderer<TBase>
  : BaseRenderer<TBase>
  where TBase : ObjBaseModel<TBase>
{
  internal override RenderStructure Render(TBase model, IRenderContext context)
    => base.Render(model, context)
      .Add("typeArguments", model.TypeArguments.Render(this, context));
}

internal class ObjectFieldRenderer<TField, TBase>(
  IRenderer<TBase> objBase,
  IRenderer<ModifierModel> modifier
) : AliasedRenderer<TField>
  where TField : ObjFieldModel<TBase>
  where TBase : ObjBaseModel<TBase>
{
  internal override RenderStructure Render(TField model, IRenderContext context)
    => base.Render(model, context)
      .Add("modifiers", model.Modifiers.Render(modifier, context, flow: true))
      .Add(model.Type is not null,
        s => s.Add("type", objBase.Render(model.Type!, context)));
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
  IRenderer<DualBaseModel> objBase,
  IRenderer<ModifierModel> modifier
) : ObjectFieldRenderer<DualFieldModel, DualBaseModel>(objBase, modifier)
{ }
