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

    result.ShouldBeOfType<ResultOk<string>>();
    // using AssertionScope scope = new();
    result.Optional().ShouldBe(Sample);
    withValue.ShouldBeFalse();
    action.ShouldBeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultOk()
  {
    bool withValue = false;

    IResultArray<string> result = _emptyArray.AsPartialArray(SampleArray, v => withValue = true);

    result.ShouldBeOfType<ResultArrayOk<string>>();
    // using AssertionScope scope = new();
    result.Optional().ShouldBe([Sample]);
    withValue.ShouldBeFalse();
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayEmpty()
  {
    IResultArray<string> result = _emptyArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayEmptyInt()
  {
    IResultArray<int> result = _emptyArray.AsResultArray<int>();

    result.ShouldBeOfType<ResultArrayEmpty<int>>();
  }

  [Fact]
  public void AsResultInt_ReturnsResultEmptyInt()
  {
    IResult<int> result = _emptyArray.AsResult<int>();

    result.ShouldBeOfType<ResultEmpty<int>>();
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _emptyArray.Map(a => Empty.Ok(), () => Sample.Ok());

    result.ShouldBeOfType<ResultOk<string>>()
      .Required().ShouldBe(Sample);
  }

  [Fact]
  public void Optional_ReturnsEmpty()
  {
    IEnumerable<string> result = _emptyArray.Optional();

    result.ShouldBeEmpty();
  }
}
