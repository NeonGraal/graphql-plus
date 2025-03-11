using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus;

public class SampleSchemaChecks(
  Parser<IGqlpSchema>.D schemaParser
) : SampleChecks
{
  private readonly Parser<IGqlpSchema>.L _schemaParser = schemaParser;

  protected IResult<IGqlpSchema> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _schemaParser.Parse(tokens, "Schema");
  }

  protected async Task<IGqlpSchema> ParseSampleSchema(string sample)
  {
    string schema = await ReadSchema(sample);
    Tokenizer tokens = new(schema);

    return _schemaParser.Parse(tokens, "Schema").Required();
  }
}
