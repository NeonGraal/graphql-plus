namespace GqlPlus.Resolving;

internal class AllTypesResolver(
  IResolverRepository resolvers
) : IResolver<BaseTypeModel>
{
  private readonly Defer<ITypeResolver>.LA _typeResolvers = resolvers.TypeResolvers();

  public BaseTypeModel Resolve(BaseTypeModel model, IResolveContext context)
    => _typeResolvers.IA.SingleOrDefault(t => t.ForType(model))?.ResolveType(model, context) ?? model;

  internal static AllTypesResolver Factory(IResolverRepository r) => new(r);
}
