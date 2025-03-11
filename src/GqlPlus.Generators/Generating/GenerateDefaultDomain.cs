namespace GqlPlus.Generating;

internal sealed class GenerateDefaultDomain
  : IDomainGenerator
{
  public bool ForDomain(IGqlpDomain ast) => throw new NotImplementedException();

  public void GenerateDomain(IGqlpDomain ast, GeneratorContext context)
  {
    context.AppendLine("");

    string parent = "";
    if (!string.IsNullOrWhiteSpace(ast.Parent)) {
      parent = " : " + ast.Parent;
    }

    context.AppendLine($"public interface I{ast.Label}{ast.Name}{parent} {{}}");
  }
}
