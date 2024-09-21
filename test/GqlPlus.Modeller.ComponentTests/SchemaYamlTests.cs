using FluentAssertions.Execution;

using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Resolving;
using GqlPlus.Result;

namespace GqlPlus;

public class SchemaYamlTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger,
    IModelAndRender renderer
) : SchemaDataBase(parser)
{
  [Fact]
  public async Task Yaml_All()
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());

    ITypesContext context = renderer.WithBuiltIns();
    RenderStructure result = ModelAsts(asts, context);

    using AssertionScope scope = new();
    context.Errors.Should().BeNullOrEmpty("!All");
    await Verify(result.ToYaml(true), CustomSettings("Schema", "Yaml", "!ALL"));
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Yaml_Groups(string group)
  {
    IEnumerable<IGqlpSchema> asts = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required());

    ITypesContext context = renderer.WithBuiltIns();
    RenderStructure result = ModelAsts(asts, context);

    using AssertionScope scope = new();
    context.Errors.Should().BeNullOrEmpty("!" + group);
    await Verify(result.ToYaml(true), CustomSettings("Schema", "Yaml", "!" + group));
  }

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Yaml_Merges(string model)
  {
    string input = SchemaValidMergesData.Source[model];
    await ReplaceActionAsync(input, model, Verify_Model);
  }

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public async Task Yaml_Objects(string model)
  {
    string input = SchemaValidObjectsData.Source[model];
    await ReplaceActionAsync(input, model, Verify_Model);
  }

  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public async Task Yaml_Globals(string global)
  {
    string input = SchemaValidGlobalsData.Source[global];
    await ReplaceActionAsync(input, global, Verify_Model);
  }

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public async Task Yaml_Simple(string simple)
  {
    string input = SchemaValidSimpleData.Source[simple];
    await ReplaceActionAsync(input, simple, Verify_Model);
  }

  private async Task Verify_Model(string input, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);
    IGqlpSchema ast = parse.Required();

    ITypesContext context = renderer.WithBuiltIns();
    RenderStructure result = ModelAsts([ast], context);

    using AssertionScope scope = new();
    context.Errors.Should().BeNullOrEmpty(test);
    await Verify(result.ToYaml(true), CustomSettings("Schema", "Yaml", test));
  }

  private RenderStructure ModelAsts(IEnumerable<IGqlpSchema> asts, ITypesContext context)
  {
    IGqlpSchema schema = merger.Merge(asts).First();

    RenderStructure result = renderer.RenderAst(schema, context);

    return result;
  }
}
