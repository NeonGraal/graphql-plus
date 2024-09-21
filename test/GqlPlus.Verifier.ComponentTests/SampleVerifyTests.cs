﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus;

public class SampleVerifyTests(
    Parser<IGqlpSchema>.D schemaParser,
    IVerify<IGqlpSchema> schemaVerifier
) : SampleSchemaChecks(schemaParser)
{
  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task VerifySampleSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);
    TokenMessages errors = [];

    schemaVerifier.Verify(ast, errors);

    await CheckErrors("Schema", sample, errors, true);
  }
}
