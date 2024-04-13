using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Verification;

public class MergeSchemaTests(
    Parser<SchemaAst>.D parser,
    IMerge<SchemaAst> merger
) : SchemaBase(parser)
{
  [Fact]
  public void CanMerge_All()
  {
    var schemas = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.CanMerge(schemas);

    result.Should().BeEmpty();
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public void CanMerge_Groups(string group)
  {
    var schemas = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.CanMerge(schemas);

    result.Should().BeEmpty();
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public void CanMerge_Valid(string merge)
  {
    var input = VerifySchemaValidMergesData.Source[merge];
    var schemas = ReplaceObjects([input])
      .Select(input => Parse(input).Required());

    var result = merger.CanMerge(schemas);

    result.Should().BeEmpty();
  }

  [Fact]
  public async Task Merge_All()
  {
    var schemas = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required());

    var result = merger.Merge(schemas);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    await Verify(result.Select(s => s.Render()), settings);
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Merge_Groups(string group)
  {
    var schemas = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.Merge(schemas);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseTextForParameters(group);

    await Verify(result.Select(s => s.Render()), settings);
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public async Task Merge_Valid(string merge)
  {
    var input = VerifySchemaValidMergesData.Source[merge];
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
    var parse = Parse(input);

    var result = merger.Merge([parse.Required()]);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(MergeSchemaTests));
    settings.UseTypeName("Merge");
    settings.UseMethodName(test);

    await Verify(result.Select(s => s.Render()), settings);
  }
}
