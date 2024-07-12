using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualArgumentTests(
  ICheckObjectArgument<IGqlpDualArgument> checks
) : TestObjectArgument<IGqlpDualArgument>(checks)
{ }

internal sealed class ParseDualArgumentChecks(
  Parser<IGqlpDualArgument>.DA parser
) : CheckObjectArgument<IGqlpDualArgument, DualArgumentAst>(new DualFactories(), parser)
{ }
