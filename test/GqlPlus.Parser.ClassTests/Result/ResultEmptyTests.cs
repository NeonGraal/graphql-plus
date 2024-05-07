namespace GqlPlus.Result;

public class ResultEmptyTests : BaseResultTests
{
  private const string Empty = "Empty";
  private readonly IResult<string> _empty = Empty.Empty();

  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    string? result = _empty.Optional();

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
    IResult<int> result = _empty.Select(s => s.Length, () => 3.Ok());

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(3);
  }

  [Fact]
  public void SelectOk_ReturnsResultEmpty()
  {
    IResult<int> result = _empty.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultEmpty<int>>();
  }

  [Fact]
  public void SelectOk_WithOnReturnsResultOk()
  {
    IResult<int> result = _empty.SelectOk(s => s.Length, () => 3.Ok());

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(3);
  }
}
