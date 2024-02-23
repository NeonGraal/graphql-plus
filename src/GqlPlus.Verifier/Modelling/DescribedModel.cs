using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract record class DescribedModel<TBase>(TBase Base)
  : ModelBase
  where TBase : ModelBase
{
  public string? Description { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add(Base)
      .Add("description", RenderValue.Str(Description));
}
