namespace GqlPlus.Resolving;

internal class SchemaResolver(
  IResolver<BaseTypeModel> type
) : IResolver<SchemaModel>
{
  public SchemaModel Resolve(SchemaModel model, IResolveContext context)
  {
    IMap<BaseTypeModel> types = model.Types.Values.Select(
      t => type.Resolve(t, context))
      .ToMap(t => t.Name);

    return model with { Types = types, };
  }
}
