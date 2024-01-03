using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier.Result;

public class ResultTests : BaseResultTests
{
  [Fact]
  public void Optional_ThrowsInvalidOperation()
  {
    var input = new TestResult<string>();

    Action action = () => input.Optional();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain(nameof(String));
  }

  [Fact]
  public void OptionalArray_ThrowsInvalidOperation()
  {
    var input = new TestResultArray<string>();

    Action action = () => input.Optional();

    action.Should().Throw<InvalidOperationException>()
      .Which.Message.Should().Contain(nameof(String));
  }

  [ExcludeFromCodeCoverage]
  public class TestResult<T> : IResult<T>
  {
    public IResult<R> AsPartial<R>(R result, Action<T>? withValue = null, Action? action = null) => throw new NotImplementedException();
    public IResult<R> AsResult<R>(R? _ = default) => throw new NotImplementedException();
    public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null) => throw new NotImplementedException();
  }

  [ExcludeFromCodeCoverage]
  public class TestResultArray<T> : IResultArray<T>
  {
    public IResult<R> AsPartial<R>(R result, Action<T[]>? withValue = null, Action? action = null) => throw new NotImplementedException();
    public IResultArray<R> AsPartialArray<R>(IEnumerable<R> result, Action<T[]>? withValue = null) => throw new NotImplementedException();
    public IResult<R> AsResult<R>(R? _ = default) => throw new NotImplementedException();
    public IResultArray<R> AsResultArray<R>(R[]? _ = null) => throw new NotImplementedException();
    public IResult<R> Map<R>(SelectResult<T[], R> onValue, OnResult<R>? otherwise = null) => throw new NotImplementedException();
  }
}
