using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public sealed class ValueListParser<TValue>(
  Parser<TValue>.D value
) : Parser<TValue>.IA
{
  private readonly Parser<TValue>.L _value = value;

  public IResultArray<TValue> Parse(ITokenizer tokens, string label)

  {
    tokens.ThrowIfNull();

    List<TValue> list = [];

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
