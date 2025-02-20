﻿using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus;

public class SchemaHtmlTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger,
    IModelAndRender renderer
) : SchemaDataBase(parser)
{
  [Fact]
  public async Task Html_Index()
  {
    Structured groups = Structured.New("");
    groups.Add("All", Structured.ForAll(["!ALL", "!Globals", "!Merges", "!Objects", "!Simple"]));
    groups.Add("Globals", Structured.ForAll(SchemaValidData.Globals));
    groups.Add("Merges", Structured.ForAll(await ReplaceSchemaKeys("Merges")));
    groups.Add("Objects", Structured.ForAll(await ReplaceSchemaKeys("Objects")));
    groups.Add("Simple", Structured.ForAll(SchemaValidData.Simple));

    Structured result = Structured.New("");
    result.Add("groups", groups);

    await result.WriteHtmlFileAsync("Schema", "index", "index");
  }

  [Fact]
  public async Task Html_All()
    => Verify_Model(await SchemaValidAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Html_Groups(string group)
    => Verify_Model(await SchemaValidGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Html_Merges(string model)
    => await ReplaceFile("ValidMerges", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public async Task Html_Objects(string model)
    => await ReplaceFile("ValidObjects", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public async Task Html_Globals(string global)
    => await ReplaceFile("ValidGlobals", global, Verify_Model);

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public async Task Html_Simple(string simple)
    => await ReplaceFile("ValidSimple", simple, Verify_Model);

  private void Verify_Model(string input, string test)
    => Verify_Model([input], test);

  private void Verify_Model(IEnumerable<string> inputs, string test)
  {
    IEnumerable<IGqlpSchema> asts = inputs.Select(input => Parse(input).Required());

    Structured result = ModelAsts(asts);

    result.WriteHtmlFile("Schema", test);
  }

  private Structured ModelAsts(IEnumerable<IGqlpSchema> asts)
  {
    IGqlpSchema schema = merger.Merge(asts).First();

    Structured result = renderer.RenderAst(schema, renderer.WithBuiltIns());

    return result;
  }
}
