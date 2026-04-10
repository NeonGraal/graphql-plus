using GqlPlus.Abstractions.Operation;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;
using GqlPlus.Verifying;

namespace GqlPlus.Sample;

public class VerifyOperationTests(
    IParserRepository parsers,
    IVerifierRepository verifierRepository
) : SampleChecks
{
  private readonly Parser<IAstOperation>.L _parser = parsers.ParserFor<IAstOperation>();
  private readonly IVerify<IAstOperation> _operationVerifier = verifierRepository.VerifierFor<IAstOperation>();

  [Theory]
  [ClassData(typeof(SamplesOperationData))]
  public async Task Verify_ValidOperations_ReturnsValid(string operation)
  {
    IResult<IAstOperation> parse = await Parse("", operation);
    if (parse is IResultError<IAstOperation> error) {
      error.Message.ShouldBeNull();
    }

    IMessages result = Messages.New;

    _operationVerifier.Verify(parse.Required(), result);

    result.ShouldBeEmpty();
  }

  [Theory]
  [ClassData(typeof(SamplesOperationInvalidData))]
  public async Task Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    IResult<IAstOperation> parse = await Parse("Invalid", operation);

    Messages result = Messages.Empty;
    if (parse.IsOk()) {
      _operationVerifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(result.Add);
    }

    await CheckErrors(["Operation", "Invalid"], operation, result, "verify", "parse");
  }

  private async Task<IResult<IAstOperation>> Parse(string category, string operation)
  {
    string input = await ReadFile(operation, "gql+", ["Operation", category]);
    OperationContext tokens = new(input);
    return _parser.Parse(tokens, "Operation");
  }
}
