using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

// Todo: SchemaModel

// Todo: FilterParameter

// Todo: CategoryFilterParameter

// Todo: TypeFilterParameter

public record class AliasedModel(
  string Name
) : DescribedModel<NamedModel>(new NamedModel(Name))
{
  public string[] Aliases { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("aliases", Aliases.Render());
}

public record class DescribedModel<TBase>(
  TBase Base
) : ModelBase
  where TBase : IRendering
{
  public string? Description { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add(Base, context)
      .Add("description", RenderValue.Str(Description));
}

public record class NamedModel(
  string Name
) : ModelBase
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("name", Name);
}
