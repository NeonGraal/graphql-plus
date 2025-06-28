using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Decoding;

public abstract class DecoderClassTestBase<TModel>
  : SubstituteBase
{
  protected abstract IDecoder<TModel> Decoder { get; }

  internal static IDecoder<TM> DFor<TM>()
    where TM : IModelBase
    => A.Of<IDecoder<TM>>();
  public void DecodeReturns<T>([NotNull] IDecoder<T> decoder, T returns)
    where T : IModelBase
    => decoder.Decode(null!).ReturnsForAnyArgs(returns);

  internal void DecodeAndCheck(Structured input, TModel? expected)
  {
    TModel? result = Decoder.Decode(input);

    result.ShouldBeEquivalentTo(expected);
  }
}
