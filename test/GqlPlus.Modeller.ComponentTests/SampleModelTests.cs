﻿using System.Reflection;
using Fluid;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling;
using GqlPlus.Parsing;
using Microsoft.Extensions.FileProviders;

#pragma warning disable IDE0130
namespace GqlPlus.Sample;

public class SampleModelTests(
    Parser<IGqlpSchema>.D schemaParser,
    IModeller<IGqlpSchema, SchemaModel> schemaModeller,
    ITypesModeller types
) : SampleChecks(schemaParser)
{
  static SampleModelTests()
    => RenderFluid.Setup(
      new EmbeddedFileProvider(Assembly.GetExecutingAssembly(),
      "GqlPlus.Html"));

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

    await Verify(result.ToYaml(true), SampleSettings("Yaml", sample));
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task JsonSchema(string sample)
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

    await Verify(result.ToJson(), "json", SampleSettings("Json", sample));
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task HtmlSchema(string sample)
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

    await RenderFluid.WriteHtmlFileAsync("Sample", sample, result);
  }

  [Fact]
  public void Html_Index()
  {
    RenderStructure groups = RenderStructure.New("");
    groups.Add("All", RenderStructure.ForAll(new SampleSchemaData().Select(i => (string)i[0])));

    RenderStructure result = RenderStructure.New("");
    result.Add("groups", groups);

    result.WriteHtmlFile("Sample", "index", "index");
  }
}
