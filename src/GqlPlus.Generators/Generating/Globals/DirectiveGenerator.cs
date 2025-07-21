namespace GqlPlus.Generating.Globals;

internal class DirectiveGenerator
  : IGenerator<IGqlpSchemaDirective>
{
  public void Generate(IGqlpSchemaDirective ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Static) {
      context.AppendLine(ast.Label + " " + ast.Name);
    }
  }
}
