namespace GqlPlus.Encoding.Objects;

public abstract class ObjectArgEncoderBase<TModel, TArg>
  : EncoderClassTestBase<TModel>
  where TModel : IModelBase
  where TArg : IModelBase
{
  protected IEncoder<TArg> ObjArg { get; }

  protected ObjectArgEncoderBase()
    => ObjArg = RFor<TArg>();
}
