namespace GqlPlus.Rendering;

internal class AliasedRenderer<TModel>
  : NamedRenderer<TModel>
  where TModel : IAliasedModel
{
  internal override RenderStructure Render(TModel model)
    => base.Render(model)
      .Add("aliases", new(model.Aliases.Select(a => new RenderStructure(new RenderValue(a))), flow: true))
      .Add("description", RenderValue.Str(model.Description));
}

internal class DescribedRenderer<TModel>
  : NamedRenderer<TModel>
  where TModel : DescribedModel
{
  internal override RenderStructure Render(TModel model)
    => base.Render(model)
      .Add("description", RenderValue.Str(model.Description));
}

internal class BaseDescribedRenderer<TDescr>(
  IRenderer<TDescr> described
) : BaseRenderer<ObjDescribedModel<TDescr>>
  where TDescr : ModelBase
{
  internal override RenderStructure Render(ObjDescribedModel<TDescr> model)
    => string.IsNullOrEmpty(model.Description)
      ? described.Render(model.Base)
      : base.Render(model)
        .Add("base", model.Base, described)
        .Add("description", RenderValue.Str(model.Description));
}

internal class NamedRenderer<TModel>
  : BaseRenderer<TModel>
  where TModel : INamedModel
{
  internal override RenderStructure Render(TModel model)
    => base.Render(model)
      .Add("name", model.Name);
}
