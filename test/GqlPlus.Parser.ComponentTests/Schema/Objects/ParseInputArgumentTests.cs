using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseInputArgTests(
  ICheckObjectArg<IGqlpInputArg> objectArgChecks
) : TestObjectArg<IGqlpInputArg>(objectArgChecks)
{ }

internal sealed class ParseInputArgChecks(
  Parser<IGqlpInputArg>.DA parser
) : CheckObjectArg<IGqlpInputArg, InputArgAst>(new InputFactories(), parser)
{ }
