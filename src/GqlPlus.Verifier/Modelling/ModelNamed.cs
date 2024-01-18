using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract record class ModelNamed(string Name)
  : ModelBase
{
  public string? Description { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("name", new("", Name))
      .Add("description", RenderValue.Str(Description));
}
