namespace GqlPlus.Decoding.Objects;

public class FilterModelDecoderTests
  : FilterModelDecoderTestBase<FilterModel>
{

  public FilterModelDecoderTests()
  {
    IDecoderRepository decoders = A.Of<IDecoderRepository>();
    decoders.DecoderForReturns(Boolean);
    decoders.DecoderForReturns<INameFilterDecoder, string>(NameFilter);
    Decoder = new FilterModelDecoder(decoders);
  }

  protected override IDecoder<FilterModel> Decoder { get; }
}
