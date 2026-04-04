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
      .AddTypeGenerator(_ => new EnumGenerator())
      .AddTypeGenerator(_ => new DomainBooleanInterfaceGenerator())
      .AddTypeGenerator(_ => new DomainBooleanModelGenerator())
      .AddTypeGenerator(_ => new DomainEnumInterfaceGenerator())
      .AddTypeGenerator(_ => new DomainEnumModelGenerator())
      .AddTypeGenerator(_ => new DomainNumberInterfaceGenerator())
      .AddTypeGenerator(_ => new DomainNumberModelGenerator())
      .AddTypeGenerator(_ => new DomainStringInterfaceGenerator())
      .AddTypeGenerator(_ => new DomainStringModelGenerator())
      .AddTypeGenerator(_ => new UnionInterfaceGenerator())
      .AddTypeGenerator(_ => new UnionModelGenerator());

  internal static IGeneratorRepositoryBuilder AddSchemaObjectGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddTypeGenerator(_ => new DualInterfaceGenerator())
      .AddTypeGenerator(_ => new DualModelGenerator())
      .AddTypeGenerator(_ => new InputInterfaceGenerator())
      .AddTypeGenerator(_ => new InputModelGenerator())
      .AddTypeGenerator(_ => new OutputInterfaceGenerator())
      .AddTypeGenerator(_ => new OutputModelGenerator());
}
