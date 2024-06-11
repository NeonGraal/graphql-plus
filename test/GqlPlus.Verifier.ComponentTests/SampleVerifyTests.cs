using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus;

public class SampleVerifyTests(
    Parser<IGqlpSchema>.D schemaParser,
    IVerify<IGqlpSchema> schemaVerifier
) : SampleChecks(schemaParser)
{
  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task VerifySampleSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);
    TokenMessages errors = [];

    schemaVerifier.Verify(ast, errors);

    await Verify(errors.Select(e => $"{e}").Order().Distinct(), SampleSettings("Verify", sample));
  }
}
