namespace GqlPlus.Resolving;

internal class AllTypesResolver(
  IResolverRepository resolvers
) : IResolver<BaseTypeModel>
{
  private readonly DeferList<ITypeResolver> _typeResolvers = resolvers.TypeResolvers();

  public BaseTypeModel Resolve(BaseTypeModel model, IResolveContext context)
    => _typeResolvers.SingleOrDefault(t => t.ForType(model))?.ResolveType(model, context) ?? model;

  internal static AllTypesResolver Factory(IResolverRepository r) => new(r);
}
