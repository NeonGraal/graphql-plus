using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus.Sample;

public class VerifierTests(
    Parser<IGqlpSchema>.D schemaParser,
    IVerify<IGqlpSchema> schemaVerifier
) : SampleSchemaChecks(schemaParser)
{
  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task VerifySampleSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);
    TokenMessages errors = [];

    schemaVerifier.Verify(ast, errors);

    await CheckErrors("Schema", "", sample, errors, true);
  }
}
