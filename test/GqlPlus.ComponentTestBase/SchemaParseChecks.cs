using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus;

public class SchemaParseChecks(
  Parser<IGqlpSchema>.D schemaParser
) : SampleChecks
  , ISchemaParseChecks
{

  private readonly Parser<IGqlpSchema>.L _schemaParser = schemaParser;

  public IResult<IGqlpSchema> Parse(string schema, string label)
    => _schemaParser.Parse(new Tokenizer(schema), TestLabel);

  public IGqlpSchema ParseInput(string schema, string label)
    => Parse(schema, TestLabel).Required();
}

public interface ISchemaParseChecks
{
  IResult<IGqlpSchema> Parse(string schema, string label);
  IGqlpSchema ParseInput(string schema, string label);
}
