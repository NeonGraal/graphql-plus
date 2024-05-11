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
  public async Task Html_Index()
  {
    RenderStructure groups = RenderStructure.New("");
    groups.Add("All", RenderStructure.ForAll(["!ALL", "!Globals", "!Merges", "!Objects", "!Simple"]));
    groups.Add("Globals", RenderStructure.ForAll(SchemaValidGlobalsData.Source.Keys));
    groups.Add("Merges", RenderStructure.ForAll(SchemaValidMergesData.Source.Keys));
    groups.Add("Objects", RenderStructure.ForAll(SchemaValidObjectsData.Source.Keys));
    groups.Add("Simple", RenderStructure.ForAll(SchemaValidSimpleData.Source.Keys));

    RenderStructure result = RenderStructure.New("");
    result.Add("groups", groups);

    RenderFluid.Setup(new EmbeddedFileProvider(Assembly.GetExecutingAssembly(), "GqlPlus.Html"), "index");
    await RenderFluid.WriteHtmlFile("SchemaHtmlTests", "index", result);
  }

  [Fact]
  public async Task Html_All()
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    RenderFluid.Setup(new EmbeddedFileProvider(Assembly.GetExecutingAssembly(), "GqlPlus.Html"));
    await RenderFluid.WriteHtmlFile("SchemaHtmlTests", "!ALL", result);
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Html_Groups(string group)
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    RenderFluid.Setup(new EmbeddedFileProvider(Assembly.GetExecutingAssembly(), "GqlPlus.Html"));
    await RenderFluid.WriteHtmlFile("SchemaHtmlTests", "!" + group, result);
  }

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Html_Merges(string model)
  {
    string input = SchemaValidMergesData.Source[model];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + model))
        .ToArray());
    } else {
      await Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public async Task Html_Objects(string model)
  {
    string input = SchemaValidObjectsData.Source[model];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + model))
        .ToArray());
    } else {
      await Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public async Task Html_Globals(string global)
  {
    string input = SchemaValidGlobalsData.Source[global];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + global))
        .ToArray());
    } else {
      await Verify_Model(input, global);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public async Task Html_Simple(string simple)
  {
    string input = SchemaValidSimpleData.Source[simple];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + simple))
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

    RenderFluid.Setup(new EmbeddedFileProvider(Assembly.GetExecutingAssembly(), "GqlPlus.Html"));
    await RenderFluid.WriteHtmlFile("SchemaHtmlTests", test, result);
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
