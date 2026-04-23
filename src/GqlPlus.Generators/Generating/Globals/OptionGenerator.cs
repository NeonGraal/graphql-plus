namespace GqlPlus.Generating.Globals;

internal class OptionGenerator
  : IGenerator<IAstSchemaOption>
{
  public void Generate(IAstSchemaOption ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Static) {
      context.Write(ast.Label + " " + ast.Name);
    }
  }
}
