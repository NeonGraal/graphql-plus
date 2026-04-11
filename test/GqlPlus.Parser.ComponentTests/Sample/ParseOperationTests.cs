using GqlPlus.Abstractions.Operation;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class ParseOperationTests(
    IParserRepository parsers
) : SampleChecks
{

  private readonly Parser<IAstOperation>.L _operation = parsers.ParserFor<IAstOperation>();

  [Theory]
  [ClassData(typeof(SamplesOperationData))]
  public async Task ParseOperation(string sample)
  {
    IAstOperation? ast = await ParseSampleOperation("Operation", sample, "gql+");
    await CheckErrors(["Operation"], sample, ast!.Errors, "parse");
    await VerifyOperation(ast, "Sample", sample);
  }

  [Theory]
  [ClassData(typeof(SamplesGraphQlData))]
  public async Task ParseGraphQl(string example)
  {
    IAstOperation? ast = await ParseSampleOperation("GraphQl", example, "gql");
    await VerifyOperation(ast, "GraphQl", example);
  }

  private async Task<IAstOperation?> ParseSampleOperation(string dir, string sample, string extn)
  {
    string operation = await ReadFile(sample, extn, dir);

    OperationContext tokens = new(operation);
    return _operation.Parse(tokens, "Operation").Optional();
  }

  private async Task VerifyOperation(IAstOperation? ast, string label, string test)
  {
    string? target = ast?.Show();
    if (string.IsNullOrEmpty(target)) {
      return;
    }

    await target.AttachAndVerify("Operation " + test, CustomSettings("Operation", label, test));
  }
}
