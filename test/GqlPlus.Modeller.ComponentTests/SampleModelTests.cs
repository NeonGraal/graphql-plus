using FluentAssertions.Execution;

using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Parsing;
using GqlPlus.Resolving;

namespace GqlPlus;

public class SampleModelTests(
    Parser<IGqlpSchema>.D schemaParser,
    IModelAndRender renderer
) : SampleChecks(schemaParser)
{
  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task YamlSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    ITypesContext context = renderer.WithBuiltIns();
    RenderStructure result = renderer.RenderAst(ast, context);

    using AssertionScope scope = new();
    if (sample.ThrowIfNull().EndsWith("Complete", StringComparison.InvariantCulture)) {
      context.Errors.Should().BeNullOrEmpty(sample);
    }

    await Verify(result.ToYaml(true), SampleSettings("Yaml", sample));
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task JsonSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);

    RenderStructure result = renderer.RenderAst(ast, renderer.WithBuiltIns());

    await Verify(result.ToJson(), "json", SampleSettings("Json", sample));
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
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
    groups.Add("All", RenderStructure.ForAll(new SampleSchemaData()));

    RenderStructure result = RenderStructure.New("");
    result.Add("groups", groups);

    result.WriteHtmlFile("Sample", "index", "index");
  }
}
