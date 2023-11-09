namespace GqlPlus.Verifier.Result;

public class ResultOkTests
{
  private readonly string[] _sample = { "Sample" };

  private readonly IResult<string> _ok = "Ok".Ok();

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayOk()
  {
    var input = new[] { "Ok" }.Ok();

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayOk<string>>();
    result.Optional().Should().BeEquivalentTo(new object[] { "Ok" });
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayOk()
  {
    var result = _ok.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayEmpty<string>>();
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
