using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualBaseTests(
  Parser<IGqlpDualBase>.D parser
) : TestObjectBase
{
  internal override ICheckObjectBase ObjectBaseChecks => _checks;

  private readonly CheckObjectBase<IGqlpDualBase, DualBaseAst, IGqlpDualArgument, DualArgumentAst> _checks = new(new DualFactories(), parser);
}
