namespace GqlPlus.Generating;

internal sealed class SchemaGenerator(
  IGeneratorRepository generators
) : IGenerator<IGqlpSchema>
{
  public void Generate(IGqlpSchema ast, GqlpGeneratorContext context)
  {
    IGqlpType[] types = Typed<IGqlpType>(ast);
    context.AddTypes(types);

    context.WritePrefixLine("/*");
    Typed<IGqlpSchemaCategory>(ast).Generate(generators.GeneratorFor<IGqlpSchemaCategory>(), context);
    Typed<IGqlpSchemaDirective>(ast).Generate(generators.GeneratorFor<IGqlpSchemaDirective>(), context);
    Typed<IGqlpSchemaOption>(ast).Generate(generators.GeneratorFor<IGqlpSchemaOption>(), context);
    context.WritePrefixLine("*/");
    context.WritePrefixLine("");
    string nameSpace = context.GeneratorOptions.NameSpace.IfWhiteSpace(context.ModelOptions.BaseNamespace);
    context.WritePrefixLine($"namespace {nameSpace}.Gqlp_" + context.SafeFile + ";");

    foreach (IGqlpType type in types) {
      ITypeGenerator? generator = generators.TypeGenerators.FirstOrDefault(g => g.ForType(type));
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
