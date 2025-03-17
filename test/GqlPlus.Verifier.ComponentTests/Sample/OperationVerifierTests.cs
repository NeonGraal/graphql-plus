using GqlPlus.Abstractions.Operation;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus.Sample;

public class OperationVerifierTests(
    Parser<IGqlpOperation>.D operationParser,
    IVerify<IGqlpOperation> operationVerifier
) : SampleChecks
{
  private readonly Parser<IGqlpOperation>.L _parser = operationParser;

  [Theory]
  [ClassData(typeof(SamplesOperationData))]
  public async Task Verify_ValidOperations_ReturnsValid(string operation)
  {
    IResult<IGqlpOperation> parse = await Parse("", operation);
    if (parse is IResultError<IGqlpOperation> error) {
      error.Message.ShouldBeNull();
    }

    TokenMessages result = [];

    operationVerifier.Verify(parse.Required(), result);

    result.ShouldBeEmpty();
  }

  [Theory]
  [ClassData(typeof(SamplesOperationInvalidData))]
  public async Task Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    IResult<IGqlpOperation> parse = await Parse("Invalid", operation);

    TokenMessages result = [];
    if (parse.IsOk()) {
      operationVerifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(result.Add);
    }

    await CheckErrors("Operation", "Invalid", operation, result, true);
  }

  private async Task<IResult<IGqlpOperation>> Parse(string category, string operation)
  {
    string input = await ReadFile(operation, "gql+", ["Operation", category]);
    OperationContext tokens = new(input);
    return _parser.Parse(tokens, "Operation");
  }
}
