﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse;

internal class ParseDefault(
  Parser<ConstantAst>.D constant
) : IParserDefault
{
  private readonly Parser<ConstantAst>.L _constant = constant;

  public IResult<ConstantAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => tokens.Take('=') ? _constant.Parse(tokens, "Default").MapEmpty(
          () => tokens.Error<ConstantAst>("Default", "value after '='")
        ) : 0.Empty<ConstantAst>();
}

public interface IParserDefault : Parser<ConstantAst>.I { }
