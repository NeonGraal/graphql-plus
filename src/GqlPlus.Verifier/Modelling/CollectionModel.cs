using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class CollectionModel(ModifierKind Kind)
  : ModelBase
{
  public string Key { get; set; } = "";
  public bool KeyOptional { get; set; }

  internal override RenderStructure Render()
    => base.Render()
        .Add("kind", $"{Kind}")
        .Add(Kind == ModifierKind.Dict, s => s
          .Add("key", Key)
          .Add("opt", KeyOptional, true)
        );
}
