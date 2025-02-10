using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Parsing;
using GqlPlus.Resolving;

namespace GqlPlus;

public class SampleModelTests(
    Parser<IGqlpSchema>.D schemaParser,
    IModelAndRender renderer
) : SampleSchemaChecks(schemaParser)
{
  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task YamlSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    ITypesContext context = renderer.WithBuiltIns();
    RenderStructure result = renderer.RenderAst(ast, context);
    context.Errors.Add(ast.Errors);

    await CheckErrors("Schema", sample, context.Errors);

    await Verify(result.ToYaml(true), CustomSettings("Sample", "Yaml", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task JsonSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    RenderStructure result = renderer.RenderAst(ast, renderer.WithBuiltIns());

    await Verify(result.ToJson(), "json", CustomSettings("Sample", "Json", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task HtmlSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    RenderStructure result = renderer.RenderAst(ast, renderer.WithBuiltIns());

    await result.WriteHtmlFileAsync("Sample", sample);
  }

  [Fact]
  public void Html_Index()
  {
    RenderStructure groups = RenderStructure.New("");
    groups.Add("All", RenderStructure.ForAll(SchemaValidData.Sample));

    RenderStructure result = RenderStructure.New("");
    result.Add("groups", groups);

    result.WriteHtmlFile("Sample", "index", "index");
  }
}
