namespace GqlPlus.Generating.Globals;

internal class DirectiveGenerator
  : IGenerator<IGqlpSchemaDirective>
{
  public void Generate(IGqlpSchemaDirective ast, GqlpGeneratorContext context)
    => context.AppendLine(ast.Label + " " + ast.Name);
}
