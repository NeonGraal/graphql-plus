﻿using GqlPlus.Models;

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

internal class BaseDescribedRenderer<TDescr>(
  IRenderer<TDescr> described
) : BaseRenderer<BaseDescribedModel<TDescr>>
  where TDescr : ModelBase
{
  internal override RenderStructure Render(BaseDescribedModel<TDescr> model, IRenderContext context)
    => string.IsNullOrEmpty(model.Description)
      ? described.Render(model.Base, context)
      : base.Render(model, context)
        .Add("base", described.Render(model.Base, context))
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
