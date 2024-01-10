using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

internal record class ModifierModel(ModifierKind Kind) : IRendering
{
  public string Key { get; set; } = "";
  public bool KeyOptional { get; set; }

  public RenderValue Render()
    => Kind == ModifierKind.Dict
      ? new RenderValue("_Modifier")
       .Add("key", new("", Key))
       .Add("opt", KeyOptional ? new("", true) : new(""))
      : new RenderValue("_Modifier", $"{Kind}");

}

internal static class ModifierHelper
{
  internal static ModifierModel ToModel(this ModifierAst modifier)
    => new(modifier.Kind) {
      Key = modifier.Key ?? "",
      KeyOptional = modifier.KeyOptional,
    };
}