﻿namespace GqlPlus.Encoding.Objects;

public class DualAlternateEncoderTests
  : ObjectBaseEncoderBase<ObjAlternateModel, DualBaseModel>
{
  private readonly IEncoder<CollectionModel> _collection;
  private readonly IEncoder<ObjBaseModel> _objBaseEncoder;

  public DualAlternateEncoderTests()
  {
    _collection = RFor<CollectionModel>();
    _objBaseEncoder = A.Of<IEncoder<ObjBaseModel>>();
    Encoder = new ObjectAlternateEncoder<ObjAlternateModel>(new(_collection, _objBaseEncoder));
  }

  protected override IEncoder<ObjAlternateModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithDual(string dual)
  {
    DualBaseModel objBase = new(dual, "");
    _objBaseEncoder.Encode(objBase).Returns(new Structured(dual));
    EncodeAndCheck(new(objBase), [
        "!_ObjAlternate",
        "type: " + dual
      ]);
  }
}
