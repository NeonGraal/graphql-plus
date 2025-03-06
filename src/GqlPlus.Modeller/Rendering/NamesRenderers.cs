namespace GqlPlus.Rendering;

internal class AliasedRenderer<TModel>
  : NamedRenderer<TModel>
  where TModel : IAliasedModel
{
  internal override Structured Render(TModel model)
    => base.Render(model)
      .Add("aliases", new(model.Aliases.Select(a => new Structured(new StructureValue(a))), flow: true))
      .Add("description", StructureValue.Str(model.Description));
}

internal class DescribedRenderer<TModel>
  : NamedRenderer<TModel>
  where TModel : DescribedModel
{
  internal override Structured Render(TModel model)
    => base.Render(model)
      .Add("description", StructureValue.Str(model.Description));
}

internal class BaseDescribedRenderer<TDescr>(
  IRenderer<TDescr> described
) : BaseRenderer<ObjDescribedModel<TDescr>>
  where TDescr : ModelBase
{
  internal override Structured Render(ObjDescribedModel<TDescr> model)
    => string.IsNullOrEmpty(model.Description)
      ? described.Render(model.Base)
      : base.Render(model)
        .AddRendered("base", model.Base, described)
        .Add("description", StructureValue.Str(model.Description));
}

internal class NamedRenderer<TModel>
  : BaseRenderer<TModel>
  where TModel : INamedModel
{
  internal override Structured Render(TModel model)
    => base.Render(model)
      .Add("name", model.Name);
}
