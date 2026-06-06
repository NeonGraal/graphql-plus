using GqlPlus.Decoding;
using GqlPlus.Structures;

namespace GqlPlus.Request.Decoding;

public class RequestBodyDecoderTests
{
  private readonly RequestBodyDecoder _decoder = new();

  [Fact]
  public void Decode_StringBody_ReturnsDefinition()
  {
    Structured body = "_Schema { categories { name } }".Encode();

    RequestBodyInput result = _decoder.Decode(body);

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
    Structured body = new(["_Schema { categories }".Encode()]);

    RequestBodyInput result = _decoder.Decode(body);

    result.ShouldSatisfyAllConditions(
      () => result.Definition.ShouldBe("_Schema { categories }"),
      () => result.Errors.ShouldNotContain(m => m.Level == MessageLevel.Error));
  }

  [Fact]
  public void Decode_MapBody_ExtractsAllFields()
  {
    Structured body = new(new Dictionary<StructureValue, Structured> {
      [new StructureValue("category")] = "_Schema".Encode(),
      [new StructureValue("definition")] = "{ categories { name } }".Encode(),
      [new StructureValue("parameters")] = new(new Dictionary<StructureValue, Structured> {
        [new StructureValue("limit")] = "10".Encode(),
      }),
    });

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
    Structured body = Structured.Empty();

    RequestBodyInput result = _decoder.Decode(body);

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }

  [Fact]
  public void Decode_NumberBody_ReturnsError()
  {
    Structured body = new(new StructureValue(42m));

    RequestBodyInput result = _decoder.Decode(body);

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }

  [Fact]
  public void Decode_BooleanBody_ReturnsError()
  {
    Structured body = new(new StructureValue(true));

    RequestBodyInput result = _decoder.Decode(body);

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }

  [Fact]
  public void Decode_MapBodyWithoutDefinition_ReturnsError()
  {
    Structured body = new(new Dictionary<StructureValue, Structured> {
      [new StructureValue("category")] = "_Schema".Encode(),
    });

    RequestBodyInput result = _decoder.Decode(body);

    result.Errors.ShouldContain(m => m.Level == MessageLevel.Error);
  }
}
