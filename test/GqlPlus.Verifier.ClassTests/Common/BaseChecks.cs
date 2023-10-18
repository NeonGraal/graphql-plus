namespace GqlPlus.Verifier.Common;

internal class BaseChecks<P>
  where P : CommonParser
{
  internal delegate P Factory(Tokenizer tokenizer);

  private readonly Factory _factory;

  public BaseChecks(Factory factory)
    => _factory = factory;

  protected P Parser(string input)
    => _factory(Tokens(input));
}
