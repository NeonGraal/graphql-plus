using System.Reflection;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Modelling;
using GqlPlus.Parsing;
using GqlPlus.Result;
using Microsoft.Extensions.FileProviders;

#pragma warning disable IDE0130
namespace GqlPlus.SchemaData;

public class SchemaHtmlTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger,
    IModeller<IGqlpSchema, SchemaModel> modeller,
    ITypesModeller types
) : SchemaDataBase(parser)
{
  [Fact]
  public void Html_Index()
  {
    RenderStructure groups = RenderStructure.New("");
    groups.Add("All", RenderStructure.ForAll(["!ALL", "!Globals", "!Merges", "!Objects", "!Simple"]));
    groups.Add("Globals", RenderStructure.ForAll(SchemaValidGlobalsData.Source.Keys));
    groups.Add("Merges", RenderStructure.ForAll(ReplaceKeys(SchemaValidMergesData.Source)));
    groups.Add("Objects", RenderStructure.ForAll(ReplaceKeys(SchemaValidObjectsData.Source)));
    groups.Add("Simple", RenderStructure.ForAll(SchemaValidSimpleData.Source.Keys));

    RenderStructure result = RenderStructure.New("");
    result.Add("groups", groups);

    result.WriteHtmlFile("Schema", "index", "index");
  }

  [Fact]
  public void Html_All()
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    result.WriteHtmlFile("Schema", "!ALL");
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public void Html_Groups(string group)
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    result.WriteHtmlFile("Schema", "!" + group);
  }

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public void Html_Merges(string model)
  {
    string input = SchemaValidMergesData.Source[model];
    if (IsObjectInput(input)) {
      foreach ((string label, string abbr) in Replacements) {
        Verify_Model(ReplaceValue(input, label, abbr), label + "-" + model);
      }
    } else {
      Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public void Html_Objects(string model)
  {
    string input = SchemaValidObjectsData.Source[model];
    if (IsObjectInput(input)) {
      foreach ((string label, string abbr) in Replacements) {
        Verify_Model(ReplaceValue(input, label, abbr), label + "-" + model);
      }
    } else {
      Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public void Html_Globals(string global)
  {
    string input = SchemaValidGlobalsData.Source[global];
    if (IsObjectInput(input)) {
      foreach ((string label, string abbr) in Replacements) {
        Verify_Model(ReplaceValue(input, label, abbr), label + "-" + global);
      }
    } else {
      Verify_Model(input, global);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public void Html_Simple(string simple)
  {
    string input = SchemaValidSimpleData.Source[simple];
    if (IsObjectInput(input)) {
      foreach ((string label, string abbr) in Replacements) {
        Verify_Model(ReplaceValue(input, label, abbr), label + "-" + simple);
      }
    } else {
      Verify_Model(input, simple);
    }
  }

  private void Verify_Model(string input, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);
    IGqlpSchema ast = parse.Required();

    RenderStructure result = ModelAsts([ast]);

    result.WriteHtmlFile("Schema", test);
  }

  private RenderStructure ModelAsts(IEnumerable<IGqlpSchema> asts)
  {
    IGqlpSchema schema = merger.Merge(asts).First();

    TypesCollection context = TypesCollection.WithBuiltins(types);
    SchemaModel model = modeller.ToModel(schema, context);
    context.AddModels(model.Types.Values);
    context.Errors.Clear();

    RenderStructure result = model.Render(context);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    return result;
  }
}
