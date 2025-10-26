namespace GqlPlus.Result;

public class ResultErrorTests : TestResultBase
{
  private const string Error = "Error";
  private readonly IResult<string> _error = Error.Error(Error.ParseMessage());
  private readonly IResult<string[]> _errorArray = Array.Empty<string>().Error(Error.ParseMessage());
  private readonly IResultArray<string> _errorResultArray = Error.ParseMessage().ErrorArray<string>();

  // Abstract method implementations
  protected override IResult<string> CreateResult() => _error;
  protected override IResult<string[]> CreateArrayResult() => _errorArray;
  protected override IResultArray<string> CreateResultArray() => _errorResultArray;

  protected override bool ExpectedIsError => true;
  protected override string? ExpectedOptionalValue => null;
  protected override bool ExpectedOptionalThrows => true;
  protected override bool ExpectedRequiredThrows => true;
  protected override string? ExpectedMessage => Error;

  protected override Type ExpectedAsResultType => typeof(ResultError<int>);
  protected override Type ExpectedAsPartialType => typeof(ResultPartial<string>);
  protected override Type ExpectedSelectType => typeof(ResultPartial<int>);
  protected override Type ExpectedAsResultArrayType => typeof(ResultArrayPartial<string>);
  protected override Type ExpectedAsPartialArrayType => typeof(ResultArrayPartial<string>);
  protected override Type ExpectedArrayAsResultArrayType => typeof(ResultArrayError<int>);
  protected override Type ExpectedArrayAsPartialArrayType => typeof(ResultArrayPartial<string>);

  protected override bool ExpectedArrayOptionalThrows => true;
  protected override bool ExpectedArrayRequiredThrows => true;
  protected override IEnumerable<string>? ExpectedArrayOptionalValue => null;

  protected override bool ExpectedActionCalled => true;

}
