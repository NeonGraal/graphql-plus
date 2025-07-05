using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using NSubstitute.ReceivedExtensions;

namespace GqlPlus.Decoding;

public abstract class DecoderClassTestBase<TModel>
  : SubstituteBase
{
  protected abstract IDecoder<TModel> Decoder { get; }

  internal static IDecoder<TM> DFor<TM>()
    => A.Of<IDecoder<TM>>();
  public void DecodeReturns<T>([NotNull] IDecoder<T> decoder, T returns)
    => decoder.Decode(null!).ReturnsForAnyArgs(returns);

  public Action DecoderCalled<T>([NotNull] IDecoder<T> decoder, int count, [CallerArgumentExpression(nameof(decoder))] string? name = "")
    => () => decoder.ReceivedWithAnyArgs(new NamedQuantity(count, name)).Decode(null!);

  internal void DecodeAndCheck(Structured input, TModel? expected)
  {
    TModel? result = Decoder.Decode(input);

    result.ShouldBeEquivalentTo(expected);
  }

  private sealed class NamedQuantity(int count, string? name) : Quantity
  {
    public override string Describe(string singularNoun, string pluralNoun)
      => $"exactly {count} {(count == 1 ? singularNoun : pluralNoun)} on {name}";
    public override bool Matches<T>(IEnumerable<T> items) => count == items.Count();
    public override bool RequiresMoreThan<T>(IEnumerable<T> items) => count > items.Count();
  }
}
