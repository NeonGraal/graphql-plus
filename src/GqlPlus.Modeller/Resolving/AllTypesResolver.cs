namespace GqlPlus.Resolving;

internal class AllTypesResolver(
  IResolverRepository resolvers
) : IResolver<BaseTypeModel>
{
  private readonly IResolverRepository _resolvers = resolvers;

  public BaseTypeModel Resolve(BaseTypeModel model, IResolveContext context)
    => _resolvers.TypeResolvers.SingleOrDefault(t => t.ForType(model))?.ResolveType(model, context) ?? model;
}
