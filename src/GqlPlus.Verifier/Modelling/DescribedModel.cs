using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

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
