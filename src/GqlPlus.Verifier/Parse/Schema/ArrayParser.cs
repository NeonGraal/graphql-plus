using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema;

internal class ArrayParser<TItem>(
  Parser<TItem>.D regex
) : Parser<TItem>.IA
{
  private readonly Parser<TItem>.L _regex = regex;

  public IResultArray<TItem> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var result = new List<TItem>();
    var regex = _regex.Parse(tokens, label);
    if (regex.IsError()) {
      return regex.AsResultArray(result);
    }

    while (regex.Required(result.Add)) {
      regex = _regex.Parse(tokens, label);
      if (regex.IsError()) {
        return regex.AsResultArray(result);
      }
    }

    return result.OkArray();
  }
}
