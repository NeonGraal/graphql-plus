using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Parse;
using GqlPlus.Result;

namespace GqlPlus.Verification;

public class MergeSchemaTests(
    Parser<IGqlpSchema>.D parser,
    IMerge<IGqlpSchema> merger
) : SchemaBase(parser)
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
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public void CanMerge_Valid(string merge)
  {
    string input = VerifySchemaValidMergesData.Source[merge];
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
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public async Task Merge_Valid(string merge)
  {
    string input = VerifySchemaValidMergesData.Source[merge];
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
    settings.UseDirectory(nameof(MergeSchemaTests));
    settings.UseTypeName("Merge");
    settings.UseMethodName(test);

    await Verify(result.Select(s => s.Render()), settings);
  }
}
