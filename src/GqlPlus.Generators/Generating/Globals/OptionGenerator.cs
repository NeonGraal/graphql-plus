namespace GqlPlus.Generating.Globals;

internal class OptionGenerator
  : IGenerator<IGqlpSchemaOption>
{
  public void Generate(IGqlpSchemaOption ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Static) {
      context.Write(ast.Label + " " + ast.Name);
    }
  }
}
