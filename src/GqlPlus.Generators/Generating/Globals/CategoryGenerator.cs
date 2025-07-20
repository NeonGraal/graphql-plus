namespace GqlPlus.Generating.Globals;

internal class CategoryGenerator
  : IGenerator<IGqlpSchemaCategory>
{
  public void Generate(IGqlpSchemaCategory ast, GqlpGeneratorContext context)
    => context.AppendLine(ast.Label + " " + ast.Name);
}
