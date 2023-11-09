namespace GqlPlus.Verifier.Result;

public class ResultEmptyTests
{
  private readonly string[] _sample = { "Sample" };
  private readonly IResult<string> _empty = "Empty".Empty();

  [Fact]
  public void AsResultArray_ReturnsResultArrayEmpty()
  {
    var result = _empty.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    var result = _empty.Optional();

    result.Should().Be(default);
  }

  [Fact]
  public void Required_ThrowsInvalidOperation()
  {
    Action action = () => _empty.Required();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain("empty");
  }

  [Fact]
  public void Select_WithOnReturnsResultOk()
  {
    var result = _empty.Select(s => s.Length, () => 3.Ok());

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(3);
  }

  [Fact]
  public void SelectOk_ReturnsResultEmpty()
  {
    var result = _empty.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultEmpty<int>>();
  }

  [Fact]
  public void SelectOk_WithOnReturnsResultOk()
  {
    var result = _empty.SelectOk(s => s.Length, () => 3.Ok());

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(3);
  }
}
