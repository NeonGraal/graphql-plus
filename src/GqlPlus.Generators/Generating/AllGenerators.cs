using GqlPlus.Ast.Schema;
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
      .AddGenerator<IAstSchemaCategory, CategoryGenerator>()
      .AddGenerator<IAstSchemaDirective, DirectiveGenerator>()
      .AddGenerator<IAstSchemaOption, OptionGenerator>();

  internal static IGeneratorRepositoryBuilder AddSchemaSimpleGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddAllFourTypeGenerators<DomainBooleanInterfaceGenerator, DomainBooleanModelGenerator, DomainBooleanDecoderGenerator, DomainBooleanEncoderGenerator>()
      .AddAllFourTypeGenerators<DomainEnumInterfaceGenerator, DomainEnumModelGenerator, DomainEnumDecoderGenerator, DomainEnumEncoderGenerator>()
      .AddAllFourTypeGenerators<DomainNumberInterfaceGenerator, DomainNumberModelGenerator, DomainNumberDecoderGenerator, DomainNumberEncoderGenerator>()
      .AddAllFourTypeGenerators<DomainStringInterfaceGenerator, DomainStringModelGenerator, DomainStringDecoderGenerator, DomainStringEncoderGenerator>()
      .AddTypeGenerator<EnumGenerator>(GqlpGeneratorType.Interface)
      .AddTypeGenerator<EnumDecoderGenerator>(GqlpGeneratorType.Dec)
      .AddTypeGenerator<EnumEncoderGenerator>(GqlpGeneratorType.Enc)
      .AddAllFourTypeGenerators<UnionInterfaceGenerator, UnionModelGenerator, UnionDecoderGenerator, UnionEncoderGenerator>();

  internal static IGeneratorRepositoryBuilder AddSchemaObjectGenerators(this IGeneratorRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddAllFourTypeGenerators<DualInterfaceGenerator, DualModelGenerator, DualDecoderGenerator, DualEncoderGenerator>()
      .AddAllFourTypeGenerators<InputInterfaceGenerator, InputModelGenerator, InputDecoderGenerator, InputEncoderGenerator>()
      .AddAllFourTypeGenerators<OutputInterfaceGenerator, OutputModelGenerator, OutputDecoderGenerator, OutputEncoderGenerator>();
}
