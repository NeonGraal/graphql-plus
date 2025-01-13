using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public sealed class ValueListParser<T>(
  Parser<T>.D value
) : Parser<T>.IA
{
  private readonly Parser<T>.L _value = value;

  public IResultArray<T> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);

    List<T> list = [];

    if (!tokens.Take('[')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(']')) {
      if (!_value.Parse(tokens, label).Required(list.Add)) {
        return tokens.ErrorArray(label, "a value in list", list);
      }

      tokens.Take(',');
    }

    return list.OkArray();
  }
}
