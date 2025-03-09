namespace GqlPlus.Generating;

internal sealed class TypesGenerator
  : IGenerator<IGqlpType>
{
  public void Generate(IGqlpType ast, GeneratorContext context)
  {
    context.AppendLine("");

    string parent = "";

    if (ast is IGqlpType<string> simpleParent && !string.IsNullOrWhiteSpace(simpleParent.Parent)) {
      parent = " : " + simpleParent.Parent;
    }

    context.AppendLine($"public interface I{ast.Label}{ast.Name}{parent} {{}}");
  }
}
