using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputArgsTests
  : ObjectArgsParseTestBase<IGqlpOutputArg>
{
  protected override Parser<IGqlpOutputArg>.IA Parser { get; } = new ParseOutputArgs();
}
