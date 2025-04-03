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
  internal override Structured Render(TModel model)
    => base.Render(model)
      .Add("description", StructureValue.Str(model.Description));
}

internal class NamedRenderer<TModel>
  : DescribedRenderer<TModel>
  where TModel : INamedModel
{
  internal override Structured Render(TModel model)
    => base.Render(model)
      .Add("name", model.Name);
}
