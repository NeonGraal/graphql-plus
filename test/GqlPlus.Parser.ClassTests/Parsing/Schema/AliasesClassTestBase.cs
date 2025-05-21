namespace GqlPlus.Parsing.Schema;

public class AliasesClassTestBase
  : ModifiersClassTestBase
{
  private readonly Parser<string>.IA _aliases;

  internal Parser<string>.DA Aliases { get; }

  public AliasesClassTestBase()
    => Aliases = ParserAFor(out _aliases);

  internal void ParseAliasesOk(string[] aliases)
    => ParseOkA(_aliases, aliases);
  internal void ParseAliasesError()
    => ParseErrorA(_aliases);
}
