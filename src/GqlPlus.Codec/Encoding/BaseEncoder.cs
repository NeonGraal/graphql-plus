namespace GqlPlus.Encoding;

internal class BaseEncoder<TModel>
  : IEncoder<TModel>
  where TModel : IModelBase
{
  Structured IEncoder<TModel>.Encode(TModel model)
    => Encode(model);

  internal virtual Structured Encode(TModel model)
    => new Map<Structured>().Encode(model.Tag);
}
