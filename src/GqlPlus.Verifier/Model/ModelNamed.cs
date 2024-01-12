using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Model;

public abstract record class ModelNamed(string Name)
  : IRendering
{
  public string? Description { get; set; }

  protected abstract string Tag { get; }

  internal virtual RenderStructure Render()
    => new RenderStructure("_" + Tag)
      .Add("name", new("", Name))
      .Add("description", RenderValue.Str(Description));
  RenderStructure IRendering.Render() => Render();
}
