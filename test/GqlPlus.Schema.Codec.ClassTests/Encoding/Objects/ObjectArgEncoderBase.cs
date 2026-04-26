namespace GqlPlus.Encoding.Objects;

public abstract class ObjectArgEncoderBase<TModel>
  : EncoderClassTestBase<TModel>
  where TModel : IModelBase
{
  protected IEncoder<TypeArgModel> TypeArg { get; }

  protected ObjectArgEncoderBase()
    => TypeArg = RFor<TypeArgModel>();
}
