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

    Typed<IGqlpSchemaCategory>(ast).Generate(categoryGenerator, context);
    Typed<IGqlpSchemaDirective>(ast).Generate(directiveGenerator, context);
    Typed<IGqlpSchemaOption>(ast).Generate(optionGenerator, context);

    context.WritePrefix("*/\n");
    string nameSpace = context.GeneratorOptions.NameSpace.IfWhiteSpace(context.ModelOptions.BaseNamespace);
    context.WritePrefix($"namespace {nameSpace}.Gqlp_" + context.SafeFile + ";");

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
