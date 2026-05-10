namespace GqlPlus.Parsing.Schema;

public class AliasesClassTestBase
  : ModifiersClassTestBase
{
  private readonly IParserArray<string> _aliases;

  public AliasesClassTestBase()
  {
    _aliases = A.Of<IParserArray<string>>();
    _aliases.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<string>());

    Parsers.ArrayFor<string>().ReturnsForAnyArgs(() => _aliases);
  }

  internal void ParseAliasesOk(string[] aliases)
    => ParseOkA(_aliases, aliases);
  internal void ParseAliasesError()
    => ParseErrorA(_aliases);
}
