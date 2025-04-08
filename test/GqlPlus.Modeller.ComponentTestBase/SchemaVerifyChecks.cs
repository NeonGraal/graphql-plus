using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus;

internal sealed class SchemaVerifyChecks(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger,
    IModelAndRender schemaRenderer
) : SchemaDataBase(schemaParser)
  , ISchemaVerifyChecks
{
  public Structured Verify_Model(string input)
  {
    IGqlpSchema ast = Parse(input, "Sample").Required();

    return Verify_Asts([ast]);
  }

  public Structured Verify_Model(IEnumerable<string> inputs)
  {
    IEnumerable<IGqlpSchema> asts = inputs.Select(input => Parse(input, "Sample").Required());

    return Verify_Asts(asts);
  }

  public Structured Verify_Asts(IEnumerable<IGqlpSchema> asts)
  {
    IGqlpSchema schema = schemaMerger.Merge(asts).First();

    return schemaRenderer.RenderAst(schema, schemaRenderer.WithBuiltIns());
  }
}

public interface ISchemaVerifyChecks
{
  Task<IGqlpSchema> ParseSample(string label, string sample, params string[] dirs);

  Structured Verify_Model(string input);
  Structured Verify_Model(IEnumerable<string> inputs);
  Structured Verify_Asts(IEnumerable<IGqlpSchema> asts);
}
