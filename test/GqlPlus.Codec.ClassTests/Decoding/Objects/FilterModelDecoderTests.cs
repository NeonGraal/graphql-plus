namespace GqlPlus.Decoding.Objects;

public class FilterModelDecoderTests
  : FilterModelDecoderTestBase<FilterModel>
{

  public FilterModelDecoderTests()
  {
    IDecoderRepository decoders = A.Of<IDecoderRepository>();
    decoders.DecoderFor<bool?>().Returns(Boolean);
    decoders.NameFilterDecoder.Returns(NameFilter);
    Decoder = new FilterModelDecoder(decoders);
  }

  protected override IDecoder<FilterModel> Decoder { get; }
}
