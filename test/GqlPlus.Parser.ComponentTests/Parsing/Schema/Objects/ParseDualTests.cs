using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualTests(
  Parser<DualDeclAst>.D parser
) : TestObject
{
  internal override ICheckObject ObjectChecks => _checks;

  private readonly CheckObject<DualDeclAst, DualFieldAst, DualBaseAst> _checks = new(new DualFactories(), parser);
}
