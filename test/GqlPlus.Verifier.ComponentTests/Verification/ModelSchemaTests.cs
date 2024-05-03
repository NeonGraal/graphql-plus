using GqlPlus.Ast.Schema;
using GqlPlus.Merging;
using GqlPlus.Modelling;
using GqlPlus.Parse;
using GqlPlus.Rendering;
using GqlPlus.Result;

namespace GqlPlus.Verification;

public class ModelSchemaTests(
    Parser<SchemaAst>.D parser,
    IMerge<SchemaAst> merger,
    IModeller<SchemaAst, SchemaModel> modeller,
    ITypesModeller types
) : SchemaBase(parser)
{
  [Fact]
  public async Task Model_All()
  {
    var asts = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());

    var result = ModelAsts(asts);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();

    await Verify(result.ToYaml(), settings);
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Model_Groups(string group)
  {
    var asts = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required());

    var result = ModelAsts(asts);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseTextForParameters(group);

    await Verify(result.ToYaml(), settings);
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public async Task Model_Merges(string model)
  {
    var input = VerifySchemaValidMergesData.Source[model];
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
    var input = VerifySchemaValidObjectsData.Source[model];
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
    var input = VerifySchemaValidGlobalsData.Source[global];
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
    var input = VerifySchemaValidSimpleData.Source[simple];
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
    var parse = Parse(input);
    var ast = parse.Required();

    var result = ModelAsts([ast]);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(ModelSchemaTests));
    settings.UseTypeName("Model");
    settings.UseMethodName(test);

    await Verify(result.ToYaml(), settings);
  }

  private RenderStructure ModelAsts(IEnumerable<SchemaAst> asts)
  {
    var schema = merger.Merge(asts).First();

    var context = TypesCollection.WithBuiltins(types);
    var model = modeller.ToModel(schema, context);
    context.AddModels(model.Types.Values);
    context.Errors.Clear();

    var result = model.Render(context);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    return result;
  }
}
