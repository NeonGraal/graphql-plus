﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Modelling;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus;

public class SchemaYamlTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger,
    IModeller<IGqlpSchema, SchemaModel> modeller,
    IRenderer<SchemaModel> renderer,
    ITypesModeller types
) : SchemaDataBase(parser)
{
  [Fact]
  public async Task Yaml_All()
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    await Verify(result.ToYaml(true), SchemaSettings("Yaml", "!ALL"));
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Yaml_Groups(string group)
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required());

    RenderStructure result = ModelAsts(asts);

    await Verify(result.ToYaml(true), SchemaSettings("Yaml", "!" + group));
  }

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Yaml_Merges(string model)
  {
    string input = SchemaValidMergesData.Source[model];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceValue(input, r.Item1, r.Item2), r.Item1 + "-" + model))
        .ToArray());
    } else {
      await Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public async Task Yaml_Objects(string model)
  {
    string input = SchemaValidObjectsData.Source[model];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceValue(input, r.Item1, r.Item2), r.Item1 + "-" + model))
        .ToArray());
    } else {
      await Verify_Model(input, model);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public async Task Yaml_Globals(string global)
  {
    string input = SchemaValidGlobalsData.Source[global];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceValue(input, r.Item1, r.Item2), r.Item1 + "-" + global))
        .ToArray());
    } else {
      await Verify_Model(input, global);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public async Task Yaml_Simple(string simple)
  {
    string input = SchemaValidSimpleData.Source[simple];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Model(ReplaceValue(input, r.Item1, r.Item2), r.Item1 + "-" + simple))
        .ToArray());
    } else {
      await Verify_Model(input, simple);
    }
  }

  private async Task Verify_Model(string input, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);
    IGqlpSchema ast = parse.Required();

    RenderStructure result = ModelAsts([ast]);

    await Verify(result.ToYaml(true), SchemaSettings("Yaml", test));
  }

  private RenderStructure ModelAsts(IEnumerable<IGqlpSchema> asts)
  {
    IGqlpSchema schema = merger.Merge(asts).First();

    TypesCollection context = TypesCollection.WithBuiltins(types);
    SchemaModel model = modeller.ToModel(schema, context);
    context.AddModels(model.Types.Values);
    context.Errors.Clear();

    RenderStructure result = renderer.Render(model, context);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    return result;
  }
}
