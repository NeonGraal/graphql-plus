using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract record class ModelAliased(string Name)
  : ModelNamed(Name)
{
  public string[] Aliases { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("aliases", Aliases.Render());
}
