using GqlPlus.Abstractions.Schema;
using GqlPlus.Generating;
using GqlPlus.Merging;
using GqlPlus.Parsing;

namespace GqlPlus.Sample;

public class GenerateSchemaTests(
    ISchemaGeneratorChecks checks
) : TestSchemaAsts(checks)
{
  protected override async Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[] dirs, string section, string input = "")
  {
    string result = checks.Generate_ForAsts(asts, test, label, input);

    await Verify(result, CustomSettings(label, "Generate", test, section, scrubEmptyLines: false));
  }
}

internal sealed class SchemaGeneratorChecks(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger,
    IGenerator<IGqlpSchema> schemaGenerator
) : SchemaParseChecks(schemaParser)
  , ISchemaGeneratorChecks
{
  public string Generate_ForAsts(IEnumerable<IGqlpSchema> asts, string test, string label, string input = "")
  {
    IGqlpSchema schema = schemaMerger.Merge(asts).First();

    GeneratorContext context = new(label + " " + test, new GqlModelOptions("GqlPlus"));

    schemaGenerator.Generate(schema, context);

    string result = context.ToString();
    if (!string.IsNullOrWhiteSpace(input)) {
      result = "/* " + test + "\r\n" + input.TrimEnd() + "\r\n*/\r\n\r\n" + result;
    }

    return result.TrimEnd();
  }
}

public interface ISchemaGeneratorChecks
  : ISchemaParseChecks
{
  string Generate_ForAsts(IEnumerable<IGqlpSchema> asts, string test, string label, string input = "");
}
