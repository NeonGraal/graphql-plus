using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualFieldTests
  : ObjectFieldParseTestBase<IGqlpDualField>
{
  public ParseDualFieldTests()
    => Parser = new ParseDualField(Aliases, Modifiers, ParseBase);

  protected override Parser<IGqlpDualField>.I Parser { get; }
}
