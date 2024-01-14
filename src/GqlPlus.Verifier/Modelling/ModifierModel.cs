using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class ModifierModel(ModifierKind Kind) : IRendering
{
  public string Key { get; set; } = "";
  public bool KeyOptional { get; set; }

  public RenderStructure Render()
    => Kind == ModifierKind.Dict
      ? new RenderStructure("_Modifier")
       .Add("key", new("", Key))
       .Add("opt", KeyOptional ? new("", true) : new(""))
      : new RenderStructure("_Modifier", $"{Kind}");

}

internal static class ModifierHelper
{
  internal static ModifierModel ToModel(this ModifierAst modifier)
    => new(modifier.Kind) {
      Key = modifier.Key ?? "",
      KeyOptional = modifier.KeyOptional,
    };
}
