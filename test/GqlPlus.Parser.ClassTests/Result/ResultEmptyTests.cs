namespace GqlPlus.Result;

public class ResultEmptyTests : TestResultBase
{
  private const string Empty = "Empty";
  private readonly IResult<string> _empty = Empty.Empty();
  private readonly IResult<string[]> _emptyArray = Array.Empty<string>().Empty();
  private readonly IResultArray<string> _emptyResultArray = Array.Empty<string>().EmptyArray();

  // Abstract method implementations
  protected override IResult<string> CreateResult() => _empty;
  protected override IResult<string[]> CreateArrayResult() => _emptyArray;
  protected override IResultArray<string> CreateResultArray() => _emptyResultArray;

  protected override bool ExpectedIsEmpty => true;
  protected override bool ExpectedRequiredThrows => true;
  protected override string? ExpectedOptionalValue => null;
  protected override string? ExpectedMessage => null;

  protected override bool ExpectedArrayRequiredThrows => true;
  protected override IEnumerable<string>? ExpectedArrayOptionalValue => [];

  protected override bool ExpectedActionCalled => true;

  [Fact]
  public void Select_WithOnReturnsResultOk()
  {
    IResult<int> result = _empty.Select(s => s.Length, () => 3.Ok());

    result.ShouldBeOfType<ResultOk<int>>()
      .Optional().ShouldBe(3);
  }

  [Fact]
  public void SelectOk_ReturnsResultEmpty()
  {
    IResult<int> result = _empty.SelectOk(s => s.Length);

    result.ShouldBeOfType<ResultEmpty<int>>();
  }

  [Fact]
  public void SelectOk_WithOnReturnsResultOk()
  {
    IResult<int> result = _empty.SelectOk(s => s.Length, () => 3.Ok());

    result.ShouldBeOfType<ResultOk<int>>()
      .Optional().ShouldBe(3);
  }
}
