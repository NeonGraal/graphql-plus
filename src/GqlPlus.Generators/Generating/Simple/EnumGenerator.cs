namespace GqlPlus.Generating.Simple;

internal sealed class EnumGenerator
  : GenerateForType<IGqlpEnum>
{
  protected override void Generate(IGqlpEnum ast, GeneratorContext context)
  {
    context.AppendLine("");

    context.AppendLine($"public enum {ast.Name} {{");

    ParentItems(ast.Parent, context);

    foreach (IGqlpEnumLabel item in ast.Items) {
      context.AppendLine("  " + item.Name + ",");
      foreach (string alias in item.Aliases) {
        context.AppendLine("  " + alias + " = " + item.Name + ",");
      }
    }

    context.AppendLine("}");
  }

  private static void ParentItems(string? parent, GeneratorContext context)
  {
    IGqlpEnum? ast = context.GetTypeAst<IGqlpEnum>(parent);
    if (ast is null) {
      return;
    }

    ParentItems(ast.Parent, context);
    foreach (IGqlpEnumLabel item in ast.Items) {
      string suffix = " = " + parent + "." + item.Name + ",";
      context.AppendLine("  " + item.Name + suffix);
      foreach (string alias in item.Aliases) {
        context.AppendLine("  " + alias + suffix);
      }
    }
  }
}
