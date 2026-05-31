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
    => DecodeAndCheck("".Encode(), null);

  [Theory, RepeatData]
  public void Decode_All_ReturnsExpected(
    [NotNull] string[] names,
    bool matchAliases,
    [NotNull] string[] aliases,
    bool returnReferencedTypes,
    bool returnByAlias)
  {
    Map<Structured> input = new() {
      ["names"] = names.ThrowIfNull().Encode(),
      ["matchAliases"] = matchAliases.ThrowIfNull().Encode(),
      ["aliases"] = aliases.ThrowIfNull().Encode(),
      ["returnReferencedTypes"] = returnReferencedTypes.ThrowIfNull().Encode(),
      ["returnByAlias"] = returnByAlias.ThrowIfNull().Encode()
    };

    IMessages messages = Decoder.ThrowIfNull().Decode(input.ThrowIfNull().Encode(), out TModel? result);

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
    IMessages messages = Decoder.ThrowIfNull().Decode(new[] { name }.Encode(), out TModel? result);

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
    IMessages messages = Decoder.ThrowIfNull().Decode(names.ThrowIfNull().Encode(), out TModel? result);

    result.ThrowIfNull().ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(names.Length),
        DecoderCalled(NameFilter, names.ThrowIfNull().Length),
        MessagesEmpty(messages, result)
      );
  }
}
