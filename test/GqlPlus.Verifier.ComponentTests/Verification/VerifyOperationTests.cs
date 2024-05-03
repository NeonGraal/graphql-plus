using GqlPlus.Abstractions.Operation;
using GqlPlus.Parse;
using GqlPlus.Parse.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Verification;

public class VerifyOperationTests(
    Parser<IGqlpOperation>.D parser,
    IVerify<IGqlpOperation> verifier)
{
  private readonly Parser<IGqlpOperation>.L _parser = parser;

  [Theory]
  [ClassData(typeof(VerifyOperationValidData))]
  public void Verify_ValidOperations_ReturnsValid(string operation)
  {
    IResult<IGqlpOperation> parse = Parse(VerifyOperationValidData.Source[operation]);
    if (parse is IResultError<IGqlpOperation> error) {
      error.Message.Should().BeNull();
    }

    TokenMessages result = [];

    verifier.Verify(parse.Required(), result);

    result.Should().BeNullOrEmpty();
  }

  [Theory]
  [ClassData(typeof(VerifyOperationInvalidData))]
  public void Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    IResult<IGqlpOperation> parse = Parse(VerifyOperationInvalidData.Source[operation]);

    TokenMessages result = [];
    if (parse.IsOk()) {
      verifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(result.Add);
    }

    result.Should().NotBeNullOrEmpty();
  }

  private IResult<IGqlpOperation> Parse(string operation)
  {
    OperationContext tokens = new(operation);
    return _parser.Parse(tokens, "Operation");
  }
}
