﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Resolving;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class SchemaYamlTests(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger,
    IModelAndRender schemaRenderer
) : SchemaDataBase(schemaParser)
{
  [Fact]
  public async Task Yaml_All()
    => await Verify_Model(await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Yaml_Groups(string group)
    => await Verify_Model(await SchemaValidDataGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Yaml_Merges(string model)
    => await ReplaceFileAsync("Merges", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Yaml_Objects(string model)
    => await ReplaceFileAsync("Objects", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Yaml_Globals(string global)
    => await ReplaceFileAsync("Globals", global, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Yaml_Simple(string simple)
    => await ReplaceFileAsync("Simple", simple, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task Yaml_Schema(string sample)
  {
    IGqlpSchema ast = await ParseSample("Schema", sample);
    ITypesContext context = schemaRenderer.WithBuiltIns();

    Structured result = ModelAsts([ast], context);

    await CheckErrors("Schema", "", sample, context.Errors);

    await Verify(result.ToYaml(true), CustomSettings("Schema", "Yaml", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task Yaml_Spec(string sample)
  {
    IGqlpSchema ast = await ParseSample("Spec", sample, "Specification");
    ITypesContext context = schemaRenderer.WithBuiltIns();

    Structured result = ModelAsts([ast], context);

    await CheckErrors("Schema", "Specification", sample, context.Errors);

    await Verify(result.ToYaml(true), CustomSettings("Spec", "Yaml", sample));
  }

  private async Task Verify_Model(string input, string testDirectory, string test)
    => await Verify_Model([input], test);

  private async Task Verify_Model(IEnumerable<string> inputs, string test)
  {
    IEnumerable<IGqlpSchema> asts = inputs
      .Select(input => Parse(input, "Schema").Required());

    ITypesContext context = schemaRenderer.WithBuiltIns();
    Structured result = ModelAsts(asts, context);

    context.Errors.ShouldBeEmpty(test);
    await Verify(result.ToYaml(true), CustomSettings("Sample", "Yaml", test));
  }

  private Structured ModelAsts(IEnumerable<IGqlpSchema> asts, ITypesContext context)
  {
    IGqlpSchema schema = schemaMerger.Merge(asts).First();

    Structured result = schemaRenderer.RenderAst(schema, context);
    context.Errors.Add(asts.SelectMany(a => a.Errors));

    return result;
  }
}
