using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract record class ModelBaseType(TypeKindModel Kind, string Name)
  : ModelAliased(Name)
{
  internal override RenderStructure Render()
    => base.Render()
    .Add("kind", Kind.RenderEnum());
}
