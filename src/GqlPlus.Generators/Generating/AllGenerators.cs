using GqlPlus.Abstractions;
using GqlPlus.Generating.Globals;
using GqlPlus.Generating.Objects;
using GqlPlus.Generating.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Generating;

public static class AllGenerators
{
  public static IServiceCollection AddGenerators(this IServiceCollection services)
    => services
      .AddGenerator<IGqlpSchema, SchemaGenerator>()
      // Globals
      .AddGenerator<IGqlpSchemaCategory, CategoryGenerator>()
      .AddGenerator<IGqlpSchemaDirective, DirectiveGenerator>()
      .AddGenerator<IGqlpSchemaOption, OptionGenerator>()
      //Simple
      .AddTypeGenerator<EnumGenerator>()
      .AddTypeGenerator<BooleanDomainGenerator>()
      .AddTypeGenerator<EnumDomainGenerator>()
      .AddTypeGenerator<NumberDomainGenerator>()
      .AddTypeGenerator<StringDomainGenerator>()
      .AddTypeGenerator<UnionGenerator>()
      // Objects
      .AddTypeGenerator<DualGenerator>()
      .AddTypeGenerator<InputGenerator>()
      .AddTypeGenerator<OutputGenerator>()
    ;

  private static IServiceCollection AddGenerator<TAst, TGenerator>(this IServiceCollection services)
    where TAst : IGqlpError
    where TGenerator : class, IGenerator<TAst>
    => services.AddSingleton<IGenerator<TAst>, TGenerator>();

  private static IServiceCollection AddTypeGenerator<TGenerator>(this IServiceCollection services)
    where TGenerator : class, ITypeGenerator
    => services.AddSingleton<ITypeGenerator, TGenerator>();
}
