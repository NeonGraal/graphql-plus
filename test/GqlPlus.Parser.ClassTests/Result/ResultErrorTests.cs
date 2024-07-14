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

    result.Should().BeOfType<ResultPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    using AssertionScope scope = new();
    result.Optional().Should().Be(Sample);
    withValue.Should().BeFalse();
    action.Should().BeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultArrayError()
  {
    bool withValue = false;

    IResultArray<string> result = _error.AsPartialArray(SampleArray, v => withValue = true);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    using AssertionScope scope = new();
    result.Optional().Should().BeEquivalentTo(SampleArray);
    withValue.Should().BeFalse();
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _error.Map(a => Error.Ok(), () => Sample.Ok());

    result.Should().BeOfType<ResultOk<string>>()
      .Subject.Required().Should().Be(Sample);
  }

  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    Action action = () => _error.Optional();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain(Error);
  }

  [Fact]
  public void WithMesssage_CallsActionParam() => _error.WithMessage(m => m.Message.Should().Be(Error));
}
