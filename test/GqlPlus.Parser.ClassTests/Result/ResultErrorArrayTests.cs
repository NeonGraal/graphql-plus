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

    result.Should().BeOfType<ResultPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    using AssertionScope scope = new();
    result.Optional().Should().Be(Sample);
    withValue.Should().BeFalse();
    action.Should().BeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultOk()
  {
    bool withValue = false;

    IResultArray<string> result = _errorArray.AsPartialArray(SampleArray, v => withValue = true);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    using AssertionScope scope = new();
    result.Optional().Should().Equal(Sample);
    withValue.Should().BeFalse();
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayError()
  {
    IResultArray<string> result = _errorArray.AsResultArray(SampleArray);

    result.Should().BeOfType<ResultArrayError<string>>()
      .Subject.Message.Message.Should().Be(Error);
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayErrorInt()
  {
    IResultArray<int> result = _errorArray.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayError<int>>()
      .Subject.Message.Message.Should().Be("Error");
  }

  [Fact]
  public void AsResultInt_ReturnsResultErrorInt()
  {
    IResult<int> result = _errorArray.AsResult<int>();

    result.Should().BeOfType<ResultError<int>>()
      .Subject.Message.Message.Should().Be("Error");
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<IEnumerable<string>> result = _errorArray.Map(a => a.Ok(), () => SampleArray.OkArray());

    result.Should().BeOfType<ResultArrayOk<string>>()
      .Subject.Required().Should().Equal(SampleArray);
  }

  [Fact]
  public void Optional_ReturnsEmpty()
  {
    Func<IEnumerable<string>> action = () => _errorArray.Optional();

    action.Should().Throw<InvalidOperationException>().WithMessage("*Error*");
  }
}
