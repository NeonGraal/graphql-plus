﻿using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParserTests
{
  [Theory]
  [InlineData(":Boolean")]
  [InlineData("query:Boolean?")]
  [InlineData("query Test{success}")]
  [InlineData("($name){person($name){name}}")]
  [InlineData("{...person}fragment person on Person{name}")]
  [InlineData("($test)@test($test):Boolean")]
  [InlineData("($test):Boolean($test)")]
  [InlineData("{test}[]")]
  public void Parse_ShouldSucceed(string input)
  {
    var tokens = new Tokenizer(input);
    var parser = new OperationParser(tokens);

    OperationAst? ast = parser.Parse();

    ast.Should().BeOfType<OperationAst>()
      .Subject.Result.Should().Be(ParseResult.Success);
    ast!.Errors.Should().BeEmpty();
  }

  [Theory]
  [InlineData("")]
  [InlineData(":")]
  [InlineData("{")]
  [InlineData("{field")]
  public void Parse_ShouldFail(string input)
  {
    var tokens = new Tokenizer(input);
    var parser = new OperationParser(tokens);

    OperationAst? ast = parser.Parse();

    ast.Should().BeOfType<OperationAst>()
      .Subject.Result.Should().Be(ParseResult.Failure);
    ast!.Errors.Should().NotBeEmpty();
  }
}
