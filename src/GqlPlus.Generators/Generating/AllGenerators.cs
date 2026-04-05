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
      .AddTypeGenerator(GqlpGeneratorType.Enum, new EnumGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, new DomainBooleanInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, new DomainBooleanModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, new DomainEnumInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, new DomainEnumModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, new DomainNumberInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, new DomainNumberModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, new DomainStringInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, new DomainStringModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, new UnionInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, new UnionModelGenerator());

  internal static IGeneratorRepositoryBuilder AddSchemaObjectGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddTypeGenerator(GqlpGeneratorType.Interface, new DualInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, new DualModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, new InputInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, new InputModelGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Interface, new OutputInterfaceGenerator())
      .AddTypeGenerator(GqlpGeneratorType.Model, new OutputModelGenerator());
}
