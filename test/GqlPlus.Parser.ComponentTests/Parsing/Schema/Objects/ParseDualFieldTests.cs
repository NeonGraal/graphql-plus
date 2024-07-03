using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualFieldTests(
  Parser<IGqlpDualField>.D parser
) : TestObjectField
{
  internal override ICheckObjectField FieldChecks => _checks;

  private readonly CheckObjectField<IGqlpDualField, DualFieldAst, IGqlpDualBase, DualBaseAst, IGqlpDualArgument, DualArgumentAst> _checks = new(new DualFactories(), parser);
}
