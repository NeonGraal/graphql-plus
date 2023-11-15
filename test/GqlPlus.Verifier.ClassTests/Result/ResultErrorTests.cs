namespace GqlPlus.Verifier.Result;

public class ResultErrorTests : BaseResultTests
{
  private const string Error = "Error";
  private readonly IResult<string> _error = Error.Error(Error.ParseMessage());

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    var withValue = false;
    var action = false;

    var result = _error.AsPartial(Sample, v => withValue = true, () => action = true);

    result.Should().BeOfType<ResultPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    using var scope = new AssertionScope();
    result.Optional().Should().Be(Sample);
    withValue.Should().BeFalse();
    action.Should().BeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultArrayError()
  {
    var withValue = false;

    var result = _error.AsPartialArray(_sample, v => withValue = true);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Contain(Error);
    using var scope = new AssertionScope();
    result.Optional().Should().BeEquivalentTo(_sample);
    withValue.Should().BeFalse();
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    var result = _error.Map(a => Error.Ok(), () => Sample.Ok());

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
  public void WithMesssage_CallsActionParameter() => _error.WithMessage(m => m.Message.Should().Be(Error));
}
