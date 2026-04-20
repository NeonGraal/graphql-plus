using GqlPlus.Ast.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus;

public class SchemaParseChecks(
  IParserRepository parsers
) : SampleChecks
  , ISchemaParseChecks
{
  private readonly Parser<IAstSchema>.L _schemaParser = parsers.ParserFor<IAstSchema>();

  public IResult<IAstSchema> Parse(string schema, string label)
    => _schemaParser.Parse(new Tokenizer(schema), label);

  public IAstSchema ParseInput(string schema, string label)
    => Parse(schema, label).Required();
}

public interface ISchemaParseChecks
{
  IResult<IAstSchema> Parse(string schema, string label);
  IAstSchema ParseInput(string schema, string label);
}
