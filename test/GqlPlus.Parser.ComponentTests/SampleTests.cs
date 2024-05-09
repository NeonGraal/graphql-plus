using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;

namespace GqlPlus;

public class SampleTests(
    Parser<IGqlpOperation>.D operation,
    Parser<IGqlpSchema>.D schemaParser
) : SampleChecks(schemaParser)
{
  private readonly Parser<IGqlpOperation>.L _operation = operation;

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task ParseSampleSchema(string sample)
  {
    IGqlpSchema ast = await ParseSchema(sample);

    await Verify(ast.Render(), SampleSettings("ParseSchema", sample));
  }

  [Theory]
  [ClassData(typeof(SampleOperationData))]
  public async Task ParseSampleOperation(string sample)
  {
    IGqlpOperation? ast = await ParseOperation("Operation", sample, "gql+");

    await Verify(ast?.Render(), SampleSettings("ParseOperation", sample));
  }

  [Theory]
  [ClassData(typeof(SampleGraphQlData))]
  public async Task ParseSampleGraphQl(string example)
  {
    IGqlpOperation? ast = await ParseOperation("GraphQl", example, "gql");

    await Verify(ast?.Render(), SampleSettings("ParseGraphQl", example));
  }

  private async Task<IGqlpOperation?> ParseOperation(string dir, string sample, string extn)
  {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
    string operation = await File.ReadAllTextAsync($"Sample/{dir}/{sample}.{extn}");

    OperationContext tokens = new(operation);
    return _operation.Parse(tokens, "Operation").Optional();
  }
}
