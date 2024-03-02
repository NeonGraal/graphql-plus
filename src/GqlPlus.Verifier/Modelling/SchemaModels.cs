using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

// Todo: SchemaModel

// Todo: FilterParameter

// Todo: CategoryFilterParameter

// Todo: TypeFilterParameter

internal abstract record class AliasedModel(string Name)
  : DescribedModel<NamedModel>(new NamedModel(Name))
{
  public string[] Aliases { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("aliases", Aliases.Render());
}

internal record class DescribedModel<TBase>(TBase Base)
  : ModelBase
  where TBase : IRendering
{
  public string? Description { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add(Base)
      .Add("description", RenderValue.Str(Description));
}

public record class NamedModel(string Name)
  : ModelBase
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("name", Name);
}
