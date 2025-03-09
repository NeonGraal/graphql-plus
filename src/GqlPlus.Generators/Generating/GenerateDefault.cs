namespace GqlPlus.Generating;

internal sealed class GenerateDefault<TAst>
  : IGenerator<TAst>
  where TAst : IGqlpDeclaration
{
  public void Generate(TAst ast, GeneratorContext context)
    => context.AppendLine(ast.Label + " " + ast.Name);
}
