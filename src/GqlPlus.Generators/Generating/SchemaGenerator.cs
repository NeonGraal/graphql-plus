namespace GqlPlus.Generating;

internal sealed class SchemaGenerator(
  IGenerator<IGqlpSchemaCategory> categoryGenerator,
  IGenerator<IGqlpSchemaDirective> directiveGenerator,
  IGenerator<IGqlpSchemaOption> optionGenerator,
  IEnumerable<ITypeGenerator> typeGenerators
) : IGenerator<IGqlpSchema>
{
  public void Generate(IGqlpSchema ast, GqlpGeneratorContext context)
  {
    IGqlpType[] types = Typed<IGqlpType>(ast);
    context.AddTypes(types);

    context.WritePrefixLine("/*");
    Typed<IGqlpSchemaCategory>(ast).Generate(categoryGenerator, context);
    Typed<IGqlpSchemaDirective>(ast).Generate(directiveGenerator, context);
    Typed<IGqlpSchemaOption>(ast).Generate(optionGenerator, context);
    context.WritePrefixLine("*/");
    context.WritePrefixLine("");
    string nameSpace = context.GeneratorOptions.NameSpace.IfWhiteSpace(context.ModelOptions.BaseNamespace);
    context.WritePrefixLine($"namespace {nameSpace}.Gqlp_" + context.SafeFile + ";");

    foreach (IGqlpType type in types) {
      ITypeGenerator generator = typeGenerators.Where(g => g.ForType(type)).FirstOrDefault();
      if (generator is null) {
        throw new InvalidOperationException("No Generator for " + type.GetType().ExpandTypeName());
      } else {
        generator.GenerateType(type, context);
      }
    }
  }

  private static TAst[] Typed<TAst>(IGqlpSchema ast)
    => ast.Declarations.ArrayOf<TAst>();
}
