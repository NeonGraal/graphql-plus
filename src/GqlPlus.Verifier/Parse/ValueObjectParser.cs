﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse;

public class ValueObjectParser<T>(
  Parser<AstKeyValue<T>>.D field
) : Parser<AstObject<T>>.I
  where T : AstValue<T>
{
  private readonly Parser<AstKeyValue<T>>.L _field = field;

  public IResult<AstObject<T>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var result = new AstObject<T>();

    if (!tokens.Take('{')) {
      return result.Empty();
    }

    while (!tokens.Take('}')) {
      var field = _field.Parse(tokens, label);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error(label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok();
  }
}
