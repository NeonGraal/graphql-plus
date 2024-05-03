using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Modelling;
using GqlPlus.Parse;
using GqlPlus.Rendering;
using GqlPlus.Result;

namespace GqlPlus.Verification;

public class ModelSchemaTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger,
    IModeller<IGqlpSchema, SchemaModel> modeller,
    ITypesModeller types
) : SchemaBase(parser)
{
  [Fact]
  public async Task Model_All()
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    VerifySettings settings = new();
    settings.ScrubEmptyLines();

    await Verify(result.ToYaml(), settings);
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Model_Groups(string group)
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseTextForParameters(group);

    await Verify(result.ToYaml(), settings);
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public async Task Model_Merges(string model)
  {
    string input = VerifySchemaValidMergesData.Source[model];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + model))
        .ToArray());
    } else {
      await Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidObjectsData))]
  public async Task Model_Objects(string model)
  {
    string input = VerifySchemaValidObjectsData.Source[model];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + model))
        .ToArray());
    } else {
      await Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidGlobalsData))]
  public async Task Model_Globals(string global)
  {
    string input = VerifySchemaValidGlobalsData.Source[global];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + global))
        .ToArray());
    } else {
      await Verify_Model(input, global);
    }
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidSimpleData))]
  public async Task Model_Simple(string simple)
  {
    string input = VerifySchemaValidSimpleData.Source[simple];
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

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(ModelSchemaTests));
    settings.UseTypeName("Model");
    settings.UseMethodName(test);

    await Verify(result.ToYaml(), settings);
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
