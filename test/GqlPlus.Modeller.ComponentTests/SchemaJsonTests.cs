using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus;

public class SchemaJsonTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger,
    IModelAndRender renderer
) : SchemaDataBase(parser)
{
  [Fact]
  public async Task Json_All()
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    await Verify(result.ToJson(), "json", SchemaSettings("Json", "!ALL"));
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Json_Groups(string group)
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    await Verify(result.ToJson(), "json", SchemaSettings("Json", "!" + group));
  }

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Json_Merges(string model)
  {
    string input = SchemaValidMergesData.Source[model];
    await ReplaceActionAsync(input, model, Verify_Model);
  }

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public async Task Json_Objects(string model)
  {
    string input = SchemaValidObjectsData.Source[model];
    await ReplaceActionAsync(input, model, Verify_Model);
  }

  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public async Task Json_Globals(string global)
  {
    string input = SchemaValidGlobalsData.Source[global];
    await ReplaceActionAsync(input, global, Verify_Model);
  }

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public async Task Json_Simple(string simple)
  {
    string input = SchemaValidSimpleData.Source[simple];
    await ReplaceActionAsync(input, simple, Verify_Model);
  }

  private async Task Verify_Model(string input, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);
    IGqlpSchema ast = parse.Required();

    RenderStructure result = ModelAsts([ast]);

    await Verify(result.ToJson(), "json", SchemaSettings("Json", test));
  }

  private RenderStructure ModelAsts(IEnumerable<IGqlpSchema> asts)
  {
    IGqlpSchema schema = merger.Merge(asts).First();

    RenderStructure result = renderer.RenderAst(schema, withBuiltIns: true);

    return result;
  }
}
