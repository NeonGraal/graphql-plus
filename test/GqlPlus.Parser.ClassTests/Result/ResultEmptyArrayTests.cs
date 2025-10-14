namespace GqlPlus.Result;

public class ResultEmptyArrayTests : TestResultBase
{
  private const string Empty = "Empty";
  private readonly IResultArray<string> _emptyArray = new[] { "Empty" }.EmptyArray();
  private readonly IResult<string> _empty = Empty.Empty();
  private readonly IResult<string[]> _emptyArrayResult = Array.Empty<string>().Empty();

  // Abstract method implementations
  protected override IResult<string> CreateResult() => _empty;
  protected override IResult<string[]> CreateArrayResult() => _emptyArrayResult;
  protected override IResultArray<string> CreateResultArray() => _emptyArray;

  protected override bool ExpectedIsEmpty => true;
  protected override string? ExpectedOptionalValue => null;
  protected override bool ExpectedRequiredThrows => true;
  protected override string? ExpectedMessage => null;

  protected override bool ExpectedArrayRequiredThrows => true;
  protected override IEnumerable<string>? ExpectedArrayOptionalValue => Array.Empty<string>();

  protected override bool ExpectedActionCalled => true;

  [Fact]
  public void AsResultArray_ReturnsResultArrayEmpty()
  {
    IResultArray<string> result = _emptyArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayEmpty<string>>();
  }
}
