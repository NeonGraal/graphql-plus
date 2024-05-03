﻿using GqlPlus.Ast.Schema;
using GqlPlus.Parse;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Verification;

public class VerifySchemaTests(
    Parser<SchemaAst>.D parser,
    IVerify<SchemaAst> verifier
) : SchemaBase(parser)
{
  [Theory]
  [ClassData(typeof(VerifySchemaValidGlobalsData))]
  public void Verify_ValidGlobals(string global)
    => Verify_Valid(VerifySchemaValidGlobalsData.Source[global]);

  [Theory]
  [ClassData(typeof(VerifySchemaInvalidGlobalsData))]
  public async Task Verify_InvalidGlobals(string global)
    => await Verify_Invalid(VerifySchemaInvalidGlobalsData.Source[global], global);

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public void Verify_ValidMerges(string schema)
  {
    string input = VerifySchemaValidMergesData.Source[schema];
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
  [ClassData(typeof(VerifySchemaValidSimpleData))]
  public void Verify_ValidSimple(string simple)
    => Verify_Valid(VerifySchemaValidSimpleData.Source[simple]);

  [Theory]
  [ClassData(typeof(VerifySchemaInvalidSimpleData))]
  public async Task Verify_InvalidSimple(string simple)
    => await Verify_Invalid(VerifySchemaInvalidSimpleData.Source[simple], simple);

  [Theory]
  [ClassData(typeof(VerifySchemaValidObjectsData))]
  public void Verify_ValidObjects(string obj)
  {
    string input = VerifySchemaValidObjectsData.Source[obj];
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
  [ClassData(typeof(VerifySchemaInvalidObjectsData))]
  public async Task Verify_InvalidObjects(string obj)
  {
    string input = VerifySchemaInvalidObjectsData.Source[obj];
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
    IResult<SchemaAst> parse = Parse(input);

    if (parse is IResultError<SchemaAst> error) {
      error.Message.Should().BeNull();
    }

    TokenMessages result = [];

    verifier.Verify(parse.Required(), result);

    result.Should().BeNullOrEmpty();
  }

  private async Task Verify_Invalid(string input, string test)
  {
    IResult<SchemaAst> parse = Parse(input);

    TokenMessages result = [];
    if (parse.IsOk()) {
      verifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(e => result.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    result.Should().NotBeEmpty(input);

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(VerifySchemaTests));
    settings.UseTypeName("Invalid");
    settings.UseMethodName(test);

    await Verify(result.Select(m => m.Message), settings);
  }
}
