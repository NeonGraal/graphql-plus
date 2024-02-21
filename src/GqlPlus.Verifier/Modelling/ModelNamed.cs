using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class ModelNamed(string Name)
  : ModelBase
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("name", new("", Name));
}
