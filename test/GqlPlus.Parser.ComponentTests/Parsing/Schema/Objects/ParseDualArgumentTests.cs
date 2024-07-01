using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualArgumentTests(
  Parser<IGqlpDualArgument>.D parser
) : TestObjectArgument
{
  internal override ICheckObjectArgument ObjectArgumentChecks => _checks;

  private readonly CheckObjectArgument<IGqlpDualArgument, DualArgumentAst> _checks = new(new DualFactories(), parser);
}
