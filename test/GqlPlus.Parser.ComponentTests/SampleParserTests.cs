using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;

namespace GqlPlus;

public class SampleParserTests(
    Parser<IGqlpOperation>.D operation,
    Parser<IGqlpSchema>.D schemaParser
) : SampleSchemaChecks(schemaParser)
{
  private readonly Parser<IGqlpOperation>.L _operation = operation;

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task ParseSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    await CheckErrors("Schema", sample, ast.Errors);

    await Verify(ast.Show(), CustomSettings("Sample", "Schema", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesOperationData))]
  public async Task ParseOperation(string sample)
  {
    IGqlpOperation? ast = await ParseSampleOperation("Operation", sample, "gql+");

    await CheckErrors("Operation", sample, ast!.Errors);

    await Verify(ast?.Show(), CustomSettings("Sample", "Operation", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesGraphQlData))]
  public async Task ParseGraphQl(string example)
  {
    IGqlpOperation? ast = await ParseSampleOperation("GraphQl", example, "gql");

    await Verify(ast?.Show(), CustomSettings("Sample", "GraphQl", example));
  }

  private async Task<IGqlpOperation?> ParseSampleOperation(string dir, string sample, string extn)
  {
    string operation = await ReadFile(sample, extn, dir);

    OperationContext tokens = new(operation);
    return _operation.Parse(tokens, "Operation").Optional();
  }
}
