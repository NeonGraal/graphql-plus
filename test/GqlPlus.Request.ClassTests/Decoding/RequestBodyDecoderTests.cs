namespace GqlPlus.Decoding;

public class RequestBodyDecoderTests
{
  private readonly RequestBodyDecoder _decoder = new();

  [Fact]
  public void Decode_StringBody_ReturnsDefinition()
  {
    RequestBodyInput result = _decoder.Decode("_Schema { categories { name } }".Encode());

    result.ShouldSatisfyAllConditions(
      () => result.Definition.ShouldBe("_Schema { categories { name } }"),
      () => result.Category.ShouldBeNull(),
      () => result.Operation.ShouldBeNull(),
      () => result.Parameters.ShouldBeNull(),
      () => result.Errors.ShouldNotContain(m => m.Level == MessageLevel.Error));
  }

  [Fact]
  public void Decode_ListBody_FirstStringIsDefinition()
  {
    RequestBodyInput result = _decoder.Decode(new GqlpList(["_Schema { categories }".Encode()]));

    result.ShouldSatisfyAllConditions(
      () => result.Definition.ShouldBe("_Schema { categories }"),
      () => result.Errors.ShouldNotContain(m => m.Level == MessageLevel.Error));
  }

  [Fact]
  public void Decode_EmptyListBody_ReturnsError()
  {
    RequestBodyInput result = _decoder.Decode(new GqlpList([]));

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }

  [Fact]
  public void Decode_ListBodyWithoutStringDefinition_ReturnsError()
  {
    RequestBodyInput result = _decoder.Decode(new GqlpList([
      new GqlpScalar(42m),
      "_Schema { categories }".Encode(),
    ]));

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }

  [Fact]
  public void Decode_ListBodyWithMultipleParameters_RetainsAllParameters()
  {
    IGqlpValue firstParameter = "first".Encode();
    IGqlpValue secondParameter = "second".Encode();
    RequestBodyInput result = _decoder.Decode(new GqlpList([
      "_Schema { categories }".Encode(),
      firstParameter,
      secondParameter,
    ]));

    result.ShouldSatisfyAllConditions(
      () => result.Definition.ShouldBe("_Schema { categories }"),
      () => result.Parameters.ShouldBe(new GqlpList([firstParameter, secondParameter])),
      () => result.Errors.ShouldNotContain(m => m.Level == MessageLevel.Error));
  }

  [Fact]
  public void Decode_MapBody_ExtractsAllFields()
  {
    GqlpMap body = new([
      Field("category", "_Schema".Encode()),
      Field("definition", "{ categories { name } }".Encode()),
      Field("parameters", new GqlpMap([Field("limit", "10".Encode())])),
    ]);

    RequestBodyInput result = _decoder.Decode(body);

    result.ShouldSatisfyAllConditions(
      () => result.Category.ShouldBe("_Schema"),
      () => result.Definition.ShouldBe("{ categories { name } }"),
      () => result.Parameters.ShouldNotBeNull(),
      () => result.Errors.ShouldNotContain(m => m.Level == MessageLevel.Error));
  }

  [Fact]
  public void Decode_EmptyBody_ReturnsError()
  {
    RequestBodyInput result = _decoder.Decode(new GqlpUnit());

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }

  [Fact]
  public void Decode_NumberBody_ReturnsError()
  {
    RequestBodyInput result = _decoder.Decode(new GqlpScalar(42m));

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }

  [Fact]
  public void Decode_BooleanBody_ReturnsError()
  {
    RequestBodyInput result = _decoder.Decode(new GqlpScalar(true));

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }

  [Fact]
  public void Decode_MapBodyWithoutDefinition_ReturnsError()
  {
    RequestBodyInput result = _decoder.Decode(new GqlpMap([Field("category", "_Schema".Encode())]));

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }

  private static KeyValuePair<IGqlpScalar, IGqlpValue> Field(string key, IGqlpValue value)
    => new(new GqlpScalar(key, isIdentifier: true), value);
}
