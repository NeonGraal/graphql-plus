using GqlPlus.Token;

namespace GqlPlus.Result;

public class ResultOkTests : BaseResultTests
{
  private const string Ok = "Ok";
  private readonly IResult<string> _ok = Ok.Ok();
  private readonly IResult<string[]> _okArray = new[] { Ok }.Ok();

  [Fact]
  public void AsResultArray_ReturnsResultArrayOk()
  {
    IResultArray<string> result = _ok.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayEmpty<string>>();
  }

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
