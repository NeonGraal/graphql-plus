using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseDualTests(
  Parser<DualDeclAst>.D parser
) : BaseObjectTests
{
  internal override IBaseObjectChecks ObjectChecks => _checks;

  private readonly BaseObjectChecks<DualDeclAst, DualFieldAst, DualReferenceAst> _checks = new(new DualFactories(), parser);
}
