namespace GqlPlus.Verifier.Result;

public class ResultPartialTests
{
  private readonly string[] _sample = { "Sample" };
  private readonly IResult<string> _partial = "Partial".Partial("Partial".ParseMessage());

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayPartial()
  {
    var input = new[] { "Partial" }.Partial("Partial".ParseMessage());

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Be("Partial");
    result.Optional().Should().BeEquivalentTo(new object[] { "Partial" });
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayPartial()
  {
    var result = _partial.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayError<string>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void Required_ThrowsInvalidOperation()
  {
    Action action = () => _partial.Required();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain("Partial");
  }

  [Fact]
  public void Select_WithLength_ReturnsResultPartial()
  {
    var result = _partial.Select(s => s.Length);

    result.Should().BeOfType<ResultPartial<int>>()
      .Subject.Message.Message.Should().Contain("Partial");
    result.Optional().Should().Be(7);
  }

  [Fact]
  public void Select_WithNull_ReturnsResultPartial()
  {
    var result = _partial.Select(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultError<Tokenizer>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void SelectOk_WithLength_ReturnsResultError()
  {
    var result = _partial.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultError<int>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void SelectOk_WithNull_ReturnsResultError()
  {
    var result = _partial.SelectOk(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultError<Tokenizer>>()
      .Subject.Message.Message.Should().Be("Partial");
  }
}
