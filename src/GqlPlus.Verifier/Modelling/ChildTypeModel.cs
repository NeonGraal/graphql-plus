using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract record class ChildTypeModel<TParent>(
  TypeKindModel Kind,
  string Name
) : BaseTypeModel(Kind, Name)
  where TParent : IRendering
{
  public TParent? Parent { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("parent", Parent?.Render());
}
