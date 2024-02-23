using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class ModifierModel(ModifierKind Kind)
  : IRendering
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

internal class ModifierModeller
  : ModellerBase<ModifierAst, ModifierModel>
{
  internal override ModifierModel ToModel(ModifierAst ast)
    => new(ast.Kind) {
      Key = ast.Key ?? "",
      KeyOptional = ast.KeyOptional,
    };
}
