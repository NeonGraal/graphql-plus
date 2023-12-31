﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal interface IParseDeclaration
{
  string Selector { get; }
  IResult<AstDeclaration> Parser(Tokenizer tokens, string label);
}

internal class ParseDeclaration<T>(
  string selector,
  Parser<T>.D declaration
) : IParseDeclaration
  where T : AstDeclaration
{
  public string Selector { get; } = selector;

  public IResult<AstDeclaration> Parser(Tokenizer tokens, string label)
    => _declaration.Parse(tokens, label).AsResult<AstDeclaration>();

  private readonly Parser<T>.L _declaration = declaration;
}
