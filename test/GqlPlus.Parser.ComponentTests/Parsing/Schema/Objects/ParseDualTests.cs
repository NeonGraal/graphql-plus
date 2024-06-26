using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualTests(
  Parser<IGqlpDualObject>.D parser
) : TestObject
{
  internal override ICheckObject ObjectChecks => _checks;

  private readonly CheckObject<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, DualBaseAst> _checks = new(new DualFactories(), parser);
}
