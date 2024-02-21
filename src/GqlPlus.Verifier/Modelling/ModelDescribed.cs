using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract record class ModelDescribed(ModelBase BaseModel)
  : ModelBase
{
  public string? Description { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add(BaseModel)
      .Add("description", RenderValue.Str(Description));
}
