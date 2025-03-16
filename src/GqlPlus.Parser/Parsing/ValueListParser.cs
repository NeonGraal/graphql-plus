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
    tokens.ThrowIfNull();

    List<T> list = [];

#pragma warning disable CA1062 // Validate arguments of public methods
    if (!tokens.Take('[')) {
      return list.EmptyArray();
    }
#pragma warning restore CA1062 // Validate arguments of public methods

    while (!tokens.Take(']')) {
      if (!_value.Parse(tokens, label).Required(list.Add)) {
        return tokens.ErrorArray(label, "a value in list", list);
      }

      tokens.Take(',');
    }

    return list.OkArray();
  }
}
