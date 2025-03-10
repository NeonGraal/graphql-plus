﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Schema;

public class ParseSchemaTests(
  Parser<IGqlpSchema>.D parser
)
{
  private readonly Parser<IGqlpSchema>.L _parser = parser;

  [Theory]
  [InlineData("category { Query }")]
  [InlineData("enum Test { Value }")]
  [InlineData("category { Query } enum Test { Value }")]
  [InlineData("'Description' enum Test { Value }")]
  [InlineData("category { Query } 'Description' enum Test { Value }")]
  public void Parse_ShouldSucceed(string input)
  {
    Tokenizer tokens = new(input);

    IGqlpSchema result = _parser.Parse(tokens, "Schema").Required();

    // using AssertionScope scope = new();

    result.ShouldBeOfType<SchemaAst>();
    result.ThrowIfNull().Result.ShouldBe(ParseResultKind.Success);
    result.Errors.ShouldBeEmpty();
  }

  [Theory]
  [InlineData("")]
  public void Parse_ShouldFail(string input)
  {
    Tokenizer tokens = new(input);

    IResult<IGqlpSchema> result = _parser.Parse(tokens, "Schema");
    result.Optional(ast => {
      // using AssertionScope scope = new();

      ast.ShouldBeNull();
      result.IsError(err => err.Message.ShouldNotBeNullOrWhiteSpace());
    });
  }

  [Theory]
  [InlineData("enum Test Value }")]
  [InlineData("category { Query } extra")]
  public void Parse_ShouldPartiallySucceed(string input)
  {
    Tokenizer tokens = new(input);

    IGqlpSchema? ast = _parser.Parse(tokens, "Schema").Optional();

    // using AssertionScope scope = new();

    ast.ShouldBeOfType<SchemaAst>()
      .Result.ShouldBe(ParseResultKind.Failure);
    ast.ThrowIfNull().Errors.ShouldNotBeEmpty();
  }
}
