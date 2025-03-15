using GqlPlus.Abstractions.Operation;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;
namespace GqlPlus.Operation;

public class VerifierTests(
    Parser<IGqlpOperation>.D parser,
    IVerify<IGqlpOperation> verifier
) : SampleChecks
{
  private readonly Parser<IGqlpOperation>.L _parser = parser;

  [Theory]
  [ClassData(typeof(SamplesOperationValidData))]
  public async Task Verify_ValidOperations_ReturnsValid(string operation)
  {
    IResult<IGqlpOperation> parse = await Parse("Valid", operation);
    if (parse is IResultError<IGqlpOperation> error) {
      error.Message.ShouldBeNull();
    }

    TokenMessages result = [];

    verifier.Verify(parse.Required(), result);

    result.ShouldBeEmpty();
  }

  [Theory]
  [ClassData(typeof(SamplesOperationInvalidData))]
  public async Task Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    IResult<IGqlpOperation> parse = await Parse("Invalid", operation);

    TokenMessages result = [];
    if (parse.IsOk()) {
      verifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(result.Add);
    }

    await CheckErrors("Operation", "", operation, result, true);
  }

  private async Task<IResult<IGqlpOperation>> Parse(string category, string operation)
  {
    string input = await ReadFile(operation, "gql+", ["Operation", category]);
    OperationContext tokens = new(input);
    return _parser.Parse(tokens, "Operation");
  }
}
