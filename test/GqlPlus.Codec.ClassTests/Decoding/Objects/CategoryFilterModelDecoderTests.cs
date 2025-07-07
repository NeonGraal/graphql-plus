using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Decoding.Objects;

public class CategoryFilterModelDecoderTests
  : FilterModelDecoderTestBase<CategoryFilterModel>
{
  private IDecoder<CategoryOption> Resolution { get; }
    = DFor<CategoryOption>();

  public CategoryFilterModelDecoderTests()
    => Decoder = new CategoryFilterModelDecoder(Boolean, NameFilter, Resolution);

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

    IMessages messages = Decoder.Decode(input.Encode(), out CategoryFilterModel? result);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(names.Length),
        () => result.Resolutions.Length.ShouldBe(resolutions.Length),
        DecoderCalled(NameFilter, names.Length),
        DecoderCalled(Resolution, resolutions.Length)
      );
    messages.ShouldNotBeNull();
  }
}
