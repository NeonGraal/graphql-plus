using GqlPlus.Resolving.Objects;
using GqlPlus.Resolving.Simple;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Resolving;

public static class AllResolvers
{
  public static IServiceCollection AddResolvers(this IServiceCollection services)
  {
    ResolverRepositoryBuilder builder = new();
    builder.AddSchemaResolvers();
    services.AddSingleton(builder);
    services.TryAddSingleton<IResolverRepository, ResolverRepository>();
    return services;
  }

  internal static IResolverRepositoryBuilder AddSchemaResolvers(this IResolverRepositoryBuilder builder)
    => builder.ThrowIfNull()
      // Schema
      .AddResolver<SchemaModel>(SchemaResolver.Factory)
      .AddResolver<BaseTypeModel>(AllTypesResolver.Factory)
      // Simple
      .AddTypeResolver<BaseDomainModel<DomainLabelModel>>(TypeDomainEnumResolver.Factory)
      .AddTypeResolver<BaseDomainModel<DomainRangeModel>>(ResolverDomainType<DomainRangeModel>.Factory)
      .AddTypeResolver<BaseDomainModel<DomainRegexModel>>(ResolverDomainType<DomainRegexModel>.Factory)
      .AddTypeResolver<BaseDomainModel<DomainTrueFalseModel>>(ResolverDomainType<DomainTrueFalseModel>.Factory)
      .AddTypeResolver<TypeEnumModel>(TypeEnumResolver.Factory)
      .AddTypeResolver<TypeUnionModel>(TypeUnionResolver.Factory)
      // Object
      .AddTypeResolver<TypeDualModel>(TypeDualResolver.Factory)
      .AddTypeResolver<TypeInputModel>(TypeInputResolver.Factory)
      .AddTypeResolver<TypeOutputModel>(TypeOutputResolver.Factory);
}
