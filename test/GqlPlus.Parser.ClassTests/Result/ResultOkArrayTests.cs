namespace GqlPlus.Result;

public class ResultOkArrayTests : BaseResultTests
{
  private const string Ok = "Ok";
  private readonly IResultArray<string> _okArray = new[] { Ok }.OkArray();

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    bool withValue = false;
    bool action = false;

    IResult<string> result = _okArray.AsPartial(Sample, v => withValue = true, () => action = true);

    result.Should().BeOfType<ResultOk<string>>();
    using AssertionScope scope = new();
    result.Optional().Should().Be(Sample);
    withValue.Should().BeTrue();
    action.Should().BeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultOk()
  {
    IResultArray<string> result = _okArray.AsPartialArray(SampleArray);

    result.Should().BeOfType<ResultArrayOk<string>>();
    result.Optional().Should().BeEquivalentTo(SampleArray);
  }

  [Fact]
  public void AsResultObject_ReturnsResultOkObject()
  {
    IResult<object> result = _okArray.AsResult<object>();

    result.Should().BeOfType<ResultOk<object>>()
      .Subject.Required().Should().BeEquivalentTo(new object[] { "Ok" });
  }

  [Fact]
  public void AsResultString_ReturnsResultEmptyString()
  {
    IResult<string> result = _okArray.AsResult<string>();

    result.Should().BeOfType<ResultEmpty<string>>();
  }

  [Fact]
  public void AsResultArrayObject_ReturnsResultArrayOkObject()
  {
    IResultArray<object> result = _okArray.AsResultArray<object>();

    result.Should().BeOfType<ResultArrayOk<object>>()
      .Subject.Required().Should().BeEquivalentTo(new object[] { "Ok" });
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayEmptyInt()
  {
    IResultArray<int> result = _okArray.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayEmpty<int>>();
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayOk()
  {
    IResultArray<string> result = _okArray.AsResultArray(SampleArray);

    result.Should().BeOfType<ResultArrayOk<string>>();
    result.Optional().Should().BeEquivalentTo(new object[] { Ok });
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _okArray.Map(a => Ok.Ok(), () => Sample.Ok());

    result.Should().BeOfType<ResultOk<string>>()
      .Subject.Required().Should().Be(Ok);
  }
}
