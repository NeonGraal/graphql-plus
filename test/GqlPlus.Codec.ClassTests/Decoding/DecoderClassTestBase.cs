using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using NSubstitute.ReceivedExtensions;
using Shouldly;

namespace GqlPlus.Decoding;

public abstract class DecoderClassTestBase<TModel>
  : SubstituteBase
{
  protected abstract IDecoder<TModel> Decoder { get; }

  internal static IDecoder<TM> DFor<TM>()
    => A.Of<IDecoder<TM>>();
  public void DecodeReturns<T>([NotNull] IDecoder<T> decoder, T returns)
  {
    decoder.Decode(null!, out T? output).ReturnsForAnyArgs(x => {
      x[1] = returns;
      return Messages.New;
    });
  }

  public Action DecoderCalled<T>([NotNull] IDecoder<T> decoder, int count, [CallerArgumentExpression(nameof(decoder))] string? name = "")
    => () => decoder.ReceivedWithAnyArgs(new NamedQuantity(count, name)).Decode(null!, out T? _);

  internal void DecodeAndCheck(Structured input, TModel? expected)
  {
    IMessages messages = Decoder.Decode(input, out TModel? result);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeEquivalentTo(expected),
      MessagesEmpty(messages, result));
  }

  public Action MessagesEmpty(IMessages messages, TModel? expected)
    => expected is null
      ? () => messages.ShouldContain(m => m.Level == MessageLevel.Error)
      : () => messages.ShouldNotContain(m => m.Level == MessageLevel.Error);

  internal void DecodeAndCheck(Structured input, TModel? expected, string message)
  {
    IMessages messages = Decoder.Decode(input, out TModel? result);

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
