using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ArrayParser<TItem>(
  IParserRepository parsers
) : IParserArray<TItem>
{
  private readonly ParserOne<TItem> _itemParser = parsers.ParserFor<TItem>();

  public IResultArray<TItem> Parse([NotNull] ITokenizer tokens, string label)

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

  internal static ArrayParser<TItem> Factory(IParserRepository p) => new(p);
}
