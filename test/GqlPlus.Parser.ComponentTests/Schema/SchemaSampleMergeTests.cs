using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus.Schema;

public class SchemaSampleMergeTests(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger
) : SchemaDataBase(schemaParser)
{
  [Fact]
  public async Task CanMerge_All()
    => Check_CanMerge(await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task CanMerge_Groups(string group)
    => Check_CanMerge(await SchemaValidDataGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task CanMerge_Valid(string merge)
  {
    string input = await ReadSchema(merge, "Merges");

    Check_CanMerge(ReplaceValue(input, merge), merge);
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task CanMerge_ValidEach(string merge)
    => await ReplaceFile("Merges", merge, (input, _, test) => Check_CanMerge([input], test));

  [Fact]
  public async Task Merge_All()
    => await Verify_Merge(await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Merge_Groups(string group)
    => await Verify_Merge(await SchemaValidDataGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Merge_Valid(string merge)
  {
    string input = await ReadSchema(merge, "Merges");

    await Verify_Merge(ReplaceValue(input, merge), "_" + merge);
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Merge_ValidEach(string merge)
  {
    string input = await ReadSchema(merge, "Merges");
    await ReplaceActionAsync(input, merge, (input, test) => Verify_Merge([input], test));
  }

  private void Check_CanMerge(IEnumerable<string> inputs, string testName)
  {
    IGqlpSchema[] schemas = [.. inputs.Select(input => Parse(input, "Schema").Required())];

    ITokenMessages result = schemaMerger.CanMerge(schemas);

    result.ShouldBeEmpty(testName);
  }

  private async Task Verify_Merge(IEnumerable<string> inputs, string test)
  {
    IGqlpSchema[] schemas = [.. inputs.Select(input => Parse(input, "Schema").Required())];

    IEnumerable<IGqlpSchema> result = schemaMerger.Merge(schemas);

    await Verify(result.Select(s => s.Show()), CustomSettings("Merge", "Schema", test));
  }
}
