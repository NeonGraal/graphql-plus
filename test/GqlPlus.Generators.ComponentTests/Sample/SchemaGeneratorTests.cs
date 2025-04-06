using AutoFixture;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Generating;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema;
using GqlPlus.Resolving;
using GqlPlus.Result;
using GqlPlus.Structures;
using GqlPlus.Token;

namespace GqlPlus.Sample;

public class SchemaGeneratorTests(
    ISchemaGeneratorVerifier schemaVerifier
) : SampleChecks
{
  [Fact]
  public async Task Generator_All()
    => await Verify_Model(await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Generator_Groups(string group)
    => await Verify_Model(await SchemaValidDataGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Generator_Merges(string model)
    => await ReplaceFileAsync("Merges", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Generator_Objects(string model)
    => await ReplaceFileAsync("Objects", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Generator_Globals(string global)
    => await ReplaceFileAsync("Globals", global, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Generator_Simple(string simple)
    => await ReplaceFileAsync("Simple", simple, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task Generator_Schema(string sample)
    => await schemaVerifier.Verify_ModelFor([await schemaVerifier.ParseSample("Schema", sample)], sample, "Schema");

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task Generator_Spec(string sample)
    => await schemaVerifier.Verify_ModelFor([await schemaVerifier.ParseSample("Spec", sample, "Specification")], sample, "Spec");

  private async Task Verify_Model(string input, string testDirectory, string test)
    => await schemaVerifier.Verify_ModelFor([schemaVerifier.Parse(input, "Schema").Required()], test, "Sample", input);

  private async Task Verify_Model(IEnumerable<string> inputs, string test)
    => await schemaVerifier.Verify_ModelFor(inputs.Select(input => schemaVerifier.Parse(input, "Schema").Required()), test, "Sample");
}

internal sealed class SchemaGeneratorVerifier(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger,
    IGenerator<IGqlpSchema> schemaGenerator
) : SchemaDataBase(schemaParser)
  , ISchemaGeneratorVerifier
{
  public async Task Verify_ModelFor(IEnumerable<IGqlpSchema> asts, string test, string label, string input = "")
  {
    IGqlpSchema schema = schemaMerger.Merge(asts).First();

    GeneratorContext context = new(label + " " + test, new GqlModelOptions("GqlPlus"));

    schemaGenerator.Generate(schema, context);

    string result = context.ToString();
    if (!string.IsNullOrWhiteSpace(input)) {
      result = "/* " + test + "\r\n" + input.TrimEnd() + "\r\n*/\r\n\r\n" + result;
    }

    await Verify(result.TrimEnd(), CustomSettings(label, "Generator", test, false));
  }

  IResult<IGqlpSchema> ISchemaGeneratorVerifier.Parse(string schema, string label)
    => Parse(schema, label);

  Task<IGqlpSchema> ISchemaGeneratorVerifier.ParseSample(string label, string sample, params string[] dirs)
    => ParseSample(label, sample, dirs);
}

public interface ISchemaGeneratorVerifier
{
  IResult<IGqlpSchema> Parse(string schema, string label);
  Task<IGqlpSchema> ParseSample(string label, string sample, params string[] dirs);
  Task Verify_ModelFor(IEnumerable<IGqlpSchema> asts, string test, string label, string input = "");
}
