namespace GqlPlus.Verifier.Result;

public class ResultErrorTests
{
  private readonly string[] _sample = { "Sample" };

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayError()
  {
    var input = new[] { "Error" }.Error("Error".ParseMessage());

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayError<string>>()
      .Subject.Message.Message.Should().Be("Error");
  }

  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    var input = "Error".Error("Error".ParseMessage());

    Action action = () => input.Optional();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain("Error");
  }
}
