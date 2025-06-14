namespace GqlPlus.Generating;

internal sealed class GenerateDefaultType<TAst>
  : ITypeGenerator
  where TAst : IGqlpType
{
  public bool ForType(IGqlpType ast)
    => ast is TAst;

  public void GenerateType(IGqlpType ast, GeneratorContext context)
  {
    context.AppendLine("");

    if (ast is IGqlpType<IGqlpTypeRef> simpleParent && !string.IsNullOrWhiteSpace(simpleParent.Parent?.Name)) {
      context.AppendLine($"// Parent {simpleParent.Parent}");
    }

    context.AppendLine($"public interface I{ast.Label}{ast.Name} {{}}");
  }
}
