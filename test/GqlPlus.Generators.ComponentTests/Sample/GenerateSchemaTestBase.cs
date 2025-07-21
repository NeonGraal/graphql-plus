using GqlPlus.Abstractions.Schema;
using GqlPlus.Generating;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public abstract class GenerateSchemaTestBase(
  ILoggerFactory logger,
  ISchemaGeneratorChecks checks
) : TestSchemaAsts(logger, checks)
{
  protected override async Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[] dirs, string section, string input = "")
  {
    string result = checks.Generate_ForAsts(BaseType, GeneratorType, asts, test, label, input);

    if (!result.IsWhiteSpace()) {
      await Verify(result, CustomSettings(label, $"Generate_{GeneratorType}", test, section, scrubEmptyLines: false));
    }
  }

  public virtual GqlpBaseType BaseType => GqlpBaseType.Other;
  public abstract GqlpGeneratorType GeneratorType { get; }
}

internal sealed class SchemaGeneratorChecks(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger,
    IGenerator<IGqlpSchema> schemaGenerator
) : SchemaParseChecks(schemaParser)
  , ISchemaGeneratorChecks
{
  public string Generate_ForAsts(GqlpBaseType baseType, GqlpGeneratorType type, IEnumerable<IGqlpSchema> asts, string test, string label, string input = "")
  {
    IGqlpSchema schema = schemaMerger.Merge(asts).First();

    GqlpGeneratorContext context = new(label + " " + test, new($"GqlPlus.{label}_{test}", baseType, type), new GqlpModelOptions("GqlPlus"));

    schemaGenerator.Generate(schema, context);

    string result = context.ToString();
    if (!input.IsWhiteSpace()) {
      result = "/* " + test + "\r\n" + input.TrimEnd() + "\r\n*/\r\n\r\n" + result;
    }

    return result.TrimEnd();
  }
}

public interface ISchemaGeneratorChecks
  : ISchemaParseChecks
{
  string Generate_ForAsts(GqlpBaseType baseType, GqlpGeneratorType type, IEnumerable<IGqlpSchema> asts, string test, string label, string input = "");
}
