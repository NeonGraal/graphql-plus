using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputArgsTests
  : ObjectArgsParseTestBase<IGqlpInputArg>
{
  protected override Parser<IGqlpInputArg>.IA Parser { get; } = new ParseInputArgs();
}
