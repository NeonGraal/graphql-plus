using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class MergeTests(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger
) : SchemaDataBase(schemaParser)
{
  [Fact]
  public async Task CanMerge_All()
    => Check_CanMerge(await SchemaValidAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task CanMerge_Groups(string group)
    => Check_CanMerge(await SchemaValidGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaValidMergesData))]
  public async Task CanMerge_Valid(string merge)
  {
    string input = await ReadSchema(merge, "ValidMerges");

    Check_CanMerge(ReplaceValue(input, merge), merge);
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaValidMergesData))]
  public async Task CanMerge_ValidEach(string merge)
    => await ReplaceFile("ValidMerges", merge, (input, _, test) => Check_CanMerge([input], test));

  [Fact]
  public async Task Merge_All()
    => await Verify_Merge(await SchemaValidAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Merge_Groups(string group)
    => await Verify_Merge(await SchemaValidGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaValidMergesData))]
  public async Task Merge_Valid(string merge)
  {
    string input = await ReadSchema(merge, "ValidMerges");

    await Verify_Merge(ReplaceValue(input, merge), "_" + merge);
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaValidMergesData))]
  public async Task Merge_ValidEach(string merge)
  {
    string input = await ReadSchema(merge, "ValidMerges");
    await ReplaceActionAsync(input, merge, (input, test) => Verify_Merge([input], test));
  }

  private void Check_CanMerge(IEnumerable<string> inputs, string testName)
  {
    IGqlpSchema[] schemas = [.. inputs.Select(input => Parse(input).Required())];

    ITokenMessages result = schemaMerger.CanMerge(schemas);

    result.ShouldBeEmpty(testName);
  }

  private async Task Verify_Merge(IEnumerable<string> inputs, string test)
  {
    IGqlpSchema[] schemas = [.. inputs.Select(input => Parse(input).Required())];

    IEnumerable<IGqlpSchema> result = schemaMerger.Merge(schemas);

    await Verify(result.Select(s => s.Show()), CustomSettings("Schema", "Merge", test));
  }
}
