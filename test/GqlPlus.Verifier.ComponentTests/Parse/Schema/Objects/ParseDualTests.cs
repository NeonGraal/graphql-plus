using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseDualTests(
  Parser<DualDeclAst>.D parser
) : TestObject
{
  internal override ICheckObject ObjectChecks => _checks;

  private readonly CheckObject<DualDeclAst, DualFieldAst, DualBaseAst> _checks = new(new DualFactories(), parser);
}
