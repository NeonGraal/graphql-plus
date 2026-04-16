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
    GenerateTypesForGeneratorType(types, generatorType, context);

    if (generatorType == GqlpGeneratorType.Dec && context.DecoderRegistrations.Count > 0) {
      GenerateDecoderRegistration(context);
    }

    if (generatorType == GqlpGeneratorType.Enc && context.EncoderRegistrations.Count > 0) {
      GenerateEncoderRegistration(context);
    }
  }

  private void GenerateTypesForGeneratorType(IAstType[] types, GqlpGeneratorType generatorType, GqlpGeneratorContext context)
  {
    if (!generators.TypeGenerators.TryGetValue(generatorType, out IEnumerable<ITypeGenerator>? typeGenerators)) {
      return;
    }

    foreach (IAstType type in types) {
      GenerateTypeOrValidate(typeGenerators, type, context);
    }
  }

  private void GenerateTypeOrValidate(IEnumerable<ITypeGenerator> typeGenerators, IAstType type, GqlpGeneratorContext context)
  {
    ITypeGenerator? typeGenerator = typeGenerators.FirstOrDefault(tg => tg.ForType(type));
    if (typeGenerator is not null) {
      typeGenerator.GenerateType(type, context);
      return;
    }

    if (generators.TypeGenerators.TryGetValue(GqlpGeneratorType.Interface, out IEnumerable<ITypeGenerator>? interfaceGenerators)
        && !interfaceGenerators.Any(tg => tg.ForType(type))) {
      throw new InvalidOperationException("No Generator for " + type.GetType().ExpandTypeName());
    }
  }

  private static void GenerateDecoderRegistration(GqlpGeneratorContext context)
  {
    string typePrefix = context.ModelOptions.TypePrefix;
    string safeFile = context.SafeFile;
    string className = $"{typePrefix}_{safeFile}Decoders";
    string methodName = $"Add{typePrefix}_{safeFile}Decoders";

    context.Write("");
    context.Write($"internal static class {className}");
    context.Write("{");
    context.Write($"  internal static IDecoderRepositoryBuilder {methodName}(this IDecoderRepositoryBuilder builder)");
    context.Write("    => builder");

    IReadOnlyList<CodecRegistration> registrations = context.DecoderRegistrations;
    for (int i = 0; i < registrations.Count; i++) {
      CodecRegistration reg = registrations[i];
      string separator = i < registrations.Count - 1 ? "" : ";";
      context.Write($"      .AddDecoder<{reg.ServiceType}>({reg.ImplType}.Factory){separator}");
    }

    context.Write("}");
  }

  private static void GenerateEncoderRegistration(GqlpGeneratorContext context)
  {
    string typePrefix = context.ModelOptions.TypePrefix;
    string safeFile = context.SafeFile;
    string className = $"{typePrefix}_{safeFile}Encoders";
    string methodName = $"Add{typePrefix}_{safeFile}Encoders";

    context.Write("");
    context.Write($"internal static class {className}");
    context.Write("{");
    context.Write($"  internal static IEncoderRepositoryBuilder {methodName}(this IEncoderRepositoryBuilder builder)");
    context.Write("    => builder");

    IReadOnlyList<CodecRegistration> registrations = context.EncoderRegistrations;
    for (int i = 0; i < registrations.Count; i++) {
      CodecRegistration reg = registrations[i];
      string separator = i < registrations.Count - 1 ? "" : ";";
      context.Write($"      .AddEncoder<{reg.ServiceType}>({reg.ImplType}.Factory){separator}");
    }

    context.Write("}");
  }

  private static TAst[] Typed<TAst>(IAstSchema ast)
    => ast.Declarations.ArrayOf<TAst>();

  internal static SchemaGenerator Factory(IGeneratorRepository g) => new(g);
}
