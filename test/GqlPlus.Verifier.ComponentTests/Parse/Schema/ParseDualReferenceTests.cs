using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseDualReferenceTests
  : BaseReferenceTests
{
  internal override IBaseReferenceChecks ReferenceChecks => _checks;

  private readonly BaseReferenceParsedChecks<DualReferenceAst> _checks;

  public ParseDualReferenceTests(Parser<DualReferenceAst>.D parser)
    => _checks = new(new DualFactories(), parser);
}
