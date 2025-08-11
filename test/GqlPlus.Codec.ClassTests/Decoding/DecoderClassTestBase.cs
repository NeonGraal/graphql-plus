using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using NSubstitute.ReceivedExtensions;

namespace GqlPlus.Decoding;

public abstract class DecoderClassTestBase<TOutput>
  : SubstituteBase
{
  protected abstract IDecoder<TOutput> Decoder { get; }

  internal static IDecoder<T> DFor<T>()
    => A.Of<IDecoder<T>>();
  internal static TDecoder DFor<TDecoder, T>()
    where TDecoder : class, IDecoder<T>
    => A.Of<TDecoder, IDecoder<T>>();
  public void DecodeReturns<T>([NotNull] IDecoder<T> decoder, T returns)
  {
    decoder.Decode(null!, out T? output).ReturnsForAnyArgs(x => {
      x[1] = returns;
      return Messages.New;
    });
  }
  public void DecodeReturns<TDecoder, T>([NotNull] TDecoder decoder, T returns)
    where TDecoder : class, IDecoder<T>
  {
    decoder.Decode(null!, out T? output).ReturnsForAnyArgs(x => {
      x[1] = returns;
      return Messages.New;
    });
  }

  public Action DecoderCalled<T>([NotNull] IDecoder<T> decoder, int count, [CallerArgumentExpression(nameof(decoder))] string? name = "")
    => () => decoder.ReceivedWithAnyArgs(new NamedQuantity(count, name)).Decode(null!, out T? _);

  internal void DecodeAndCheck(Structured input, TOutput? expected)
  {
    IMessages messages = Decoder.Decode(input, out TOutput? result);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeEquivalentTo(expected),
      MessagesEmpty(messages, result));
  }

  public Action MessagesEmpty(IMessages messages, TOutput? expected)
    => expected is null
      ? () => messages.ShouldContain(m => m.Level == MessageLevel.Error)
      : () => messages.ShouldNotContain(m => m.Level == MessageLevel.Error);

  internal void DecodeAndCheck(Structured input, TOutput? expected, string message)
  {
    IMessages messages = Decoder.Decode(input, out TOutput? result);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeEquivalentTo(expected),
      MessagesContain(messages, message));
  }

  public Action MessagesContain(IMessages messages, string message)
    => string.IsNullOrEmpty(message)
      ? () => messages.ShouldBeEmpty()
      : () => messages.ShouldContain(m => m.Message.Contains(message));

  private sealed class NamedQuantity(int count, string? name) : Quantity
  {
    public override string Describe(string singularNoun, string pluralNoun)
      => $"exactly {count} {(count == 1 ? singularNoun : pluralNoun)} on {name}";
    public override bool Matches<T>(IEnumerable<T> items) => count == items.Count();
    public override bool RequiresMoreThan<T>(IEnumerable<T> items) => count > items.Count();
  }
}
