using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputBaseTests(
  Parser<IGqlpInputBase>.D parser
) : TestObjectBase
{
  internal override ICheckObjectBase ObjectBaseChecks => _checks;

  private readonly CheckObjectBase<IGqlpInputBase, InputBaseAst, IGqlpInputArgument, InputArgumentAst> _checks = new(new InputFactories(), parser);
}
