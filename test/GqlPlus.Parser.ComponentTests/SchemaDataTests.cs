using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus;

public class SchemaDataTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger
) : SchemaDataBase(parser)
{
  [Fact]
  public void VerifySchemaDataKeys()
  {
    IEnumerable<string> duplicateKeys = SchemaValidMergesData.Source.Keys
      .Concat(SchemaValidObjectsData.Source.Keys)
      .Concat(SchemaValidGlobalsData.Source.Keys)
      .Concat(SchemaValidSimpleData.Source.Keys)
      .GroupBy(k => k)
      .Where(g => g.Count() > 1)
      .Select(g => g.Key);

    duplicateKeys.Should().BeEmpty();
  }

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
    IEnumerable<IGqlpSchema> schemas = ReplaceObjects([input])
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

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    await Verify(result.Select(s => s.Render()), settings);
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Merge_Groups(string group)
  {
    IGqlpSchema[] schemas = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required())
      .ToArray();

    IEnumerable<IGqlpSchema> result = merger.Merge(schemas);

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseTextForParameters(group);

    await Verify(result.Select(s => s.Render()), settings);
  }

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Merge_Valid(string merge)
  {
    string input = SchemaValidMergesData.Source[merge];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Merge(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + merge))
        .ToArray());
    } else {
      await Verify_Merge(input, merge);
    }
  }

  private async Task Verify_Merge(string input, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    IEnumerable<IGqlpSchema> result = merger.Merge([parse.Required()]);

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SchemaDataTests));
    settings.UseTypeName("Merge");
    settings.UseMethodName(test);

    await Verify(result.Select(s => s.Render()), settings);
  }
}
