namespace GqlPlus.Verifier.Result;

public class ResultErrorTests : BaseResultTests
{
  private const string Error = "Error";
  private readonly string[] _errorArray = { Error };
  private readonly ParseMessage _errorMessage = Error.ParseMessage();

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    var input = Error.Error(_errorMessage);

    var result = input.AsPartial(Sample);

    result.Should().BeOfType<ResultPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    result.Optional().Should().Be(Sample);
  }

  [Fact]
  public void Array_AsPartial_ReturnsResultOk()
  {
    var input = _errorArray.ErrorArray(_errorMessage);

    var result = input.AsPartial(Sample);

    result.Should().BeOfType<ResultPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    result.Optional().Should().Be(Sample);
  }

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayError()
  {
    var input = _errorArray.ErrorArray(_errorMessage);

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayError<string>>()
      .Subject.Message.Message.Should().Be(Error);
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    var input = Error.Error(_errorMessage);

    var result = input.Map(a => Error.Ok(), () => Sample.Ok());

    result.Should().BeOfType<ResultOk<string>>()
      .Subject.Required().Should().Be(Sample);
  }

  [Fact]
  public void Array_Map_ReturnsOtherwise()
  {
    var input = _errorArray.ErrorArray(_errorMessage);

    var result = input.Map(a => a.Ok(), () => _sample.Ok());

    result.Should().BeOfType<ResultOk<string[]>>()
      .Subject.Required().Should().Equal(_sample);
  }

  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    var input = Error.Error(_errorMessage);

    Action action = () => input.Optional();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain(Error);
  }

  [Fact]
  public void WithMesssage_CallsActionParameter()
  {
    var input = Error.Error(_errorMessage);

    input.WithMessage(m => m.Message.Should().Be(Error));
  }
}
