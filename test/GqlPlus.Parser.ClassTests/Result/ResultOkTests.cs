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
    IResult<Tokenizer> result = _ok.Select(s => (Tokenizer?)null);

    result.ShouldBeOfType<ResultEmpty<Tokenizer>>();
  }

  [Fact]
  public void SelectWithLength_ReturnsResultOk()
  {
    IResult<int> result = _ok.SelectOk(s => s.Length);

    result.ShouldBeOfType<ResultOk<int>>()
      .Optional().ShouldBe(2);
  }

  [Fact]
  public void SelectWithNull_ReturnsResultEmpty()
  {
    IResult<Tokenizer> result = _ok.SelectOk(s => (Tokenizer?)null);

    result.ShouldBeOfType<ResultEmpty<Tokenizer>>();
  }
}
