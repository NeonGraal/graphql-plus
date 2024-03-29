using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

// Todo: SchemaModel

// Todo: FilterParameter

// Todo: CategoryFilterParameter

// Todo: TypeFilterParameter

public record class AliasedModel(
  string Name
) : NamedModel(new NamedModel(Name))
{
  public string? Description { get; set; }
  public string[] Aliases { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("aliases", Aliases.Render())
      .Add("description", RenderValue.Str(Description));
}

public record class DescribedModel(
  string Name
) : NamedModel(Name)
{
  public string? Description { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("description", RenderValue.Str(Description));
}

public record class BaseDescribedModel<TBase>(
  TBase Base
) : ModelBase
  where TBase : IRendering
{
  public string? Description { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => string.IsNullOrEmpty(Description)
      ? Base.Render(context)
      : base.Render(context)
        .Add("base", Base.Render(context))
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
