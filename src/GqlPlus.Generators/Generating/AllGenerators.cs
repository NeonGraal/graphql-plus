﻿using GqlPlus.Abstractions;
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
    ;

  private static IServiceCollection AddGenerator<TAst, TGenerator>(this IServiceCollection services)
    where TAst : IGqlpError
    where TGenerator : class, IGenerator<TAst>
    => services.AddSingleton<IGenerator<TAst>, TGenerator>();

  private static IServiceCollection AddDefaultGenerator<TAst>(this IServiceCollection services)
    where TAst : IGqlpDeclaration
    => services.AddSingleton<IGenerator<TAst>, GenerateDefault<TAst>>();

  private static IServiceCollection AddTypeGenerator<TGenerator>(this IServiceCollection services)
    where TGenerator : class, ITypeGenerator
    => services.AddSingleton<ITypeGenerator, TGenerator>();
}
