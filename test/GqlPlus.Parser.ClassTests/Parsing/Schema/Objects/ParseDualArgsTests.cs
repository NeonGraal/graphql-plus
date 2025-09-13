using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualArgsTests
  : ObjectArgsParseTestBase<IGqlpObjArg>
{
  protected override Parser<IGqlpObjArg>.IA Parser { get; } = new ParseDualArgs();
}
