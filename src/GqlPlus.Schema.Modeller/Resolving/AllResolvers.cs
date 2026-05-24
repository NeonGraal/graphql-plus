using GqlPlus.Resolving.Objects;
using GqlPlus.Resolving.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Resolving;

public static class AllResolvers
{
  public static IServiceCollection AddResolvers(this IServiceCollection services, Action<IResolverRepositoryBuilder> config)
    => services
      .AddSingleton(new ResolverRepositoryBuilder().FluentInterface(config))
      .AddSingleton<IResolverRepository, ResolverRepository>();

  internal static IResolverRepositoryBuilder AddSchemaResolvers(this IResolverRepositoryBuilder builder)
    => builder.ThrowIfNull()
      // Schema
      .AddResolver(SchemaResolver.Factory)
      .AddResolver(AllTypesResolver.Factory)
      .SimpleResolvers()
      .ObjectResolvers();

  private static IResolverRepositoryBuilder SimpleResolvers(this IResolverRepositoryBuilder builder)
    => builder
      .AddTypeResolver<BaseDomainModel<DomainLabelModel>>(TypeDomainEnumResolver.Factory)
      .AddTypeResolver<BaseDomainModel<DomainRangeModel>>(ResolverDomainType<DomainRangeModel>.Factory)
      .AddTypeResolver<BaseDomainModel<DomainRegexModel>>(ResolverDomainType<DomainRegexModel>.Factory)
      .AddTypeResolver<BaseDomainModel<DomainTrueFalseModel>>(ResolverDomainType<DomainTrueFalseModel>.Factory)
      .AddTypeResolver<TypeEnumModel>(TypeEnumResolver.Factory)
      .AddTypeResolver<TypeUnionModel>(TypeUnionResolver.Factory);

  private static IResolverRepositoryBuilder ObjectResolvers(this IResolverRepositoryBuilder builder)
    => builder
      .AddTypeResolver<TypeDualModel>(TypeDualResolver.Factory)
      .AddTypeResolver<TypeInputModel>(TypeInputResolver.Factory)
      .AddTypeResolver<TypeOutputModel>(TypeOutputResolver.Factory);
}
