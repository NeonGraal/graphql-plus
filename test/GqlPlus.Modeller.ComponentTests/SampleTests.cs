using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling;
using GqlPlus.Parsing;

namespace GqlPlus;

public class SampleTests(
    Parser<IGqlpSchema>.D schemaParser,
    IModeller<IGqlpSchema, SchemaModel> schemaModeller,
    ITypesModeller types
) : SampleChecks(schemaParser)
{
  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task ModelSampleSchema(string sample)
  {
    IGqlpSchema ast = await ParseSchema(sample);
    TypesCollection context = TypesCollection.WithBuiltins(types);

    SchemaModel model = schemaModeller.ToModel(ast, context);
    context.AddModels(model.Types.Values);
    context.Errors.Clear();

    RenderStructure result = model.Render(context);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    await Verify(result.ToYaml(), SampleSettings("ModelSchema", sample));
  }
}
