namespace GqlPlus.Rendering;

internal class AliasedRenderer<TModel>
  : NamedRenderer<TModel>
  where TModel : IAliasedModel
{
  internal override Structured Render(TModel model)
    => base.Render(model)
      .Add("aliases", new(model.Aliases.Select(a => new Structured(new StructureValue(a))), flow: true));
}

internal class DescribedRenderer<TModel>
  : BaseRenderer<TModel>
  where TModel : IDescribedModel
{
  internal Structured Described(Structured rendered, TModel model)
    => rendered
    .Add("description", StructureValue.Str(model.Description));

  internal override Structured Render(TModel model)
    => Described(base.Render(model), model);
}

internal class NamedRenderer<TModel>
  : DescribedRenderer<TModel>
  where TModel : INamedModel
{
  internal override Structured Render(TModel model)
    => base.Render(model)
      .Add("name", model.Name);
}
