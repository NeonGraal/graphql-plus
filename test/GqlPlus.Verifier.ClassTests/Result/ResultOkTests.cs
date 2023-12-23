using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Result;

public class ResultOkTests : BaseResultTests
{
  private const string Ok = "Ok";
  private readonly IResult<string> _ok = Ok.Ok();
  private readonly IResult<string[]> _okArray = new[] { Ok }.Ok();

  [Fact]
  public void AsResultArray_ReturnsResultArrayOk()
  {
    var result = _ok.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayOk()
  {
    var result = _okArray.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayOk<string>>();
    result.Optional().Should().Equal(Ok);
  }

  [Fact]
  public void Select_WithLength_ReturnsResultOk()
  {
    var result = _ok.Select(s => s.Length);

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(2);
  }

  [Fact]
  public void Select_WithNull_ReturnsResultEmpty()
  {
    var result = _ok.Select(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultEmpty<Tokenizer>>();
  }

  [Fact]
  public void SelectWithLength_ReturnsResultOk()
  {
    var result = _ok.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(2);
  }

  [Fact]
  public void SelectWithNull_ReturnsResultEmpty()
  {
    var result = _ok.SelectOk(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultEmpty<Tokenizer>>();
  }
}
