namespace GqlPlus.Generating.Globals;

internal class OptionGenerator
  : IGenerator<IGqlpSchemaOption>
{
  public void Generate(IGqlpSchemaOption ast, GeneratorContext context)
    => context.AppendLine(ast.Label + " " + ast.Name);
}
