using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract record class AliasedModel(string Name)
  : DescribedModel<NamedModel>(new NamedModel(Name))
{
  public string[] Aliases { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("aliases", Aliases.Render());
}
