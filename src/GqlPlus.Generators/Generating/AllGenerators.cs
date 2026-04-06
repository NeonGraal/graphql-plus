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
      .AddBothTypeGenerators(_ => new DomainBooleanInterfaceGenerator(), _ => new DomainBooleanModelGenerator())
      .AddBothTypeGenerators(_ => new DomainEnumInterfaceGenerator(), _ => new DomainEnumModelGenerator())
      .AddBothTypeGenerators(_ => new DomainNumberInterfaceGenerator(), _ => new DomainNumberModelGenerator())
      .AddBothTypeGenerators(_ => new DomainStringInterfaceGenerator(), _ => new DomainStringModelGenerator())
      .AddBothTypeGenerators(_ => new UnionInterfaceGenerator(), _ => new UnionModelGenerator());

  internal static IGeneratorRepositoryBuilder AddSchemaObjectGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddBothTypeGenerators(_ => new DualInterfaceGenerator(), _ => new DualModelGenerator())
      .AddBothTypeGenerators(_ => new InputInterfaceGenerator(), _ => new InputModelGenerator())
      .AddBothTypeGenerators(_ => new OutputInterfaceGenerator(), _ => new OutputModelGenerator());
}
