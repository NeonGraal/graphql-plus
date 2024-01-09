using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

public enum ResolutionModel { Parallel, Sequential, Single }

public static class CategoryHelper
{
  public static ModelValue ToModel(this CategoryDeclAst category)
    => new ModelValue("_Category")
      .Add("name", new("", category.Name))
      .Add("description", ModelValue.Str(category.Description))
      .Add("aliases", new("", category.Aliases.Select(a => new ModelValue("", a)), true))
      .Add("resolution", new("_Resolution", category.Option.ToString()))
      .Add("output", new("", category.Output))
      .Add("modifiers", new("", category.Modifiers.Select(m => m.ToModel()), true));

  public static string ToYaml(this ModelValue model)
    => ModelYaml.Serializer.Serialize(model);
}
