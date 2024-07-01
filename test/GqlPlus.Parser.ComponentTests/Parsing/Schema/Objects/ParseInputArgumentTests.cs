using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputArgumentTests(
  Parser<IGqlpInputArgument>.D parser
) : TestObjectArgument
{
  internal override ICheckObjectArgument ObjectArgumentChecks => _checks;

  private readonly CheckObjectArgument<IGqlpInputArgument, InputArgumentAst> _checks = new(new InputFactories(), parser);
}
