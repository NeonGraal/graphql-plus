using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseDualArgTests(
  ICheckObjectArg<IGqlpObjArg> checks
) : TestObjectArg<IGqlpObjArg>(checks)
{ }

internal sealed class ParseDualArgChecks(
  Parser<IGqlpObjArg>.DA parser
) : CheckObjectArg<IGqlpObjArg, DualArgAst>(new DualFactories(), parser)
{ }
