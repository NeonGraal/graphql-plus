namespace GqlPlus.Parsing.Schema;

public class AliasesClassTestBase
  : ModifiersClassTestBase
{
  private readonly Parser<string>.IA _aliases;

  public AliasesClassTestBase()
  {
    _aliases = A.Of<Parser<string>.IA>();
    _aliases.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<string>());

    Parsers.ArrayFor<string>().ReturnsForAnyArgs(() => _aliases);
  }

  internal void ParseAliasesOk(string[] aliases)
    => ParseOkA(_aliases, aliases);
  internal void ParseAliasesError()
    => ParseErrorA(_aliases);
}
