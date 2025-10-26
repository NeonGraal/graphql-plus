namespace GqlPlus.Result;

public class ResultPartialTests : TestResultBase
{
  private const string Partial = "Partial";
  private readonly IResult<string> _partial = Partial.Partial(Partial.ParseMessage());
  private readonly IResult<string[]> _partialArray = new[] { Partial }.Partial(Partial.ParseMessage());
  private readonly IResultArray<string> _partialResultArray = new[] { Partial }.PartialArray(Partial.ParseMessage());

  // Abstract method implementations
  protected override IResult<string> CreateResult() => _partial;
  protected override IResult<string[]> CreateArrayResult() => _partialArray;
  protected override IResultArray<string> CreateResultArray() => _partialResultArray;

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
  public void Array_AsResultArray_ReturnsResultArrayError()
  {
    IResultArray<string> result = _partialArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayPartial<string>>()
      .Message.Message.ShouldBe(Partial);
    result.Optional().ShouldBe([Partial]);
  }

  [Fact]
  public void Select_WithLength_ReturnsResultPartial()
  {
    IResult<int> result = _partial.Select(s => s.Length);

    result.ShouldBeOfType<ResultPartial<int>>()
      .Message.Message.ShouldContain(Partial);
    result.Optional().ShouldBe(7);
  }

  [Fact]
  public void Select_WithNull_ReturnsResultPartial()
  {
    IResult<ITokenizer> result = _partial.Select(s => (ITokenizer?)null);

    result.ShouldBeOfType<ResultError<ITokenizer>>()
      .Message.Message.ShouldBe(Partial);
  }

  [Fact]
  public void SelectOk_WithLength_ReturnsResultError()
  {
    IResult<int> result = _partial.SelectOk(s => s.Length);

    result.ShouldBeOfType<ResultError<int>>()
      .Message.Message.ShouldBe(Partial);
  }

  [Fact]
  public void SelectOk_WithNull_ReturnsResultError()
  {
    IResult<ITokenizer> result = _partial.SelectOk(s => (ITokenizer?)null);

    result.ShouldBeOfType<ResultError<ITokenizer>>()
      .Message.Message.ShouldBe(Partial);
  }
}
