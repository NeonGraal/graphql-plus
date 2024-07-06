using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Resolving;

public static class AllResolvers
{
  public static IServiceCollection AddResolvers(this IServiceCollection services)
  => services
      // Schema
      .AddResolver<SchemaModel, SchemaResolver>()
      .AddResolver<BaseTypeModel, AllTypesResolver>()
    // Domain
    //.AddDomainResolver<DomainMemberModel, DomainMemberResolver>()
    //.AddDomainResolver<DomainRangeModel, DomainRangeResolver>()
    //.AddDomainResolver<DomainRegexModel, DomainRegexResolver>()
    //.AddDomainResolver<DomainTrueFalseModel, DomainTrueFalseResolver>()
    //.AddTypeResolver<TypeEnumModel, TypeEnumResolver>()
    //.AddTypeResolver<TypeUnionModel, TypeUnionResolver>()
    // Object
    //.AddTypeResolver<TypeDualModel, TypeDualResolver>()
    //.AddTypeResolver<TypeInputModel, TypeInputResolver>()
    //.AddTypeResolver<TypeOutputModel, TypeOutputResolver>()
    ;

  private static IServiceCollection AddResolver<TModel, TResolver>(this IServiceCollection services)
    where TModel : IModelBase
    where TResolver : class, IResolver<TModel>
    => services.AddSingleton<IResolver<TModel>, TResolver>();
}
