namespace GqlPlus.Result;

public class ResultEmptyArrayTests : BaseResultTests
{
  private const string Empty = "Empty";
  private readonly IResultArray<string> _emptyArray = new[] { "Empty" }.EmptyArray();

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    bool withValue = false;
    bool action = false;

    IResult<string> result = _emptyArray.AsPartial(Sample, v => withValue = true, () => action = true);

    result.Should().BeOfType<ResultOk<string>>();
    using AssertionScope scope = new();
    result.Optional().Should().Be(Sample);
    withValue.Should().BeFalse();
    action.Should().BeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultOk()
  {
    bool withValue = false;

    IResultArray<string> result = _emptyArray.AsPartialArray(SampleArray, v => withValue = true);

    result.Should().BeOfType<ResultArrayOk<string>>();
    using AssertionScope scope = new();
    result.Optional().Should().Equal(Sample);
    withValue.Should().BeFalse();
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayEmpty()
  {
    IResultArray<string> result = _emptyArray.AsResultArray(SampleArray);

    result.Should().BeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayEmptyInt()
  {
    IResultArray<int> result = _emptyArray.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayEmpty<int>>();
  }

  [Fact]
  public void AsResultInt_ReturnsResultEmptyInt()
  {
    IResult<int> result = _emptyArray.AsResult<int>();

    result.Should().BeOfType<ResultEmpty<int>>();
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _emptyArray.Map(a => Empty.Ok(), () => Sample.Ok());

    result.Should().BeOfType<ResultOk<string>>()
      .Subject.Required().Should().Be(Sample);
  }

  [Fact]
  public void Optional_ReturnsEmpty()
  {
    string[] result = _emptyArray.Optional();

    result.Should().BeEmpty();
  }
}
