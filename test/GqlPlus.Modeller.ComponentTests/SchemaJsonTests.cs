using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Resolving;
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
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceValue(input, r.Item1, r.Item2), r.Item1 + "-" + model))
        .ToArray());
    } else {
      await Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public async Task Json_Objects(string model)
  {
    string input = SchemaValidObjectsData.Source[model];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceValue(input, r.Item1, r.Item2), r.Item1 + "-" + model))
        .ToArray());
    } else {
      await Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public async Task Json_Globals(string global)
  {
    string input = SchemaValidGlobalsData.Source[global];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceValue(input, r.Item1, r.Item2), r.Item1 + "-" + global))
        .ToArray());
    } else {
      await Verify_Model(input, global);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public async Task Json_Simple(string simple)
  {
    string input = SchemaValidSimpleData.Source[simple];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceValue(input, r.Item1, r.Item2), r.Item1 + "-" + simple))
        .ToArray());
    } else {
      await Verify_Model(input, simple);
    }
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

    RenderStructure result = renderer.RenderAst(schema, renderer.WithBuiltIns());

    return result;
  }
}
