namespace GqlPlus.Result;

public class ResultErrorTests : BaseResultTests
{
  private const string Error = "Error";
  private readonly IResult<string> _error = Error.Error(Error.ParseMessage());

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    bool withValue = false;
    bool action = false;

    IResult<string> result = _error.AsPartial(Sample, v => withValue = true, () => action = true);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeOfType<ResultPartial<string>>()
        .Message.Message.ShouldContain(Error),
      () => result.Optional().ShouldBe(Sample),
      () => withValue.ShouldBeFalse(),
      () => action.ShouldBeTrue());
  }

  [Fact]
  public void AsPartialArray_ReturnsResultArrayError()
  {
    bool withValue = false;

    IResultArray<string> result = _error.AsPartialArray(SampleArray, v => withValue = true);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeOfType<ResultArrayPartial<string>>()
        .Message.Message.ShouldContain(Error),
      () => result.Optional().ShouldBe(SampleArray),
      () => withValue.ShouldBeFalse());
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _error.Map(a => Error.Ok(), () => Sample.Ok());

    result.ShouldBeOfType<ResultOk<string>>()
      .Required().ShouldBe(Sample);
  }

  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    Action action = () => _error.Optional();

    action.ShouldThrow<InvalidOperationException>()
      .Message.ShouldContain(Error);
  }

  [Fact]
  public void WithMesssage_CallsActionParam() => _error.WithMessage(m => m.Message.ShouldBe(Error));
}
