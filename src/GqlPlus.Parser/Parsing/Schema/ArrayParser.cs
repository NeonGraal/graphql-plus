using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ArrayParser<TItem>(
  Parser<TItem>.D itemParser
) : Parser<TItem>.IA
{
  private readonly Parser<TItem>.L _itemParser = itemParser;

  public IResultArray<TItem> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<TItem> result = [];
    IResult<TItem> item = _itemParser.Parse(tokens, label);
    if (item.IsError()) {
      return item.AsResultArray(result);
    }

    while (item.Required(result.Add)) {
      item = _itemParser.Parse(tokens, label);
      if (item.IsError()) {
        return item.AsResultArray(result);
      }
    }

    return result.OkArray();
  }
}
