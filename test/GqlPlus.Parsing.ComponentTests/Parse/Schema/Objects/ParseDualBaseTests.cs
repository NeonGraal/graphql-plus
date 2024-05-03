using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parse.Schema.Objects;

public class ParseDualBaseTests(
  Parser<DualBaseAst>.D parser
) : TestObjectBase
{
  internal override ICheckObjectBase ObjectBaseChecks => _checks;

  private readonly CheckObjectBase<DualBaseAst> _checks = new(new DualFactories(), parser);
}
