using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus;

public class SchemaParseChecks(
  IParserRepository parsers
) : SampleChecks
  , ISchemaParseChecks
{
  private readonly Parser<IGqlpSchema>.L _schemaParser = parsers.Get<IGqlpSchema>();

  public IResult<IGqlpSchema> Parse(string schema, string label)
    => _schemaParser.Parse(new Tokenizer(schema), label);

  public IGqlpSchema ParseInput(string schema, string label)
    => Parse(schema, label).Required();
}

public interface ISchemaParseChecks
{
  IResult<IGqlpSchema> Parse(string schema, string label);
  IGqlpSchema ParseInput(string schema, string label);
}
