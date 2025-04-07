namespace GqlPlus.Generating.Objects;

internal abstract class GenerateObjectBase<TObj>
  : GenerateForType<TObj>
  where TObj : IGqlpObject
{
  protected override void Generate(TObj ast, GeneratorContext context)
  {
    context.AppendLine("");

    if (ast is IGqlpType<string> simpleParent && !string.IsNullOrWhiteSpace(simpleParent.Parent)) {
      context.AppendLine($"// Parent {simpleParent.Parent}");
    }

    context.AppendLine($"public interface I{ast.Label}{ast.Name} {{}}");
  }
}
