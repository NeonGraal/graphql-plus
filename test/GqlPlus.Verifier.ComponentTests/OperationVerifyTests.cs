using GqlPlus.Abstractions.Operation;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus;

public class OperationVerifyTests(
    Parser<IGqlpOperation>.D parser,
    IVerify<IGqlpOperation> verifier
)
{
  private readonly Parser<IGqlpOperation>.L _parser = parser;

  [Theory]
  [ClassData(typeof(OperationValidData))]
  public void Verify_ValidOperations_ReturnsValid(string operation)
  {
    IResult<IGqlpOperation> parse = Parse(OperationValidData.Source[operation]);
    if (parse is IResultError<IGqlpOperation> error) {
      error.Message.Should().BeNull();
    }

    TokenMessages result = [];

    verifier.Verify(parse.Required(), result);

    result.Should().BeNullOrEmpty();
  }

  [Theory]
  [ClassData(typeof(OperationInvalidData))]
  public async Task Verify_InvalidOperations_ReturnsInvalidAsync(string operation)
  {
    IResult<IGqlpOperation> parse = Parse(OperationInvalidData.Source[operation]);

    TokenMessages result = [];
    if (parse.IsOk()) {
      verifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(result.Add);
    }

    result.Should().NotBeNullOrEmpty();

    await Verify(result.Select(m => m.Message), OperationSettings("Invalid", operation));
  }

  private IResult<IGqlpOperation> Parse(string operation)
  {
    OperationContext tokens = new(operation);
    return _parser.Parse(tokens, "Operation");
  }

  private VerifySettings OperationSettings(string category, string test)
  {
    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory($"Operation{category}Tests");
    settings.UseFileName(test);

    return settings;
  }
}
