using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;

namespace GqlPlus;

public class SampleParserTests(
    Parser<IGqlpOperation>.D operation,
    Parser<IGqlpSchema>.D schemaParser
) : SampleChecks(schemaParser)
{
  private readonly Parser<IGqlpOperation>.L _operation = operation;

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task ParseSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    await Verify(ast.Show(), SampleSettings("Schema", sample));
  }

  [Theory]
  [ClassData(typeof(SampleOperationData))]
  public async Task ParseOperation(string sample)
  {
    IGqlpOperation? ast = await ParseSampleOperation("Operation", sample, "gql+");

    await Verify(ast?.Show(), SampleSettings("Operation", sample));
  }

  [Theory]
  [ClassData(typeof(SampleGraphQlData))]
  public async Task ParseGraphQl(string example)
  {
    IGqlpOperation? ast = await ParseSampleOperation("GraphQl", example, "gql");

    await Verify(ast?.Show(), SampleSettings("GraphQl", example));
  }

  private async Task<IGqlpOperation?> ParseSampleOperation(string dir, string sample, string extn)
  {
    string operation = await File.ReadAllTextAsync($"Samples/{dir}/{sample}.{extn}");

    OperationContext tokens = new(operation);
    return _operation.Parse(tokens, "Operation").Optional();
  }
}
