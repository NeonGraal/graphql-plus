using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputArgTests(
  ICheckObjectArg<IGqlpInputArg> objectArgChecks
) : TestObjectArg<IGqlpInputArg>(objectArgChecks)
{ }

internal sealed class ParseInputArgChecks(
  Parser<IGqlpInputArg>.DA parser
) : CheckObjectArg<IGqlpInputArg, InputArgAst>(new InputFactories(), parser)
{ }
