namespace GqlPlus.Result;

public class ResultPartialArrayTests : BaseResultTests
{
  private const string Partial = "Partial";
  private readonly IResultArray<string> _partialArray = new[] { Partial }.PartialArray(Partial.ParseMessage());

  [Fact]
  public void AsPartialArray_ReturnsResultArrayPartial()
  {
    IResultArray<string> result = _partialArray.AsPartialArray(SampleArray);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Be(Partial);
    result.Optional().Should().BeEquivalentTo(SampleArray);
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayPartial()
  {
    IResultArray<string> result = _partialArray.AsResultArray(SampleArray);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Be(Partial);
    result.Optional().Should().BeEquivalentTo(new object[] { Partial });
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayErrorInt()
  {
    IResultArray<int> result = _partialArray.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayError<int>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void AsResultArrayObject_ReturnsResultArrayPartialObject()
  {
    IResultArray<object> result = _partialArray.AsResultArray<object>();

    result.Should().BeOfType<ResultArrayPartial<object>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void AsResultInt_ReturnsResultErrorInt()
  {
    IResult<int> result = _partialArray.AsResult<int>();

    result.Should().BeOfType<ResultError<int>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void AsResultObject_ReturnsResultPartialObject()
  {
    IResult<object> result = _partialArray.AsResult<object>();

    result.Should().BeOfType<ResultPartial<object>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _partialArray.Map(a => Sample.Ok(), () => Sample.Ok());

    result.Should().BeOfType<ResultOk<string>>()
      .Subject.Required().Should().Be(Sample);
  }
}
