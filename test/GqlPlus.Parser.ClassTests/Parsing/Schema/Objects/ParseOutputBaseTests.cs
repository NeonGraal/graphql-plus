using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputBaseTests
  : ObjectBaseParseTests<IGqlpOutputBase, IGqlpOutputArg>
{
  public ParseOutputBaseTests()
    => BaseParser = new ParseOutputBase(ParseArgs);

  protected override Parser<IGqlpOutputBase>.I BaseParser { get; }
}
