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

  protected IResult<IGqlpSchema> Parse(string schema, string label)
  {
    Tokenizer tokens = new(schema);
    return _schemaParser.Parse(tokens, label);
  }

  public async Task<IGqlpSchema> ParseSample(string label, string sample, params string[] dirs)
  {
    string schema = await ReadSchema(sample, dirs);
    return Parse(schema, label).Required();
  }
}
