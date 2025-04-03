namespace GqlPlus.Result;

public class ResultEmptyTests : BaseResultTests
{
  private const string Empty = "Empty";
  private readonly IResult<string> _empty = Empty.Empty();

  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    string? result = _empty.Optional();

    result.ShouldBe(default);
  }

  [Fact]
  public void Required_ThrowsInvalidOperation()
  {
    Action action = () => _empty.Required();

    action.ShouldThrow<InvalidOperationException>()
      .Message.ShouldContain("empty");
  }

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
