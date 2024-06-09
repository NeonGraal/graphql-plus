namespace GqlPlus.Rendering;

internal class AliasedRenderer<TModel>
  : NamedRenderer<TModel>
  where TModel : AliasedModel
{
  internal override RenderStructure Render(TModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("aliases", model.Aliases.Render())
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

internal class NamedRenderer<TModel>
  : BaseRenderer<TModel>
  where TModel : NamedModel
{
  internal override RenderStructure Render(TModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("name", model.Name);
}
