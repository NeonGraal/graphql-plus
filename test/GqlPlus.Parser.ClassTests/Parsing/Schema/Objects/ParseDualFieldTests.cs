using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualFieldTests
  : ObjectFieldParseTestBase<IAstDualField>
{
  public ParseDualFieldTests()
    => Parser = new ParseDualField(Parsers);

  protected override Parser<IAstDualField>.I Parser { get; }
}
