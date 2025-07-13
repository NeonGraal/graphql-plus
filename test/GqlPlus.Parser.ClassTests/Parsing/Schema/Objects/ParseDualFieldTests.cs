using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualFieldTests
  : ParseObjectFieldTestBase<IGqlpDualField, IGqlpDualBase>
{
  public ParseDualFieldTests()
    => Parser = new ParseDualField(Aliases, Modifiers, ParseBase);

  protected override Parser<IGqlpDualField>.I Parser { get; }
}
