namespace GqlPlus.Encoding.Objects;

public abstract class ObjectBaseEncoderBase<TModel, TBase>
  : EncoderClassTestBase<TModel>
  where TModel : IModelBase
  where TBase : IModelBase
{
  protected IEncoder<TBase> ObjBase { get; }

  protected ObjectBaseEncoderBase()
    => ObjBase = RFor<TBase>();
}
