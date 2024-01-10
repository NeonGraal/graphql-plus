namespace GqlPlus.Verifier.Model;

public abstract record class ModelNamed(string Name)
  : IRendering
{
  public string? Description { get; set; }

  protected abstract string Tag { get; }

  public virtual RenderValue Render()
    => new RenderValue("_" + Tag)
      .Add("name", new("", Name))
      .Add("description", RenderValue.Str(Description));
}
