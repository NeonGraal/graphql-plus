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

    result.ShouldBeOfType<ResultOk<string>>();
    // using AssertionScope scope = new();
    result.Optional().ShouldBe(Sample);
    withValue.ShouldBeTrue();
    action.ShouldBeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultOk()
  {
    IResultArray<string> result = _okArray.AsPartialArray(SampleArray);

    result.ShouldBeOfType<ResultArrayOk<string>>();
    result.Optional().ShouldBe(SampleArray);
  }

  [Fact]
  public void AsResultObject_ReturnsResultOkObject()
  {
    IResult<object> result = _okArray.AsResult<object>();

    result.ShouldBeOfType<ResultOk<object>>()
      .Required().ShouldBe(new object[] { "Ok" });
  }

  [Fact]
  public void AsResultString_ReturnsResultEmptyString()
  {
    IResult<string> result = _okArray.AsResult<string>();

    result.ShouldBeOfType<ResultEmpty<string>>();
  }

  [Fact]
  public void AsResultArrayObject_ReturnsResultArrayOkObject()
  {
    IResultArray<object> result = _okArray.AsResultArray<object>();

    result.ShouldBeOfType<ResultArrayOk<object>>()
      .Required().ShouldBe(new object[] { "Ok" });
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayEmptyInt()
  {
    IResultArray<int> result = _okArray.AsResultArray<int>();

    result.ShouldBeOfType<ResultArrayEmpty<int>>();
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayOk()
  {
    IResultArray<string> result = _okArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayOk<string>>();
    result.Optional().ShouldBe(new object[] { Ok });
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _okArray.Map(a => Ok.Ok(), () => Sample.Ok());

    result.ShouldBeOfType<ResultOk<string>>()
      .Required().ShouldBe(Ok);
  }
}
