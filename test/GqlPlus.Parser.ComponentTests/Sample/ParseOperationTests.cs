﻿using GqlPlus.Abstractions.Operation;
using GqlPlus.Parsing;
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

    await Verify(ast?.Show(), CustomSettings("Operation", "Sample", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesGraphQlData))]
  public async Task ParseGraphQl(string example)
  {
    IGqlpOperation? ast = await ParseSampleOperation("GraphQl", example, "gql");

    await Verify(ast?.Show(), CustomSettings("Operation", "GraphQl", example));
  }

  private async Task<IGqlpOperation?> ParseSampleOperation(string dir, string sample, string extn)
  {
    string operation = await ReadFile(sample, extn, dir);

    OperationContext tokens = new(operation);
    return _operation.Parse(tokens, "Operation").Optional();
  }
}
