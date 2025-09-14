namespace GqlPlus.Encoding.Objects;

public abstract class ObjectArgEncoderBase<TModel>
  : EncoderClassTestBase<TModel>
  where TModel : IModelBase
{
  protected IEncoder<ObjTypeArgModel> ObjArg { get; }

  protected ObjectArgEncoderBase()
    => ObjArg = RFor<ObjTypeArgModel>();
}
