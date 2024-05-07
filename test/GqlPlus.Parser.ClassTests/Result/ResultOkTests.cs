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

    result.Should().BeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayOk()
  {
    IResultArray<string> result = _okArray.AsResultArray(SampleArray);

    result.Should().BeOfType<ResultArrayOk<string>>();
    result.Optional().Should().Equal(Ok);
  }

  [Fact]
  public void Select_WithLength_ReturnsResultOk()
  {
    IResult<int> result = _ok.Select(s => s.Length);

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(2);
  }

  [Fact]
  public void Select_WithNull_ReturnsResultEmpty()
  {
    IResult<Tokenizer> result = _ok.Select(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultEmpty<Tokenizer>>();
  }

  [Fact]
  public void SelectWithLength_ReturnsResultOk()
  {
    IResult<int> result = _ok.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(2);
  }

  [Fact]
  public void SelectWithNull_ReturnsResultEmpty()
  {
    IResult<Tokenizer> result = _ok.SelectOk(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultEmpty<Tokenizer>>();
  }
}
