using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class ModelScalarItem<TItem>(TItem Item, string Scalar)
  : ModelBase
  where TItem : ModelBase
{
  internal override RenderStructure Render()
    => Item.Render()
      .Add("scalar", new("", Scalar));
}
