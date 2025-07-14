namespace GqlPlus.Decoding.Objects;

public class FilterModelDecoderTests
  : FilterModelDecoderTestBase<FilterModel>
{

  public FilterModelDecoderTests()
    => Decoder = new FilterModelDecoder(Boolean, NameFilter);

  protected override IDecoder<FilterModel> Decoder { get; }
}
