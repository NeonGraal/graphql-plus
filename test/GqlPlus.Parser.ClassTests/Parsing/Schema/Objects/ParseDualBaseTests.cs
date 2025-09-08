using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualBaseTests
  : ObjectParseTestBase<IGqlpDualBase, IGqlpDualArg>
{
  public ParseDualBaseTests()
    => BaseParser = new ParseDualBase(ParseArgs);

  protected override Parser<IGqlpDualBase>.I BaseParser { get; }
}
