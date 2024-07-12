using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputArgumentTests(
  ICheckObjectArgument<IGqlpInputArgument> objectArgumentChecks
) : TestObjectArgument<IGqlpInputArgument>(objectArgumentChecks)
{ }

internal sealed class ParseInputArgumentChecks(
  Parser<IGqlpInputArgument>.DA parser
) : CheckObjectArgument<IGqlpInputArgument, InputArgumentAst>(new InputFactories(), parser)
{ }
