namespace GqlPlus.Generating.Globals;

internal class CategoryGenerator
  : IGenerator<IAstSchemaCategory>
{
  public void Generate(IAstSchemaCategory ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Static) {
      context.Write(ast.Label + " " + ast.Name);
    }
  }
}
