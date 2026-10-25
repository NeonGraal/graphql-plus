namespace GqlPlus.Encoding;

internal class BaseEncoder<TModel>
  : IEncoder<TModel>
  where TModel : IModelBase
{
  IGqlpValue IEncoder<TModel>.Encode(TModel model)
    => Encode(model);

  internal virtual IGqlpValue Encode(TModel model)
    => new GqlpMap([], model.Tag);
}
