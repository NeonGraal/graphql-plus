namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseAliases : IParserArray<string>
{
  public IResultArray<string> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var aliases = new List<string>();
    if (tokens.Take('[')) {
      while (tokens.Identifier(out var alias)) {
        aliases.Add(alias);
      }

      if (!tokens.Take("]")) {
        return tokens.PartialArray("Aliases", "']' to end aliases", () => aliases);
      } else if (aliases.Count == 0) {
        return tokens.ErrorArray("Aliases", "at least one alias after '['", aliases);
      }
    }

    return aliases.OkArray();
  }
}
