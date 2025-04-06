﻿namespace GqlPlus.Generating;

internal sealed class SchemaGenerator(
  IGenerator<IGqlpSchemaCategory> categoryGenerator,
  IGenerator<IGqlpSchemaDirective> directiveGenerator,
  IGenerator<IGqlpSchemaOption> optionGenerator,
  IEnumerable<ITypeGenerator> typeGenerators
) : IGenerator<IGqlpSchema>
{
  private static readonly ITypeGenerator s_default = new GenerateDefaultType();

  public void Generate(IGqlpSchema ast, GeneratorContext context)
  {
    IGqlpType[] types = Typed<IGqlpType>(ast);
    context.AddTypes(types);

    Typed<IGqlpSchemaCategory>(ast).Generate(categoryGenerator, context);
    Typed<IGqlpSchemaDirective>(ast).Generate(directiveGenerator, context);
    Typed<IGqlpSchemaOption>(ast).Generate(optionGenerator, context);

    context.AppendLine("*/\n");
    context.AppendLine($"namespace {context.Options.BaseNamespace}.Model_" + context.SafeFile + ";");

    foreach (IGqlpType type in types) {
      ITypeGenerator generator = typeGenerators.Where(g => g.ForType(type)).FirstOrDefault() ?? s_default;
      generator.GenerateType(type, context);
    }
  }

  private static TAst[] Typed<TAst>(IGqlpSchema ast)
    => ast.Declarations.ArrayOf<TAst>();
}
