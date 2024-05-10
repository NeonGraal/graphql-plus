using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling;
using GqlPlus.Parsing;

#pragma warning disable IDE0130
namespace GqlPlus.Sample;

public class SampleModelTests(
    Parser<IGqlpSchema>.D schemaParser,
    IModeller<IGqlpSchema, SchemaModel> schemaModeller,
    ITypesModeller types
) : SampleChecks(schemaParser)
{
  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task YamlSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);
    TypesCollection context = TypesCollection.WithBuiltins(types);

    SchemaModel model = schemaModeller.ToModel(ast, context);
    context.AddModels(model.Types.Values);
    context.Errors.Clear();

    RenderStructure result = model.Render(context);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    await Verify(result.ToYaml(), SampleSettings("Yaml", sample));
  }
}
