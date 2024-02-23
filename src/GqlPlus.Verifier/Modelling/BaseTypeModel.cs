using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract record class BaseTypeModel(TypeKindModel Kind, string Name)
  : AliasedModel(Name)
{
  internal override RenderStructure Render()
    => base.Render()
    .Add("kind", Kind.RenderEnum());
}
