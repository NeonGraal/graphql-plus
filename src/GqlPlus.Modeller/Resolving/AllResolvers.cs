using GqlPlus.Models;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Resolving;

public static class AllResolvers
{
  public static IServiceCollection AddResolvers(this IServiceCollection services)
  => services
      // Schema
      .AddResolver<SchemaModel, SchemaResolver>()
      .AddResolver<BaseTypeModel, AllTypesResolver>()
      // Simple
      .AddDomainResolver<DomainMemberModel>()
      .AddDomainResolver<DomainRangeModel>()
      .AddDomainResolver<DomainRegexModel>()
      .AddDomainResolver<DomainTrueFalseModel>()
      .AddTypeResolver<TypeEnumModel, TypeEnumResolver>()
      .AddTypeResolver<TypeUnionModel, TypeUnionResolver>()
      // Object
      .AddTypeResolver<TypeDualModel, TypeDualResolver>()
      .AddTypeResolver<TypeInputModel, TypeInputResolver>()
      .AddTypeResolver<TypeOutputModel, TypeOutputResolver>()
    ;

  private static IServiceCollection AddResolver<TModel, TResolver>(this IServiceCollection services)
    where TModel : IModelBase
    where TResolver : class, IResolver<TModel>
    => services.AddSingleton<IResolver<TModel>, TResolver>();

  private static IServiceCollection AddTypeResolver<TModel, TResolver>(this IServiceCollection services)
    where TModel : IModelBase
    where TResolver : class, IResolver<TModel>, ITypeResolver
  => services
      .AddSingleton<TResolver>()
      .AddProvider<TResolver, IResolver<TModel>>()
      .AddProvider<TResolver, ITypeResolver>();

  private static IServiceCollection AddDomainResolver<TDomain>(this IServiceCollection services)
    where TDomain : BaseDomainItemModel
  => services
      .AddSingleton<ResolverDomainType<TDomain>>()
      .AddProvider<ResolverDomainType<TDomain>, IResolver<BaseDomainModel<TDomain>>>()
      .AddProvider<ResolverDomainType<TDomain>, ITypeResolver>();
}
