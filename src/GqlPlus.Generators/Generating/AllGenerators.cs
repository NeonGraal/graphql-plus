using GqlPlus.Abstractions;
using GqlPlus.Generating.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Generating;

public static class AllGenerators
{
  public static IServiceCollection AddGenerators(this IServiceCollection services)
    => services
      .AddGenerator<IGqlpSchema, SchemaGenerator>()
      // Globals
      .AddDefaultGenerator<IGqlpSchemaCategory>()
      .AddDefaultGenerator<IGqlpSchemaDirective>()
      .AddDefaultGenerator<IGqlpSchemaOption>()
      //Simple
      .AddTypeGenerator<EnumGenerator>()
      .AddTypeGenerator<BooleanDomainGenerator>()
      .AddTypeGenerator<EnumDomainGenerator>()
      .AddTypeGenerator<NumberDomainGenerator>()
      .AddTypeGenerator<StringDomainGenerator>()
      .AddTypeGenerator<UnionGenerator>()
      // Objects
      .AddDefaultTypeGenerator<IGqlpDualObject>()
      .AddDefaultTypeGenerator<IGqlpInputObject>()
      .AddDefaultTypeGenerator<IGqlpOutputObject>()
    ;

  private static IServiceCollection AddGenerator<TAst, TGenerator>(this IServiceCollection services)
    where TAst : IGqlpError
    where TGenerator : class, IGenerator<TAst>
    => services.AddSingleton<IGenerator<TAst>, TGenerator>();

  private static IServiceCollection AddDefaultGenerator<TAst>(this IServiceCollection services)
    where TAst : IGqlpDeclaration
    => services.AddSingleton<IGenerator<TAst>, GenerateDefault<TAst>>();

  private static IServiceCollection AddDefaultTypeGenerator<TAst>(this IServiceCollection services)
    where TAst : IGqlpType
    => services.AddSingleton<ITypeGenerator, GenerateDefaultType<TAst>>();

  private static IServiceCollection AddTypeGenerator<TGenerator>(this IServiceCollection services)
    where TGenerator : class, ITypeGenerator
    => services.AddSingleton<ITypeGenerator, TGenerator>();
}
