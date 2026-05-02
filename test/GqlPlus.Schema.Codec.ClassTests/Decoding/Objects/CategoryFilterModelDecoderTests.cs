using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Decoding.Objects;

public class CategoryFilterModelDecoderTests
  : FilterModelDecoderTestBase<CategoryFilterModel>
{
  private IDecoder<CategoryOptionModel?> Resolution { get; }
    = DFor<CategoryOptionModel?>();

  public CategoryFilterModelDecoderTests()
  {
    IDecoderRepository decoders = A.Of<IDecoderRepository>();
    decoders.DecoderForReturns(Boolean);
    decoders.DecoderForReturns<INameFilterDecoder, string>(NameFilter);
    decoders.DecoderForReturns(Resolution);
    Decoder = new CategoryFilterModelDecoder(decoders);
  }

  protected override IDecoder<CategoryFilterModel> Decoder { get; }

  [Theory, RepeatData]
  public void Decode_NamesAndResolutions_ReturnsExpected(
    [NotNull] string[] names,
    [NotNull] CategoryOption[] resolutions)
  {
    Map<Structured> input = new() {
      ["names"] = names.Encode(),
      ["resolutions"] = resolutions.Encode()
    };

    DecodeReturns(Resolution, CategoryOptionModel.Parallel);

    IMessages messages = Decoder.Decode(input.Encode(), out CategoryFilterModel? result);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(names.Length),
        () => result.Resolutions.Length.ShouldBe(resolutions.Length),
        DecoderCalled(NameFilter, names.Length),
        DecoderCalled(Resolution, resolutions.Length),
        MessagesEmpty(messages, result)
      );
  }
}
