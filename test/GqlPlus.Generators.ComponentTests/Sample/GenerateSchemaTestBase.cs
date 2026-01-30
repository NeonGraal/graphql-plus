using GqlPlus.Abstractions.Schema;
using GqlPlus.Generating;
using GqlPlus.Merging;
using GqlPlus.Parsing;

namespace GqlPlus.Sample;

public abstract class GenerateSchemaTestBase(
  ISchemaGeneratorChecks checks
) : TestSchemaAsts(checks)
{
  protected override async Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[] dirs, string section, string input = "")
  {
    string result = checks.Generate_ForAsts(BaseType, GeneratorType, asts, test, label, input);

    if (!string.IsNullOrWhiteSpace(result)) {
      TestContext.Current.AddAttachment(result, $"{GeneratorType}_{test}.cs");
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

    GqlpGeneratorContext context = new(label + " " + test, new($"Components.{label}_{test}", baseType, type), new GqlpModelOptions("ComponentTests", "Cmpt"));

    schemaGenerator.Generate(schema, context);

    string result = context.ToString();
    if (!string.IsNullOrWhiteSpace(result) && !string.IsNullOrWhiteSpace(input)) {
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
