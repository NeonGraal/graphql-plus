using GqlPlus.Ast.Schema;
using GqlPlus.Generating;
using GqlPlus.Merging;
using GqlPlus.Parsing;

namespace GqlPlus.Sample;

public abstract class GenerateSchemaTestBase(
  ISchemaGeneratorChecks checks
) : TestSchemaAsts(checks)
{
  protected override async Task Test_Asts(IEnumerable<IAstSchema> asts, string test, string label, string[] dirs, string section, string input = "")
  {
    string result = checks.Generate_ForAsts(BaseType, GeneratorType, asts, test, label, input);

    await result.AttachAndVerify($"{GeneratorType}_{test}.cs", CustomSettings(label, $"Generate_{GeneratorType}", test, section, scrubEmptyLines: false));
  }

  public virtual GqlpBaseType BaseType => GqlpBaseType.Class;
  public abstract GqlpGeneratorType GeneratorType { get; }
}

internal sealed class SchemaGeneratorChecks(
    IParserRepository parsers,
    IMergerRepository mergers,
    IGeneratorRepository generators
) : SchemaParseChecks(parsers)
  , ISchemaGeneratorChecks
{
  private readonly IMerge<IAstSchema> _schemaMerger = mergers.MergerFor<IAstSchema>();
  private readonly IGenerator<IAstSchema> _schemaGenerator = generators.GeneratorFor<IAstSchema>();

  public string Generate_ForAsts(GqlpBaseType baseType, GqlpGeneratorType type, IEnumerable<IAstSchema> asts, string test, string label, string input = "")
  {
    IAstSchema schema = _schemaMerger.Merge(asts).First();

    GqlpGeneratorContext context = new(label + " " + test,
      new($"Components.{label}_{test}", baseType, type),
      new GqlpModelOptions("ComponentTests", "Cmpt"));

    _schemaGenerator.Generate(schema, context);

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
  string Generate_ForAsts(GqlpBaseType baseType, GqlpGeneratorType type, IEnumerable<IAstSchema> asts, string test, string label, string input = "");
}
