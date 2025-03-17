namespace GqlPlus.Result;

public class ResultPartialArrayTests : BaseResultTests
{
  private const string Partial = "Partial";
  private readonly IResultArray<string> _partialArray = new[] { Partial }.PartialArray(Partial.ParseMessage());

  [Fact]
  public void AsPartialArray_ReturnsResultArrayPartial()
  {
    IResultArray<string> result = _partialArray.AsPartialArray(SampleArray);

    result.ShouldBeOfType<ResultArrayPartial<string>>()
      .Message.Message.ShouldBe(Partial);
    result.Optional().ShouldBe(SampleArray);
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayPartial()
  {
    IResultArray<string> result = _partialArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayPartial<string>>()
      .Message.Message.ShouldBe(Partial);
    result.Optional().ShouldBe(new object[] { Partial });
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayErrorInt()
  {
    IResultArray<int> result = _partialArray.AsResultArray<int>();

    result.ShouldBeOfType<ResultArrayError<int>>()
      .Message.Message.ShouldBe("Partial");
  }

  [Fact]
  public void AsResultArrayObject_ReturnsResultArrayPartialObject()
  {
    IResultArray<object> result = _partialArray.AsResultArray<object>();

    result.ShouldBeOfType<ResultArrayPartial<object>>()
      .Message.Message.ShouldBe("Partial");
  }

  [Fact]
  public void AsResultInt_ReturnsResultErrorInt()
  {
    IResult<int> result = _partialArray.AsResult<int>();

    result.ShouldBeOfType<ResultError<int>>()
      .Message.Message.ShouldBe("Partial");
  }

  [Fact]
  public void AsResultObject_ReturnsResultPartialObject()
  {
    IResult<object> result = _partialArray.AsResult<object>();

    result.ShouldBeOfType<ResultPartial<object>>()
      .Message.Message.ShouldBe("Partial");
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _partialArray.Map(a => Sample.Ok(), () => Sample.Ok());

    result.ShouldBeOfType<ResultOk<string>>()
      .Required().ShouldBe(Sample);
  }
}
