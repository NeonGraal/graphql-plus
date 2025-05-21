namespace GqlPlus.Resolving;

internal abstract class ResolverType<TModel>
  : IResolver<TModel>
  , ITypeResolver
  where TModel : BaseTypeModel
{
  public abstract TModel Resolve(TModel model, IResolveContext context);

  public BaseTypeModel ResolveType(BaseTypeModel model, IResolveContext context)
    => Resolve((TModel)model, context);

  bool ITypeResolver.ForType(BaseTypeModel model)
    => model is TModel;
}

internal interface ITypeResolver
{
  bool ForType(BaseTypeModel model);
  BaseTypeModel ResolveType(BaseTypeModel model, IResolveContext context);
}
