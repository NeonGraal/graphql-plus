namespace GqlPlus.Verifier.Result;

public class ResultEmptyTests : BaseResultTests
{
  private const string Empty = "Empty";
  private readonly string[] _emptyArray = { "Empty" };

  [Fact]
  public void Array_AsPartial_ReturnsResultOk()
  {
    var input = _emptyArray.EmptyArray();

    var result = input.AsPartial(Sample);

    result.Should().BeOfType<ResultOk<string>>()
      .Subject.Optional().Should().Be(Sample);
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayEmpty()
  {
    var input = _emptyArray.Empty();

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void Array_Map_ReturnsOtherwise()
  {
    var input = _emptyArray.EmptyArray();

    var result = input.Map(a => a.Ok(), () => _sample.Ok());

    result.Should().BeOfType<ResultOk<string[]>>()
      .Subject.Required().Should().Equal(_sample);
  }

  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    var input = Empty.Empty();

    var result = input.Optional();

    result.Should().Be(default);
  }

  [Fact]
  public void Required_ThrowsInvalidOperation()
  {
    var input = Empty.Empty();

    Action action = () => input.Required();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain("empty");
  }

  [Fact]
  public void Select_WithOnReturnsResultOk()
  {
    var input = Empty.Empty();

    var result = input.Select(s => s.Length, () => 3.Ok());

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(3);
  }

  [Fact]
  public void SelectOk_ReturnsResultEmpty()
  {
    var input = Empty.Empty();

    var result = input.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultEmpty<int>>();
  }

  [Fact]
  public void SelectOk_WithOnReturnsResultOk()
  {
    var input = Empty.Empty();

    var result = input.SelectOk(s => s.Length, () => 3.Ok());

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(3);
  }
}
