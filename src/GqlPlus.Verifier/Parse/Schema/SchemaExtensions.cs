﻿using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

public static class SchemaExtensions
{
  public static IResult<T> End<T>(this Tokenizer tokens, string label, Func<T> result)
  {
    ArgumentNullException.ThrowIfNull(tokens);
    ArgumentNullException.ThrowIfNull(result);

    return tokens.Take('}')
        ? result().Ok()
        : tokens.Partial(label, "'}' at end of definition", result);
  }
}
