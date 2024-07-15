namespace GqlPlus.Resolving;

internal class AllTypesResolver(
  IEnumerable<ITypeResolver> types
) : IResolver<BaseTypeModel>
{
  public BaseTypeModel Resolve(BaseTypeModel model, IResolveContext context)
    => types.SingleOrDefault(t => t.ForType(model))?.ResolveType(model, context) ?? model;
}
