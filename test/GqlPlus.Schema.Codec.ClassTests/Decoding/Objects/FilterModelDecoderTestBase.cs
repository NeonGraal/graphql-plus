using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Decoding.Objects;

public abstract class FilterModelDecoderTestBase<TModel>
  : DecoderClassTestBase<TModel>
  where TModel : FilterModel
{
  protected IDecoder<bool?> Boolean { get; } = DFor<bool?>();
  internal INameFilterDecoder NameFilter { get; } = DFor<INameFilterDecoder, string>();

  protected FilterModelDecoderTestBase()
  {
    DecodeReturns(NameFilter, "");
    DecodeReturns(Boolean, false);
  }

  [Fact]
  public void Decode_Empty_ReturnsNull()
    => DecodeAndCheck(new ScalarValue(""), null);

  [Theory, RepeatData]
  public void Decode_All_ReturnsExpected(
    [NotNull] string[] names,
    bool matchAliases,
    [NotNull] string[] aliases,
    bool returnReferencedTypes,
    bool returnByAlias)
  {
    IValue input = DecoderTestValue.FromMap([
      new("names", DecoderTestValue.FromList(names.Select(name => (IValue)new ScalarValue(name)))),
      new("matchAliases", new ScalarValue(matchAliases)),
      new("aliases", DecoderTestValue.FromList(aliases.Select(alias => (IValue)new ScalarValue(alias)))),
      new("returnReferencedTypes", new ScalarValue(returnReferencedTypes)),
      new("returnByAlias", new ScalarValue(returnByAlias)),
    ]);

    IMessages messages = Decoder.ThrowIfNull().Decode(input.ThrowIfNull(), out TModel? result);

    result.ThrowIfNull().ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.ThrowIfNull().Names.Length.ShouldBe(names.ThrowIfNull().Length),
        () => result.ThrowIfNull().Aliases.Length.ShouldBe(aliases.ThrowIfNull().Length),
        DecoderCalled(Boolean, 3),
        DecoderCalled(NameFilter, names.ThrowIfNull().Length + aliases.ThrowIfNull().Length),
        MessagesEmpty(messages, result)
      );
  }

  [Theory, RepeatData]
  public void Decode_Name_ReturnsExpected(string name)
  {
    IMessages messages = Decoder.ThrowIfNull().Decode(DecoderTestValue.FromList([new ScalarValue(name)]), out TModel? result);

    result.ThrowIfNull().ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(1),
        DecoderCalled(NameFilter, 1),
        MessagesEmpty(messages, result)
      );
  }

  [Theory, RepeatData]
  public void Decode_Names_ReturnsExpected([NotNull] string[] names)
  {
    IMessages messages = Decoder.ThrowIfNull().Decode(
      DecoderTestValue.FromList(names.Select(name => (IValue)new ScalarValue(name))), out TModel? result);

    result.ThrowIfNull().ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(names.Length),
        DecoderCalled(NameFilter, names.ThrowIfNull().Length),
        MessagesEmpty(messages, result)
      );
  }
}
