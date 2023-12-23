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

  [ExcludeFromCodeCoverage]
  public class TestResult<T> : IResult<T>
  {
    public IResult<R> AsPartial<R>(R result, Action<T>? withValue = null, Action? action = null) => throw new InvalidOperationException();
    public IResult<R> AsResult<R>(R? _ = default) => throw new InvalidOperationException();
    public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null) => throw new InvalidOperationException();
  }
}
