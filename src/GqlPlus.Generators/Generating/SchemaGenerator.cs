using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating;

internal sealed class SchemaGenerator(
  IGeneratorRepository generators
) : IGenerator<IAstSchema>
{
  public void Generate(IAstSchema ast, GqlpGeneratorContext context)
  {
    IAstType[] types = Typed<IAstType>(ast);
    context.AddTypes(types);

    context.WritePrefixLine("/*");
    Typed<IAstSchemaCategory>(ast).Generate(generators.GeneratorFor<IAstSchemaCategory>(), context);
    Typed<IAstSchemaDirective>(ast).Generate(generators.GeneratorFor<IAstSchemaDirective>(), context);
    Typed<IAstSchemaOption>(ast).Generate(generators.GeneratorFor<IAstSchemaOption>(), context);
    context.WritePrefixLine("*/");
    context.WritePrefixLine("");
    string nameSpace = context.GeneratorOptions.NameSpace.IfWhiteSpace(context.ModelOptions.BaseNamespace);
    context.WritePrefixLine($"namespace {nameSpace}.Gqlp_" + context.SafeFile + ";");

    GqlpGeneratorType generatorType = context.GeneratorOptions.GeneratorType;
    if (generators.TypeGenerators.TryGetValue(generatorType, out IEnumerable<ITypeGenerator>? typeGenerators)) {
      foreach (IAstType type in types) {
        ITypeGenerator? typeGenerator = typeGenerators.FirstOrDefault(IsForType);
        if (typeGenerator is null) {
          if (generators.TypeGenerators.TryGetValue(GqlpGeneratorType.Interface, out IEnumerable<ITypeGenerator>? interfaceGenerators)) {
            if (!interfaceGenerators.Any(IsForType)) {
              throw new InvalidOperationException("No Generator for " + type.GetType().ExpandTypeName());
            }
          }
        } else {
          typeGenerator!.GenerateType(type, context);
        }

        bool IsForType(ITypeGenerator typeGenerator)
          => typeGenerator.ForType(type);
      }
    }
  }

  private static TAst[] Typed<TAst>(IAstSchema ast)
    => ast.Declarations.ArrayOf<TAst>();
}
