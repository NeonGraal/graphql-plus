namespace GqlPlus.Result;

public class ResultPartialArrayTests : TestResultBase
{
  private const string Partial = "Partial";
  private readonly IResultArray<string> _partialArray = new[] { Partial }.PartialArray(Partial.ParseMessage());
  private readonly IResult<string> _partial = Partial.Partial(Partial.ParseMessage());
  private readonly IResult<string[]> _partialArrayResult = new[] { Partial }.Partial(Partial.ParseMessage());

  // Abstract method implementations
  protected override IResult<string> CreateResult() => _partial;
  protected override IResult<string[]> CreateArrayResult() => _partialArrayResult;
  protected override IResultArray<string> CreateResultArray() => _partialArray;

  protected override bool ExpectedHasValue => true;
  protected override bool ExpectedIsError => true;
  protected override string? ExpectedOptionalValue => Partial;
  protected override bool ExpectedRequiredThrows => true;
  protected override string? ExpectedMessage => Partial;

  protected override Type ExpectedAsResultType => typeof(ResultError<int>);
  protected override Type ExpectedAsPartialType => typeof(ResultPartial<string>);
  protected override Type ExpectedSelectType => typeof(ResultPartial<int>);
  protected override Type ExpectedAsResultArrayType => typeof(ResultArrayPartial<string>);
  protected override Type ExpectedAsPartialArrayType => typeof(ResultArrayPartial<string>);
  protected override Type ExpectedArrayAsResultArrayType => typeof(ResultArrayError<int>);
  protected override Type ExpectedArrayAsPartialArrayType => typeof(ResultArrayPartial<string>);

  protected override bool ExpectedArrayRequiredThrows => true;
  protected override IEnumerable<string>? ExpectedArrayOptionalValue => [Partial];

  protected override bool ExpectedWithValueCalled => true;
  protected override bool ExpectedActionCalled => true;

  [Fact]
  public void AsResultArray_ReturnsResultArrayPartial()
  {
    IResultArray<string> result = _partialArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayPartial<string>>()
      .Message.Message.ShouldBe(Partial);
    result.Optional().ShouldBe(new object[] { Partial });
  }

  [Fact]
  public void AsResultArrayObject_ReturnsResultArrayPartialObject()
  {
    IResultArray<object> result = _partialArray.AsResultArray<object>();

    result.ShouldBeOfType<ResultArrayPartial<object>>()
      .Message.Message.ShouldBe("Partial");
  }

  [Fact]
  public void AsResultObject_ReturnsResultPartialObject()
  {
    IResult<object> result = _partialArray.AsResult<object>();

    result.ShouldBeOfType<ResultPartial<object>>()
      .Message.Message.ShouldBe("Partial");
  }
}
