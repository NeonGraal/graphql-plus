using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating.Globals;

internal class DirectiveGenerator
  : IGenerator<IAstSchemaDirective>
{
  public void Generate(IAstSchemaDirective ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Static) {
      context.Write(ast.Label + " " + ast.Name);
    }
  }
}
