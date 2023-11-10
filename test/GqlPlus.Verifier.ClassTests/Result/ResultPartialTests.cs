namespace GqlPlus.Verifier.Result;

public class ResultPartialTests : BaseResultTests
{
  private const string Partial = "Partial";
  private readonly ParseMessage _partialMessage = Partial.ParseMessage();
  private readonly string[] _partialArray = { Partial };

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayPartial()
  {
    var input = _partialArray.PartialArray(_partialMessage);

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Be(Partial);
    result.Optional().Should().BeEquivalentTo(new object[] { Partial });
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayError()
  {
    var input = Partial.Partial(_partialMessage);

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayError<string>>()
      .Subject.Message.Message.Should().Be(Partial);
  }

  [Fact]
  public void Array_Map_ReturnsOtherwise()
  {
    var input = _partialArray.PartialArray(_partialMessage);

    var result = input.Map(a => a.Ok(), () => _sample.Ok());

    result.Should().BeOfType<ResultOk<string[]>>()
      .Subject.Required().Should().Equal(Partial);
  }

  [Fact]
  public void Required_ThrowsInvalidOperation()
  {
    var input = Partial.Partial(_partialMessage);

    Action action = () => input.Required();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain(Partial);
  }

  [Fact]
  public void Select_WithLength_ReturnsResultPartial()
  {
    var input = Partial.Partial(_partialMessage);

    var result = input.Select(s => s.Length);

    result.Should().BeOfType<ResultPartial<int>>()
      .Subject.Message.Message.Should().Contain(Partial);
    result.Optional().Should().Be(7);
  }

  [Fact]
  public void Select_WithNull_ReturnsResultPartial()
  {
    var input = Partial.Partial(_partialMessage);

    var result = input.Select(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultError<Tokenizer>>()
      .Subject.Message.Message.Should().Be(Partial);
  }

  [Fact]
  public void SelectOk_WithLength_ReturnsResultError()
  {
    var input = Partial.Partial(_partialMessage);

    var result = input.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultError<int>>()
      .Subject.Message.Message.Should().Be(Partial);
  }

  [Fact]
  public void SelectOk_WithNull_ReturnsResultError()
  {
    var input = Partial.Partial(_partialMessage);

    var result = input.SelectOk(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultError<Tokenizer>>()
      .Subject.Message.Message.Should().Be(Partial);
  }
}
