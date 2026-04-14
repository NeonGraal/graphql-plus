namespace GqlPlus.Resolving;

internal class SchemaResolver(
  IResolverRepository resolvers
) : IResolver<SchemaModel>
{
  private readonly IResolver<BaseTypeModel> _type = resolvers.ResolverFor<BaseTypeModel>();

  public SchemaModel Resolve(SchemaModel model, IResolveContext context)
  {
    IMap<BaseTypeModel> types = model.Types.Values.Select(
      t => _type.Resolve(t, context))
      .ToMap(t => t.Name);

    return model with { Types = types, };
  }
}
