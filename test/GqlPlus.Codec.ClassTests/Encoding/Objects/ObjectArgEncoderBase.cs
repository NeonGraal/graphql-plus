namespace GqlPlus.Encoding.Objects;

public abstract class ObjectArgEncoderBase<TModel>
  : EncoderClassTestBase<TModel>
  where TModel : IModelBase
{
  protected IEncoder<ObjTypeArgModel> ObjTypeArg { get; }

  protected ObjectArgEncoderBase()
    => ObjTypeArg = RFor<ObjTypeArgModel>();
}
