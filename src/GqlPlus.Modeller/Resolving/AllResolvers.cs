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
      .AddResolver<SchemaModel>(r => new SchemaResolver(r))
      .AddResolver<BaseTypeModel>(r => new AllTypesResolver(r))
      // Simple
      .AddTypeResolver<BaseDomainModel<DomainLabelModel>>(_ => new TypeDomainEnumResolver())
      .AddTypeResolver<BaseDomainModel<DomainRangeModel>>(_ => new ResolverDomainType<DomainRangeModel>())
      .AddTypeResolver<BaseDomainModel<DomainRegexModel>>(_ => new ResolverDomainType<DomainRegexModel>())
      .AddTypeResolver<BaseDomainModel<DomainTrueFalseModel>>(_ => new ResolverDomainType<DomainTrueFalseModel>())
      .AddTypeResolver<TypeEnumModel>(_ => new TypeEnumResolver())
      .AddTypeResolver<TypeUnionModel>(_ => new TypeUnionResolver())
      // Object
      .AddTypeResolver<TypeDualModel>(_ => new TypeDualResolver())
      .AddTypeResolver<TypeInputModel>(r => new TypeInputResolver(r))
      .AddTypeResolver<TypeOutputModel>(r => new TypeOutputResolver(r));
}
