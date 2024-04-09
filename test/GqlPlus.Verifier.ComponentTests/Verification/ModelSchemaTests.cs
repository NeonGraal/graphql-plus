using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Modelling;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Verification;

public class ModelSchemaTests(
    Parser<SchemaAst>.D parser,
    IMerge<SchemaAst> merger,
    IModeller<SchemaAst, SchemaModel> modeller,
    ITypesModeller types
) : MergeSchemaBase(parser)
{
  [Fact]
  public async Task Model_AllSchemas()
  {
    var asts = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());
    var schemas = merger.Merge(asts);

    var context = TypesCollection.WithBuiltins(types);
    var result = modeller.ToModel(schemas.FirstOrDefault(), context);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();

    await Verify(result.Render(context).ToYaml(), settings);
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Model_Schemas(string group)
  {
    var asts = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required());
    var schemas = merger.Merge(asts);

    var context = TypesCollection.WithBuiltins(types);
    var result = modeller.ToModel(schemas.FirstOrDefault(), context);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseTextForParameters(group);

    await Verify(result.Render(context).ToYaml(), settings);
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public async Task Model_Valid(string model)
  {
    var input = VerifySchemaValidMergesData.Source[model];
    if (IsObjectInput(input)) {
      await WhenAll(
        Verify_Model(ReplaceObject(input, "dual", "Dual"), "dual-" + model),
        Verify_Model(ReplaceObject(input, "input", "Inp"), "input-" + model),
        Verify_Model(ReplaceObject(input, "output", "Outp"), "output-" + model));
    } else {
      await Verify_Model(input, model);
    }
  }

  private async Task Verify_Model(string input, string test)
  {
    var parse = Parse(input);
    var ast = parse.Required();
    var schema = merger.Merge([ast]).First();

    var context = TypesCollection.WithBuiltins(types);
    var result = modeller.ToModel(schema, context);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(ModelSchemaTests));
    settings.UseTypeName("Model");
    settings.UseMethodName(test);

    await Verify(result.Render(context).ToYaml(), settings);
  }
}
