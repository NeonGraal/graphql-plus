namespace GqlPlus.Generating.Globals;

internal abstract class GlobalSchemaGenerator<TAst>
  : IGenerator<TAst>
  where TAst : IAstDeclaration
{
  public void Generate(TAst ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Static) {
      context.Write(ast.Label + " " + ast.Name);
    }
  }
}
