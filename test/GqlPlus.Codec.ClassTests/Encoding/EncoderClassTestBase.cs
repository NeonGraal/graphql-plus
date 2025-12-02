using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Encoding;

public abstract class EncoderClassTestBase<TModel>
  : SubstituteBase
  where TModel : IModelBase
{
  protected abstract IEncoder<TModel> Encoder { get; }

  internal static IEncoder<TM> RFor<TM>()
    where TM : IModelBase
    => A.Of<IEncoder<TM>>();
  public void EncodeReturnsMap<T>([NotNull] IEncoder<T> encoder, string tag, object? value)
    where T : IModelBase
  {
    Map<Structured> returns = new() { ["value"] = new($"{value}", tag) };
    encoder.Encode(default!).ReturnsForAnyArgs(returns.Encode());
  }
  public void EncodeReturns<T>([NotNull] IEncoder<T> encoder, T model, Structured returns)
    where T : IModelBase
    => encoder.Encode(model).ReturnsForAnyArgs(returns);

  internal void EncodeAndCheck(TModel model, string[] expected)
    => Encoder.Encode(model)
      .ShouldNotBeNull()
      .ToPlain(false)
      .ShouldBe(expected);
}
