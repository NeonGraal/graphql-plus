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

  public class TestResult<T> : IResult<T>
  {
    public IResult<R> AsPartial<R>(R result, Action<T>? action = null) => throw new NotImplementedException();
    public IResult<R> AsResult<R>(R? _ = default) => throw new NotImplementedException();
    public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null) => throw new NotImplementedException();
  }
}
