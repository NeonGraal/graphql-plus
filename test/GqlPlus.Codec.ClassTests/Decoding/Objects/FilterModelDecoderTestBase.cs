using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Decoding.Objects;

public abstract class FilterModelDecoderTestBase<TModel>
  : DecoderClassTestBase<TModel>
  where TModel : FilterModel
{
  protected IDecoder<bool?> Boolean { get; } = DFor<bool?>();
  protected IDecoder<string> NameFilter { get; } = DFor<string>();

  protected FilterModelDecoderTestBase()
  {
    DecodeReturns(NameFilter, "");
    DecodeReturns(Boolean, false);
  }

  [Fact]
  public void Decode_Empty_ReturnsNull()
    => DecodeAndCheck(new(""), null);

  [Theory, RepeatData]
  public void Decode_All_ReturnsExpected(
    [NotNull] string[] names,
    bool matchAliases,
    [NotNull] string[] aliases,
    bool returnReferencedTypes,
    bool returnByAlias)
  {
    Map<Structured> input = new() {
      ["names"] = names.Encode(),
      ["matchAliases"] = matchAliases,
      ["aliases"] = aliases.Encode(),
      ["returnReferencedTypes"] = returnReferencedTypes,
      ["returnByAlias"] = returnByAlias
    };

    IMessages messages = Decoder.Decode(input.Encode(), out TModel? result);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(names.Length),
        () => result.Aliases.Length.ShouldBe(aliases.Length),
        DecoderCalled(Boolean, 3),
        DecoderCalled(NameFilter, names.Length + aliases.Length),
        () => messages.ShouldNotBeNull()
      );
  }

  [Theory, RepeatData]
  public void Decode_Name_ReturnsExpected(string name)
  {
    IMessages messages = Decoder.Decode(new[] { name }.Encode(), out TModel? result);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(1),
        DecoderCalled(NameFilter, 1),
        () => messages.ShouldNotBeNull()
      );
  }

  [Theory, RepeatData]
  public void Decode_Names_ReturnsExpected([NotNull] string[] names)
  {
    IMessages messages = Decoder.Decode(names.Encode(), out TModel? result);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(names.Length),
        DecoderCalled(NameFilter, names.Length),
        () => messages.ShouldNotBeNull()
      );
  }
}
