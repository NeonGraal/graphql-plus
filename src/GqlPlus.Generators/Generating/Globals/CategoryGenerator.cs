namespace GqlPlus.Generating.Globals;

internal class CategoryGenerator
  : IGenerator<IGqlpSchemaCategory>
{
  public void Generate(IGqlpSchemaCategory ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Static) {
      context.AppendLine(ast.Label + " " + ast.Name);
    }
  }
}
