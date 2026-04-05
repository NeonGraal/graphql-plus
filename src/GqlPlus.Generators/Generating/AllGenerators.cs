using GqlPlus.Generating.Globals;
using GqlPlus.Generating.Objects;
using GqlPlus.Generating.Simple;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Generating;

public static class AllGenerators
{
  public static IServiceCollection AddGenerators(this IServiceCollection services)
  {
    GeneratorRepositoryBuilder builder = new();
    builder.AddSchemaGenerators();
    services.AddSingleton(builder);
    services.TryAddSingleton<IGeneratorRepository, GeneratorRepository>();
    return services;
  }

  internal static IGeneratorRepositoryBuilder AddSchemaGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddGenerator(g => new SchemaGenerator(g))
      .AddSchemaGlobalGenerators()
      .AddSchemaSimpleGenerators()
      .AddSchemaObjectGenerators();

  internal static IGeneratorRepositoryBuilder AddSchemaGlobalGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddGenerator(_ => new CategoryGenerator())
      .AddGenerator(_ => new DirectiveGenerator())
      .AddGenerator(_ => new OptionGenerator());

  internal static IGeneratorRepositoryBuilder AddSchemaSimpleGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddTypeGenerator(GqlpGeneratorType.Enum, _ => new EnumGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, _ => new DomainBooleanInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, _ => new DomainBooleanModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, _ => new DomainEnumInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, _ => new DomainEnumModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, _ => new DomainNumberInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, _ => new DomainNumberModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, _ => new DomainStringInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, _ => new DomainStringModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, _ => new UnionInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, _ => new UnionModelGenerator());

  internal static IGeneratorRepositoryBuilder AddSchemaObjectGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddTypeGenerator(GqlpGeneratorType.Interface, _ => new DualInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, _ => new DualModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, _ => new InputInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, _ => new InputModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, _ => new OutputInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, _ => new OutputModelGenerator());
}
