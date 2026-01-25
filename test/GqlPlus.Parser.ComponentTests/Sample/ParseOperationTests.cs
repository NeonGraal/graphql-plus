using GqlPlus.Abstractions.Operation;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class ParseOperationTests(
    Parser<IGqlpOperation>.D operationParser
) : SampleChecks
{

  private readonly Parser<IGqlpOperation>.L _operation = operationParser;

  [Theory]
  [ClassData(typeof(SamplesOperationData))]
  public async Task ParseOperation(string sample)
  {
    IGqlpOperation? ast = await ParseSampleOperation("Operation", sample, "gql+");
    await CheckErrors(["Operation"], sample, ast!.Errors);
    await VerifyOperation(ast, "Sample", sample);
  }

  [Theory]
  [ClassData(typeof(SamplesGraphQlData))]
  public async Task ParseGraphQl(string example)
  {
    IGqlpOperation? ast = await ParseSampleOperation("GraphQl", example, "gql");
    await VerifyOperation(ast, "GraphQl", example);
  }

  private async Task<IGqlpOperation?> ParseSampleOperation(string dir, string sample, string extn)
  {
    string operation = await ReadFile(sample, extn, dir);

    OperationContext tokens = new(operation);
    return _operation.Parse(tokens, "Operation").Optional();
  }

  private async Task VerifyOperation(IGqlpOperation? ast, string label, string test)
  {
    string? target = ast?.Show();
    if (string.IsNullOrEmpty(target)) {
      return;
    }

    TestContext.Current.AddAttachment("Operation " + test, target);
    await Verify(target, CustomSettings("Operation", TestLabel, test));
  }
}
