﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

public interface IParseScalar
{
  ScalarDomain Kind { get; }
  ParseItems Parser { get; }
}

public delegate IResult<ScalarDefinition> ParseItems(Tokenizer tokens, string label, ScalarDefinition result);
