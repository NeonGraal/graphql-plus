using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualArgsTests
  : ObjectArgsParseTestBase<IGqlpDualArg>
{
  protected override Parser<IGqlpDualArg>.IA Parser { get; } = new ParseDualArgs();
}
