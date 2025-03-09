using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal sealed class SchemaGenerator(
  IGenerator<IGqlpSchemaCategory> category,
  IGenerator<IGqlpSchemaDirective> directive,
  IGenerator<IGqlpSchemaOption> option,
  IEnumerable<ITypeGenerator> types
) : IGenerator<IGqlpSchema>
{
  private static readonly ITypeGenerator s_Default = new GenerateDefaultType();

  public void Generate(IGqlpSchema ast, GeneratorContext context)
  {
    Typed<IGqlpSchemaCategory>(ast).Generate(category, context);
    Typed<IGqlpSchemaDirective>(ast).Generate(directive, context);
    Typed<IGqlpSchemaOption>(ast).Generate(option, context);

    context.AppendLine("*/\n");
    context.AppendLine($"namespace {context.Options.BaseNamespace}.Model_" + context.File + ";");

    foreach (IGqlpType type in Typed<IGqlpType>(ast)) {
      ITypeGenerator generator = types.Where(g => g.ForType(type)).FirstOrDefault() ?? s_Default;
      generator.GenerateType(type, context);
    }
  }

  private static TAst[] Typed<TAst>(IGqlpSchema ast)
    => ast.Declarations.ArrayOf<TAst>();
}
