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
  [ClassData(typeof(SampleSchemaData))]
  public async Task YamlSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    ITypesContext context = renderer.WithBuiltIns();
    Structured result = renderer.RenderAst(ast, context);
    context.Errors.Add(ast.Errors);

    await CheckErrors("Schema", sample, context.Errors);

    await Verify(result.ToYaml(true), CustomSettings("Sample", "Yaml", sample));
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task JsonSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    Structured result = renderer.RenderAst(ast, renderer.WithBuiltIns());

    await Verify(result.ToJson(), "json", CustomSettings("Sample", "Json", sample));
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task HtmlSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    Structured result = renderer.RenderAst(ast, renderer.WithBuiltIns());

    await result.WriteHtmlFileAsync("Sample", sample);
  }

  [Fact]
  public void Html_Index()
  {
    Structured result = new Map<Structured>() {
      ["groups"] = new Map<Structured>() {
        ["All"] = SchemaValidData.Sample.Render(),
      }.Render(),
    }.Render("");

    result.WriteHtmlFile("Sample", "index", "index");
  }
}
