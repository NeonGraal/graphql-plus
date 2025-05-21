﻿namespace GqlPlus.Result;

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

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeOfType<ResultPartial<string>>()
        .Message.Message.ShouldContain(Partial),
      () => result.Optional().ShouldBe(Sample),
      () => withValue.ShouldBeTrue(),
      () => action.ShouldBeTrue());
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayPartial()
  {
    IResultArray<string> result = _partial.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayPartial<string>>()
      .Message.Message.ShouldBe(Partial);
  }

  [Fact]
  public void AsPartialArray_ReturnsResultArrayError()
  {
    bool withValue = false;

    IResultArray<string> result = _partial.AsPartialArray(SampleArray, v => withValue = true);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeOfType<ResultArrayPartial<string>>()
      .Message.Message.ShouldContain(Partial),
      () => result.Optional().ShouldBe(SampleArray),
      () => withValue.ShouldBeTrue());
  }

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayError()
  {
    IResultArray<string> result = _partialArray.AsResultArray(SampleArray);

    result.ShouldBeOfType<ResultArrayPartial<string>>()
      .Message.Message.ShouldBe(Partial);
    result.Optional().ShouldBe([Partial]);
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    IResult<string> result = _partial.Map(a => Partial.Ok(), () => Sample.Ok());

    result.ShouldBeOfType<ResultOk<string>>()
      .Required().ShouldBe(Partial);
  }

  [Fact]
  public void Required_ThrowsInvalidOperation()
  {
    Action action = () => _partial.Required();

    action.ShouldThrow<InvalidOperationException>()
      .Message.ShouldContain(Partial);
  }

  [Fact]
  public void Select_WithLength_ReturnsResultPartial()
  {
    IResult<int> result = _partial.Select(s => s.Length);

    result.ShouldBeOfType<ResultPartial<int>>()
      .Message.Message.ShouldContain(Partial);
    result.Optional().ShouldBe(7);
  }

  [Fact]
  public void Select_WithNull_ReturnsResultPartial()
  {
    IResult<ITokenizer> result = _partial.Select(s => (ITokenizer?)null);

    result.ShouldBeOfType<ResultError<ITokenizer>>()
      .Message.Message.ShouldBe(Partial);
  }

  [Fact]
  public void SelectOk_WithLength_ReturnsResultError()
  {
    IResult<int> result = _partial.SelectOk(s => s.Length);

    result.ShouldBeOfType<ResultError<int>>()
      .Message.Message.ShouldBe(Partial);
  }

  [Fact]
  public void SelectOk_WithNull_ReturnsResultError()
  {
    IResult<ITokenizer> result = _partial.SelectOk(s => (ITokenizer?)null);

    result.ShouldBeOfType<ResultError<ITokenizer>>()
      .Message.Message.ShouldBe(Partial);
  }
}
