using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputBaseTests
  : ObjectParseTestBase<IGqlpInputBase, IGqlpInputArg>
{
  public ParseInputBaseTests()
    => BaseParser = new ParseInputBase(ParseArgs);

  protected override Parser<IGqlpInputBase>.I BaseParser { get; }
}
