using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Resolving;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class YamlTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger,
    IModelAndRender renderer
) : SchemaDataBase(parser)
{
  [Fact]
  public async Task Yaml_All()
    => await Verify_Model(await SchemaValidAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Yaml_Groups(string group)
    => await Verify_Model(await SchemaValidGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaValidMergesData))]
  public async Task Yaml_Merges(string model)
    => await ReplaceFileAsync("ValidMerges", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaValidObjectsData))]
  public async Task Yaml_Objects(string model)
    => await ReplaceFileAsync("ValidObjects", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaValidGlobalsData))]
  public async Task Yaml_Globals(string global)
    => await ReplaceFileAsync("ValidGlobals", global, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaValidSimpleData))]
  public async Task Yaml_Simple(string simple)
    => await ReplaceFileAsync("ValidSimple", simple, Verify_Model);

  private async Task Verify_Model(string input, string testDirectory, string test)
    => await Verify_Model([input], test);

  private async Task Verify_Model(IEnumerable<string> inputs, string test)
  {
    IEnumerable<IGqlpSchema> asts = inputs
    .Select(input => Parse(input).Required());

    ITypesContext context = renderer.WithBuiltIns();
    Structured result = ModelAsts(asts, context);

    // using AssertionScope scope = new();
    context.Errors.ShouldBeEmpty(test);
    await Verify(result.ToYaml(true), CustomSettings("Schema", "Yaml", test));
  }

  private Structured ModelAsts(IEnumerable<IGqlpSchema> asts, ITypesContext context)
  {
    IGqlpSchema schema = merger.Merge(asts).First();

    Structured result = renderer.RenderAst(schema, context);

    return result;
  }
}
