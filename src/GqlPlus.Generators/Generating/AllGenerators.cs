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
      .AddGenerator<IGqlpSchemaCategory, CategoryGenerator>()
      .AddGenerator<IGqlpSchemaDirective, DirectiveGenerator>()
      .AddGenerator<IGqlpSchemaOption, OptionGenerator>();

  internal static IGeneratorRepositoryBuilder AddSchemaSimpleGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddBothTypeGenerators<DomainBooleanInterfaceGenerator, DomainBooleanModelGenerator>()
      .AddBothTypeGenerators<DomainEnumInterfaceGenerator, DomainEnumModelGenerator>()
      .AddBothTypeGenerators<DomainNumberInterfaceGenerator, DomainNumberModelGenerator>()
      .AddBothTypeGenerators<DomainStringInterfaceGenerator, DomainStringModelGenerator>()
      .AddTypeGenerator<EnumGenerator>(GqlpGeneratorType.Interface)
      .AddBothTypeGenerators<UnionInterfaceGenerator, UnionModelGenerator>();

  internal static IGeneratorRepositoryBuilder AddSchemaObjectGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddBothTypeGenerators<DualInterfaceGenerator, DualModelGenerator>()
      .AddBothTypeGenerators<InputInterfaceGenerator, InputModelGenerator>()
      .AddBothTypeGenerators<OutputInterfaceGenerator, OutputModelGenerator>();
}
