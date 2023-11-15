namespace GqlPlus.Verifier.Result;

public class ResultErrorArrayTests : BaseResultTests
{
  private const string Error = "Error";
  private readonly IResultArray<string> _errorArray = new[] { Error }.ErrorArray(Error.ParseMessage());

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    var withValue = false;
    var action = false;

    var result = _errorArray.AsPartial(Sample, v => withValue = true, () => action = true);

    result.Should().BeOfType<ResultPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    using var scope = new AssertionScope();
    result.Optional().Should().Be(Sample);
    withValue.Should().BeFalse();
    action.Should().BeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultOk()
  {
    var withValue = false;

    var result = _errorArray.AsPartialArray(_sample, v => withValue = true);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    using var scope = new AssertionScope();
    result.Optional().Should().Equal(Sample);
    withValue.Should().BeFalse();
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayError()
  {
    var result = _errorArray.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayError<string>>()
      .Subject.Message.Message.Should().Be(Error);
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayErrorInt()
  {
    var result = _errorArray.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayError<int>>()
      .Subject.Message.Message.Should().Be("Error");
  }

  [Fact]
  public void AsResultInt_ReturnsResultErrorInt()
  {
    var result = _errorArray.AsResult<int>();

    result.Should().BeOfType<ResultError<int>>()
      .Subject.Message.Message.Should().Be("Error");
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    var result = _errorArray.Map(a => a.Ok(), () => _sample.Ok());

    result.Should().BeOfType<ResultOk<string[]>>()
      .Subject.Required().Should().Equal(_sample);
  }
}
