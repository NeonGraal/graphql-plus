namespace GqlPlus.Rendering;

internal class AliasedRenderer<TModel>
  : NamedRenderer<TModel>
  where TModel : AliasedModel
{
  internal override RenderStructure Render(TModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("aliases", new(model.Aliases.Select(a => new RenderStructure(new RenderValue(a))), flow: true))
      .Add("description", RenderValue.Str(model.Description));
}

internal class DescribedRenderer<TModel>
  : NamedRenderer<TModel>
  where TModel : DescribedModel
{
  internal override RenderStructure Render(TModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("description", RenderValue.Str(model.Description));
}

internal class BaseDescribedRenderer<TDescr>(
  IRenderer<TDescr> described
) : BaseRenderer<ObjDescribedModel<TDescr>>
  where TDescr : ModelBase
{
  internal override RenderStructure Render(ObjDescribedModel<TDescr> model, IRenderContext context)
    => string.IsNullOrEmpty(model.Description)
      ? described.Render(model.Base, context)
      : base.Render(model, context)
        .Add("base", model.Base, described)
        .Add("description", RenderValue.Str(model.Description));
}

internal class NamedRenderer<TModel>
  : BaseRenderer<TModel>
  where TModel : NamedModel
{
  internal override RenderStructure Render(TModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("name", model.Name);
}
