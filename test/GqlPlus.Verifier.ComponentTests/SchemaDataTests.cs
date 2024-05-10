using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus;

public class SchemaDataTests(
    Parser<IGqlpSchema>.D parser,
    IVerify<IGqlpSchema> verifier
) : SchemaDataBase(parser)
{
  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public void Verify_ValidGlobals(string global)
    => Verify_Valid(SchemaValidGlobalsData.Source[global]);

  [Theory]
  [ClassData(typeof(SchemaInvalidGlobalsData))]
  public async Task Verify_InvalidGlobals(string global)
    => await Verify_Invalid(SchemaInvalidGlobalsData.Source[global], global);

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public void Verify_ValidMerges(string schema)
  {
    string input = SchemaValidMergesData.Source[schema];
    if (IsObjectInput(input)) {
      using AssertionScope scope = new();

      foreach ((string objLabel, string objAbbr) in Replacements) {
        Verify_Valid(ReplaceObject(input, objLabel, objAbbr));
      }
    } else {
      Verify_Valid(input);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public void Verify_ValidSimple(string simple)
    => Verify_Valid(SchemaValidSimpleData.Source[simple]);

  [Theory]
  [ClassData(typeof(SchemaInvalidSimpleData))]
  public async Task Verify_InvalidSimple(string simple)
    => await Verify_Invalid(SchemaInvalidSimpleData.Source[simple], simple);

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public void Verify_ValidObjects(string obj)
  {
    string input = SchemaValidObjectsData.Source[obj];
    if (IsObjectInput(input)) {
      using AssertionScope scope = new();

      foreach ((string objLabel, string objAbbr) in Replacements) {
        Verify_Valid(ReplaceObject(input, objLabel, objAbbr));
      }
    } else {
      Verify_Valid(input);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaInvalidObjectsData))]
  public async Task Verify_InvalidObjects(string obj)
  {
    string input = SchemaInvalidObjectsData.Source[obj];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Invalid(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + obj))
        .ToArray());
    } else {
      await Verify_Invalid(input, obj);
    }
  }

  private void Verify_Valid(string input)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    if (parse is IResultError<SchemaAst> error) {
      error.Message.Should().BeNull();
    }

    TokenMessages result = [];

    verifier.Verify(parse.Required(), result);

    result.Should().BeNullOrEmpty();
  }

  private async Task Verify_Invalid(string input, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    TokenMessages result = [];
    if (parse.IsOk()) {
      verifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(e => result.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    result.Should().NotBeEmpty(input);

    await Verify(result.Select(m => m.Message), SchemaSettings("Invalid", test));
  }
}
