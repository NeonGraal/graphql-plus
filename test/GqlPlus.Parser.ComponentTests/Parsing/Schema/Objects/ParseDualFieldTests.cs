using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualFieldTests(
  Parser<DualFieldAst>.D parser
) : TestObjectField
{
  internal override ICheckObjectField FieldChecks => _checks;

  private readonly CheckObjectField<DualFieldAst, IGqlpDualBase, DualBaseAst> _checks = new(new DualFactories(), parser);
}
