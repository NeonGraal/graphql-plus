namespace GqlPlus.Generating.Simple;

internal sealed class UnionGenerator
  : GenerateForType<IGqlpUnion>
{
  protected override void Generate(IGqlpUnion ast, GeneratorContext context)
  {
    UnionType(ast, context, "I", "get;");
    UnionType(ast, context, "Union", "get; set;", "I");
  }

  private static void UnionType(IGqlpUnion ast, GeneratorContext context, string prefix, string accessors, string intf = "")
  {
    context.AppendLine("");

    context.AppendLine($"public class {prefix}{ast.Name}");
    if (ast.Parent is not null) {
      context.AppendLine($"  : {prefix}{ast.Parent}");
      if (!string.IsNullOrWhiteSpace(intf)) {
        context.AppendLine($"  , {intf}{ast.Name}");
      }
    } else if (!string.IsNullOrWhiteSpace(intf)) {
      context.AppendLine($"  : {intf}{ast.Name}");
    }

    context.AppendLine("{");
    foreach (IGqlpUnionMember item in ast.Items) {
      context.AppendLine("  public " + item.Name + " As" + item.Name + $" {{ {accessors} }}");
    }

    context.AppendLine("}");
  }
}
