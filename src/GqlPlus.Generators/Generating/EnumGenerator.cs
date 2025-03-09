namespace GqlPlus.Generating;

internal sealed class EnumGenerator
  : GenerateForType<IGqlpEnum>
{
  protected override void Generate(IGqlpEnum ast, GeneratorContext context)
  {
    context.AppendLine("");

    string parent = string.IsNullOrWhiteSpace(ast.Parent) ? "" : " : " + ast.Parent;

    context.AppendLine($"public enum {ast.Name}{parent} {{");
    foreach (IGqlpEnumItem item in ast.Items) {
      context.AppendLine("  " + item.Name + ",");
      foreach (string alias in item.Aliases) {
        context.AppendLine("  " + alias + " = " + item.Name + ",");
      }
    }

    context.AppendLine("}");
  }
}
