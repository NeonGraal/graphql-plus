namespace GqlPlus.Result;

public class ResultOkTests : TestResultBase
{
  private const string Ok = "Ok";
  private readonly IResult<string> _ok = Ok.Ok();
  private readonly IResult<string[]> _okArray = new[] { Ok }.Ok();
  private readonly IResultArray<string> _okResultArray = new[] { Ok }.OkArray();

  // Abstract method implementations
  protected override IResult<string> CreateResult() => _ok;
  protected override IResult<string[]> CreateArrayResult() => _okArray;
  protected override IResultArray<string> CreateResultArray() => _okResultArray;

  protected override bool ExpectedHasValue => true;
  protected override bool ExpectedIsOk => true;
  protected override string? ExpectedOptionalValue => Ok;
  protected override string? ExpectedMessage => null;

  protected override IEnumerable<string>? ExpectedArrayOptionalValue => new[] { Ok };

  protected override bool ExpectedWithValueCalled => true;
  protected override bool ExpectedActionCalled => true;

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayOk()
  {
    IResultArray<string> result = _okArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayOk<string>>();
    result.Optional().ShouldBe([Ok]);
  }

  [Fact]
  public void Select_WithLength_ReturnsResultOk()
  {
    IResult<int> result = _ok.Select(s => s.Length);

    result.ShouldBeOfType<ResultOk<int>>()
      .Optional().ShouldBe(2);
  }

  [Fact]
  public void Select_WithNull_ReturnsResultEmpty()
  {
    IResult<ITokenizer> result = _ok.Select(s => (ITokenizer?)null);

    result.ShouldBeOfType<ResultEmpty<ITokenizer>>();
  }
}
