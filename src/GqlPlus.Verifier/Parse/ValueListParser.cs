﻿namespace GqlPlus.Verifier.Parse;

public class ValueListParser<T> : Parser<T>.IA
{
  private readonly Parser<T>.L _value;

  protected ValueListParser(Parser<T>.D value)
    => _value = value;

  public IResultArray<T> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var list = new List<T>();

    if (!tokens.Take('[')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(']')) {
      if (!_value.Parse(tokens).Required(list.Add)) {
        return tokens.ErrorArray(label, "a value in list", list);
      }

      tokens.Take(',');
    }

    return list.OkArray();
  }
}
