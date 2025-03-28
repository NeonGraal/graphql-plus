using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class SchemaHtmlTests(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger,
    IModelAndRender schemaRenderer
) : SchemaDataBase(schemaParser)
{
  [Fact]
  public async Task Index_Samples()
  {
    string[] all = ["!ALL", "!Globals", "!Merges", "!Objects", "!Simple"];

    IEnumerable<string> merges = await ReplaceSchemaKeys("Merges");
    IEnumerable<string> objects = await ReplaceSchemaKeys("Objects");
    Structured result = new Map<Structured>() {
      ["title"] = "Samples",
      ["groups"] = new Map<Structured>() {
        ["All"] = all.Render(),
        ["Globals"] = SamplesSchemaGlobalsData.Strings.Render(),
        ["Merges"] = merges.Render(),
        ["Objects"] = objects.Render(),
        ["Simple"] = SamplesSchemaSimpleData.Strings.Render(),
      }.Render()
    }.Render();

    await result.WriteHtmlFileAsync("Samples", "index", "index");
  }

  [Fact]
  public void Index_Schema()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Schema",
      ["groups"] = new Map<Structured>() {
        ["Schema"] = SamplesSchemaData.Strings.Render(),
      }.Render(),
    }.Render("");

    result.WriteHtmlFile("Schema", "index", "index");
  }

  [Fact]
  public void Index_Spec()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Specification",
      ["groups"] = new Map<Structured>() {
        ["Spec"] = SamplesSchemaSpecificationData.Strings.Render(),
      }.Render(),
    }.Render("");

    result.WriteHtmlFile("Spec", "index", "index");
  }

  [Fact]
  public async Task Html_All()
    => Verify_Model(await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Html_Groups(string group)
    => Verify_Model(await SchemaValidDataGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Html_Merges(string model)
    => await ReplaceFile("Merges", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Html_Objects(string model)
    => await ReplaceFile("Objects", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Html_Globals(string global)
    => await ReplaceFile("Globals", global, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Html_Simple(string simple)
    => await ReplaceFile("Simple", simple, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task Html_Schema(string sample)
  {
    IGqlpSchema ast = await ParseSample("Schema", sample);

    Structured result = ModelAsts([ast]);

    await result.WriteHtmlFileAsync("Schema", sample);
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task Html_Spec(string sample)
  {
    IGqlpSchema ast = await ParseSample("Spec", sample, "Specification");

    Structured result = ModelAsts([ast]);

    await result.WriteHtmlFileAsync("Spec", sample);
  }

  private void Verify_Model(string input, string testDirectory, string test)
    => Verify_Model([input], test);

  private void Verify_Model(IEnumerable<string> inputs, string test)
  {
    IEnumerable<IGqlpSchema> asts = inputs.Select(input => Parse(input, "Sample").Required());

    Structured result = ModelAsts(asts);

    result.WriteHtmlFile("Samples", test);
  }

  private Structured ModelAsts(IEnumerable<IGqlpSchema> asts)
  {
    IGqlpSchema schema = schemaMerger.Merge(asts).First();

    Structured result = schemaRenderer.RenderAst(schema, schemaRenderer.WithBuiltIns());

    return result;
  }
}
