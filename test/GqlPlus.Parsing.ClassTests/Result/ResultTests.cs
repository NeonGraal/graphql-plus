﻿namespace GqlPlus.Result;

public class ResultTests
  : BaseResultTests
{
  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    TestResult<string> input = new();

    Action action = () => input.Optional();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain(nameof(String));
  }

  [Fact]
  public void OptionalArray_ThrowsInvalidOperation()
  {
    TestResultArray<string> input = new();

    Action action = () => input.Optional();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain(nameof(String));
  }

  [ExcludeFromCodeCoverage]
  private sealed class TestResult<TValue>
    : IResult<TValue>
  {
    public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue>? withValue = null, Action? action = null) => throw new NotImplementedException();
    public IResult<TResult> AsResult<TResult>(TResult? _ = default) => throw new NotImplementedException();
    public IResult<TResult> Map<TResult>(SelectResult<TValue, TResult> onValue, OnResult<TResult>? otherwise = null) => throw new NotImplementedException();
  }

  [ExcludeFromCodeCoverage]
  private sealed class TestResultArray<T>
    : IResultArray<T>
  {
    public IResult<TResult> AsPartial<TResult>(TResult result, Action<T[]>? withValue = null, Action? action = null) => throw new NotImplementedException();
    public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<T[]>? withValue = null) => throw new NotImplementedException();
    public IResult<TResult> AsResult<TResult>(TResult? _ = default) => throw new NotImplementedException();
    public IResultArray<TResult> AsResultArray<TResult>(TResult[]? _ = null) => throw new NotImplementedException();
    public IResult<TResult> Map<TResult>(SelectResult<T[], TResult> onValue, OnResult<TResult>? otherwise = null) => throw new NotImplementedException();
  }
}
