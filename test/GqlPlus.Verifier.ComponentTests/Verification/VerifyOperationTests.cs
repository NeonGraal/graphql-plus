﻿using GqlPlus.Ast.Operation;
using GqlPlus.Parse;
using GqlPlus.Parse.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Verification;

public class VerifyOperationTests(
    Parser<OperationAst>.D parser,
    IVerify<OperationAst> verifier)
{
  private readonly Parser<OperationAst>.L _parser = parser;

  [Theory]
  [ClassData(typeof(VerifyOperationValidData))]
  public void Verify_ValidOperations_ReturnsValid(string operation)
  {
    var parse = Parse(VerifyOperationValidData.Source[operation]);
    if (parse is IResultError<OperationAst> error) {
      error.Message.Should().BeNull();
    }

    var result = new TokenMessages();

    verifier.Verify(parse.Required(), result);

    result.Should().BeNullOrEmpty();
  }

  [Theory]
  [ClassData(typeof(VerifyOperationInvalidData))]
  public void Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    var parse = Parse(VerifyOperationInvalidData.Source[operation]);

    var result = new TokenMessages();
    if (parse.IsOk()) {
      verifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(result.Add);
    }

    result.Should().NotBeNullOrEmpty();
  }

  private IResult<OperationAst> Parse(string operation)
  {
    OperationContext tokens = new(operation);
    return _parser.Parse(tokens, "Operation");
  }
}
