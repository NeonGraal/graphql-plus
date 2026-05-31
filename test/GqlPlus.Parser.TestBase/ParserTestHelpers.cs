using GqlPlus.Token;

namespace GqlPlus;

public static class ParserTestHelpers
{
  public static ITokenizer Tokens(this string input)
  {
    Tokenizer tokens = new(input);
    tokens.Read();
    return tokens;
  }
}
