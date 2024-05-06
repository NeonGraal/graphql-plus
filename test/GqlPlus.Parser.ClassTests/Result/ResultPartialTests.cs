using GqlPlus.Token;

namespace GqlPlus.Result;

public class ResultPartialTests : BaseResultTests
{
  private const string Partial = "Partial";
  private readonly IResult<string> _partial = Partial.Partial(Partial.ParseMessage());
  private readonly IResult<string[]> _partialArray = new[] { Partial }.Partial(Partial.ParseMessage());

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    bool withValue = false;
    bool action = false;

    IResult<string> result = _partial.AsPartial(Sample, v => withValue = true, () => action = true);

    result.Should().BeOfType<ResultPartial<string>>()
      .Subject.Message.Message.Should().Contain(Partial);
    using AssertionScope scope = new();
    result.Optional().Should().Be(Sample);
    withValue.Should().BeTrue();
    action.Should().BeTrue();
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayError()
  {
    IResultArray<string> result = _partial.AsResultArray(SampleArray);

    result.Should().BeOfType<ResultArrayError<string>>()
      .Subject.Message.Message.Should().Be(Partial);
  }

  [Fact]
  public void AsPartialArray_ReturnsResultArrayError()
  {
    bool withValue = false;

    IResultArray<string> result = _partial.AsPartialArray(SampleArray, v => withValue = true);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Contain(Partial);
    using AssertionScope scope = new();
    result.Optional().Should().BeEquivalentTo(SampleArray);
    withValue.Should().BeTrue();
  }

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayError()
  {
    IResultArray<string> result = _partialArray.AsResultArray(SampleArray);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Be(Partial);
    result.Optional().Should().Equal(Partial);
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _partial.Map(a => Partial.Ok(), () => Sample.Ok());

    result.Should().BeOfType<ResultOk<string>>()
      .Subject.Required().Should().Be(Partial);
  }

  [Fact]
  public void Required_ThrowsInvalidOperation()
  {
    Action action = () => _partial.Required();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain(Partial);
  }

  [Fact]
  public void Select_WithLength_ReturnsResultPartial()
  {
    IResult<int> result = _partial.Select(s => s.Length);

    result.Should().BeOfType<ResultPartial<int>>()
      .Subject.Message.Message.Should().Contain(Partial);
    result.Optional().Should().Be(7);
  }

  [Fact]
  public void Select_WithNull_ReturnsResultPartial()
  {
    IResult<Tokenizer> result = _partial.Select(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultError<Tokenizer>>()
      .Subject.Message.Message.Should().Be(Partial);
  }

  [Fact]
  public void SelectOk_WithLength_ReturnsResultError()
  {
    IResult<int> result = _partial.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultError<int>>()
      .Subject.Message.Message.Should().Be(Partial);
  }

  [Fact]
  public void SelectOk_WithNull_ReturnsResultError()
  {
    IResult<Tokenizer> result = _partial.SelectOk(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultError<Tokenizer>>()
      .Subject.Message.Message.Should().Be(Partial);
  }
}
