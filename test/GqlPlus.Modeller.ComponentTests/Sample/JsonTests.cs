using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class JsonTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger,
    IModelAndRender renderer
) : SchemaDataBase(parser)
{
  [Fact]
  public async Task Json_All()
    => await Verify_Model(await SchemaValidAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Json_Groups(string group)
    => await Verify_Model(await SchemaValidGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Json_Merges(string model)
    => await ReplaceFileAsync("ValidMerges", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public async Task Json_Objects(string model)
    => await ReplaceFileAsync("ValidObjects", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public async Task Json_Globals(string global)
    => await ReplaceFileAsync("ValidGlobals", global, Verify_Model);

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public async Task Json_Simple(string simple)
    => await ReplaceFileAsync("ValidSimple", simple, Verify_Model);

  private async Task Verify_Model(string input, string testDirectory, string test)
    => await Verify_Model([input], test);

  private async Task Verify_Model(IEnumerable<string> inputs, string test)
  {
    IEnumerable<IGqlpSchema> asts = inputs.Select(input => Parse(input).Required());

    Structured result = ModelAsts(asts);

    await Verify(result.ToJson(), "json", CustomSettings("Schema", "Json", test));
  }

  private Structured ModelAsts(IEnumerable<IGqlpSchema> asts)
  {
    IGqlpSchema schema = merger.Merge(asts).First();

    Structured result = renderer.RenderAst(schema, renderer.WithBuiltIns());

    return result;
  }
}
