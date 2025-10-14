namespace GqlPlus.Result;

public class ResultTests
  : TestResultBase
{
  private readonly TestResult<string> _testResult = new();
  private readonly TestResult<string[]> _testArrayResult = new();
  private readonly TestResultArray<string> _testResultArray = new();

  // Abstract method implementations - these test the extension methods with incomplete implementations
  protected override IResult<string> CreateResult() => _testResult;
  protected override IResult<string[]> CreateArrayResult() => _testArrayResult;
  protected override IResultArray<string> CreateResultArray() => _testResultArray;

  protected override string? ExpectedOptionalValue => null;
  protected override bool ExpectedOptionalThrows => true;
  protected override bool ExpectedRequiredThrows => true;
  protected override string? ExpectedMessage => null;

  protected override Type ExpectedAsResultType => typeof(NotImplementedException);
  protected override Type ExpectedAsPartialType => typeof(NotImplementedException);
  protected override Type ExpectedMapType => typeof(NotImplementedException);
  protected override Type ExpectedSelectType => typeof(NotImplementedException);
  protected override Type ExpectedArrayAsResultArrayType => typeof(NotImplementedException);
  protected override Type ExpectedArrayAsPartialArrayType => typeof(NotImplementedException);

  protected override bool ExpectedArrayOptionalThrows => true;
  protected override bool ExpectedArrayRequiredThrows => true;
  protected override IEnumerable<string>? ExpectedArrayOptionalValue => null;

  private sealed class TestResult<TValue>
    : IResult<TValue>
  {
    public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue>? withValue = null, Action? action = null) => throw new NotImplementedException();
    public IResult<TResult> AsResult<TResult>(TResult? _ = default) => throw new NotImplementedException();
    public IResult<TResult> Map<TResult>(SelectResult<TValue, TResult> onValue, OnResult<TResult>? otherwise = null) => throw new NotImplementedException();
  }

  private sealed class TestResultArray<T>
    : IResultArray<T>
  {
    public IResult<TResult> AsPartial<TResult>(TResult result, Action<IEnumerable<T>>? withValue = null, Action? action = null) => throw new NotImplementedException();
    public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<IEnumerable<T>>? withValue = null) => throw new NotImplementedException();
    public IResult<TResult> AsResult<TResult>(TResult? _ = default) => throw new NotImplementedException();
    public IResultArray<TResult> AsResultArray<TResult>(IEnumerable<T>? _ = null) => throw new NotImplementedException();
    public IResult<TResult> Map<TResult>(SelectResult<IEnumerable<T>, TResult> onValue, OnResult<TResult>? otherwise = null) => throw new NotImplementedException();
  }
}
