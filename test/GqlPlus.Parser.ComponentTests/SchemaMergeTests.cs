using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus;

public class SchemaMergeTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger
) : SchemaDataBase(parser)
{
  [Fact]
  public void CanMerge_All()
  {
    IGqlpSchema[] schemas = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required())
      .ToArray();

    ITokenMessages result = merger.CanMerge(schemas);

    result.Should().BeEmpty();
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public void CanMerge_Groups(string group)
  {
    IGqlpSchema[] schemas = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required())
      .ToArray();

    ITokenMessages result = merger.CanMerge(schemas);

    result.Should().BeEmpty();
  }

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public void CanMerge_Valid(string merge)
  {
    string input = SchemaValidMergesData.Source[merge];
    IEnumerable<IGqlpSchema> schemas = ReplaceValue(input, input)
      .Select(input => Parse(input).Required());

    ITokenMessages result = merger.CanMerge(schemas);

    result.Should().BeEmpty();
  }

  [Fact]
  public async Task Merge_All()
  {
    IEnumerable<IGqlpSchema> schemas = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());

    IEnumerable<IGqlpSchema> result = merger.Merge(schemas);

    await Verify(result.Select(s => s.Show()), SchemaSettings("Merge", "!ALL"));
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Merge_Groups(string group)
  {
    IGqlpSchema[] schemas = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required())
      .ToArray();

    IEnumerable<IGqlpSchema> result = merger.Merge(schemas);

    await Verify(result.Select(s => s.Show()), SchemaSettings("Merge", "!" + group));
  }

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Merge_Valid(string merge)
  {
    string input = SchemaValidMergesData.Source[merge];
    await ReplaceActionAsync(input, merge, Verify_Merge);
  }

  private async Task Verify_Merge(string input, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    IEnumerable<IGqlpSchema> result = merger.Merge([parse.Required()]);

    await Verify(result.Select(s => s.Show()), SchemaSettings("Merge", test));
  }
}
