namespace GqlPlus.Verifier.Parse.Schema;

internal class ArrayParser<TItem> : IParserArray<TItem>
{
  private readonly IParser<TItem> _regex;

  public ArrayParser(IParser<TItem> regex)
    => _regex = regex.ThrowIfNull();

  public IResultArray<TItem> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var result = new List<TItem>();
    var regex = _regex.Parse(tokens);
    if (regex.IsError()) {
      return regex.AsResultArray(result);
    }

    while (regex.Required(result.Add)) {
      regex = _regex.Parse(tokens);
      if (regex.IsError()) {
        return regex.AsResultArray(result);
      }
    }

    return result.OkArray();
  }
}
