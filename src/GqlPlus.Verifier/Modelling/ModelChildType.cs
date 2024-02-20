using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract record class ModelChildType<TParent>(TypeKindModel Kind, string Name)
  : ModelBaseType(Kind, Name)
  where TParent : ModelBase
{
  public TParent? Parent { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("parent", Parent?.Render());
}
