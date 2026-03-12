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

    Parser<string>.LA aliasesLazy = new(() => _aliases);
    Parsers.ArrayFor<string>().Returns(aliasesLazy);
  }

  internal void ParseAliasesOk(string[] aliases)
    => ParseOkA(_aliases, aliases);
  internal void ParseAliasesError()
    => ParseErrorA(_aliases);
}
