using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualBaseTests(
  Parser<DualBaseAst>.D parser
) : TestObjectBase
{
  internal override ICheckObjectBase ObjectBaseChecks => _checks;

  private readonly CheckObjectBase<DualBaseAst> _checks = new(new DualFactories(), parser);
}
