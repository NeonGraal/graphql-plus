using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

public static class ModifierHelper
{
  public static ModelValue ToModel(this ModifierAst mod)
    => mod.Kind switch {
      ModifierKind.Dict => new ModelValue("_Modifier")
       .Add("key", new("", mod.Key))
       .Add("opt", mod.KeyOptional ? new("", true) : new("")),
      _ => new ModelValue("_Modifier", $"{mod.Kind}"),
    };
}
