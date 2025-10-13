namespace GqlPlus.Result;

public class ResultOkArrayTests : TestResultBase
{
  private const string Ok = "Ok";
  private readonly IResultArray<string> _okArray = new[] { Ok }.OkArray();
  private readonly IResult<string> _ok = Ok.Ok();
  private readonly IResult<string[]> _okArrayResult = new[] { Ok }.Ok();

  // Abstract method implementations
  protected override IResult<string> CreateResult() => _ok;
  protected override IResult<string[]> CreateArrayResult() => _okArrayResult;
  protected override IResultArray<string> CreateResultArray() => _okArray;

  protected override bool ExpectedHasValue => true;
  protected override bool ExpectedIsOk => true;
  protected override string? ExpectedOptionalValue => Ok;
  protected override string? ExpectedMessage => null;

  protected override IEnumerable<string>? ExpectedArrayOptionalValue => new[] { Ok };

  protected override bool ExpectedWithValueCalled => true;
  protected override bool ExpectedActionCalled => true;

  [Fact]
  public void AsResultArray_ReturnsResultArrayOk()
  {
    IResultArray<string> result = _okArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayOk<string>>();
    result.Optional().ShouldBe(new object[] { Ok });
  }
}
