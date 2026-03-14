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
    services.AddSingleton(builder.Build());
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
      .AddTypeGenerator(_ => new DomainBooleanGenerator())
      .AddTypeGenerator(_ => new DomainEnumGenerator())
      .AddTypeGenerator(_ => new DomainNumberGenerator())
      .AddTypeGenerator(_ => new DomainStringGenerator())
      .AddTypeGenerator(_ => new UnionGenerator());

  internal static IGeneratorRepositoryBuilder AddSchemaObjectGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddTypeGenerator(_ => new DualGenerator())
      .AddTypeGenerator(_ => new InputGenerator())
      .AddTypeGenerator(_ => new OutputGenerator());
}
