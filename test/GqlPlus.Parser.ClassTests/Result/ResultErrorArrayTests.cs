namespace GqlPlus.Result;

public class ResultErrorArrayTests : BaseResultTests
{
  private const string Error = "Error";
  private readonly IResultArray<string> _errorArray = Error.ParseMessage().ErrorArray<string>();

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    bool withValue = false;
    bool action = false;

    IResult<string> result = _errorArray.AsPartial(Sample, v => withValue = true, () => action = true);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeOfType<ResultPartial<string>>()
        .Message.Message.ShouldContain(Error),
      () => result.Optional().ShouldBe(Sample),
      () => withValue.ShouldBeFalse(),
      () => action.ShouldBeTrue());
  }

  [Fact]
  public void AsPartialArray_ReturnsResultOk()
  {
    bool withValue = false;

    IResultArray<string> result = _errorArray.AsPartialArray(SampleArray, v => withValue = true);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeOfType<ResultArrayPartial<string>>()
        .Message.Message.ShouldContain(Error),
      () => result.Optional().ShouldBe([Sample]),
      () => withValue.ShouldBeFalse());
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayError()
  {
    IResultArray<string> result = _errorArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayError<string>>()
      .Message.Message.ShouldBe(Error);
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayErrorInt()
  {
    IResultArray<int> result = _errorArray.AsResultArray<int>();

    result.ShouldBeOfType<ResultArrayError<int>>()
      .Message.Message.ShouldBe("Error");
  }

  [Fact]
  public void AsResultInt_ReturnsResultErrorInt()
  {
    IResult<int> result = _errorArray.AsResult<int>();

    result.ShouldBeOfType<ResultError<int>>()
      .Message.Message.ShouldBe("Error");
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<IEnumerable<string>> result = _errorArray.Map(a => a.Ok(), () => SampleArray.OkArray());

    result.ShouldBeOfType<ResultArrayOk<string>>()
      .Required().ShouldBe(SampleArray);
  }

  [Fact]
  public void Optional_ReturnsEmpty()
  {
    Func<IEnumerable<string>> action = () => _errorArray.Optional();

    action.ShouldThrow<InvalidOperationException>().Message.ShouldContain("Error");
  }
}
