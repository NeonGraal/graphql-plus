namespace GqlPlus.Generating.Globals;

internal class OptionGenerator
  : IGenerator<IGqlpSchemaOption>
{
  public void Generate(IGqlpSchemaOption ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Static) {
      context.AppendLine(ast.Label + " " + ast.Name);
    }
  }
}
