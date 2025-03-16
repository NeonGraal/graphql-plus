using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Parsing;
using GqlPlus.Resolving;

namespace GqlPlus.Sample;

public class ModelTests(
    Parser<IGqlpSchema>.D schemaParser,
    IModelAndRender renderer
) : SampleSchemaChecks(schemaParser)
{
  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task YamlSchema(string sample)
  {
    IGqlpSchema ast = await ParseSample("Schema", sample);

    ITypesContext context = renderer.WithBuiltIns();
    Structured result = renderer.RenderAst(ast, context);
    context.Errors.Add(ast.Errors);

    await CheckErrors("Schema", "", sample, context.Errors);

    await Verify(result.ToYaml(true), CustomSettings("Sample", "Yaml", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task JsonSchema(string sample)
  {
    IGqlpSchema ast = await ParseSample("Schema", sample);

    Structured result = renderer.RenderAst(ast, renderer.WithBuiltIns());

    await Verify(result.ToJson(), "json", CustomSettings("Sample", "Json", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task HtmlSchema(string sample)
  {
    IGqlpSchema ast = await ParseSample("Schema", sample);

    Structured result = renderer.RenderAst(ast, renderer.WithBuiltIns());

    await result.WriteHtmlFileAsync("Sample", sample);
  }
  [Theory]

  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task YamlSpec(string sample)
  {
    IGqlpSchema ast = await ParseSample("Spec", sample, "Specification");

    ITypesContext context = renderer.WithBuiltIns();
    Structured result = renderer.RenderAst(ast, context);
    context.Errors.Add(ast.Errors);

    await CheckErrors("Schema", "Specification", sample, context.Errors);

    await Verify(result.ToYaml(true), CustomSettings("Spec", "Yaml", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task JsonSpec(string sample)
  {
    IGqlpSchema ast = await ParseSample("Spec", sample, "Specification");

    Structured result = renderer.RenderAst(ast, renderer.WithBuiltIns());

    await Verify(result.ToJson(), "json", CustomSettings("Spec", "Json", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task HtmlSpec(string sample)
  {
    IGqlpSchema ast = await ParseSample("Spec", sample, "Specification");

    Structured result = renderer.RenderAst(ast, renderer.WithBuiltIns());

    await result.WriteHtmlFileAsync("Spec", sample);
  }

  [Fact]
  public void Sample_Index()
  {
    Structured result = new Map<Structured>() {
      ["groups"] = new Map<Structured>() {
        ["Sample"] = SamplesSchemaData.Strings.Render(),
      }.Render(),
    }.Render("");

    result.WriteHtmlFile("Sample", "index", "index");
  }

  [Fact]
  public void Spec_Index()
  {
    Structured result = new Map<Structured>() {
      ["groups"] = new Map<Structured>() {
        ["Spec"] = SamplesSchemaSpecificationData.Strings.Render(),
      }.Render(),
    }.Render("");

    result.WriteHtmlFile("Spec", "index", "index");
  }
}
