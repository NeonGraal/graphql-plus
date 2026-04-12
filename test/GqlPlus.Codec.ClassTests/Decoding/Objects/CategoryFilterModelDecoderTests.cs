using System.Diagnostics.CodeAnalysis;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Decoding.Objects;

public class CategoryFilterModelDecoderTests
  : FilterModelDecoderTestBase<CategoryFilterModel>
{
  private IDecoder<CategoryOption?> Resolution { get; }
    = DFor<CategoryOption?>();

  public CategoryFilterModelDecoderTests()
  {
    IDecoderRepository decoders = A.Of<IDecoderRepository>();
    decoders.DecoderFor<bool?>().Returns(Boolean);
    decoders.NameFilterDecoder.Returns(NameFilter);
    decoders.DecoderFor<CategoryOption?>().Returns(Resolution);
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

    DecodeReturns(Resolution, CategoryOption.Parallel);

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
