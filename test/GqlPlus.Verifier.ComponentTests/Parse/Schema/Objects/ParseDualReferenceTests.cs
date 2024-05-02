using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseDualReferenceTests
  : TestReference
{
  internal override ICheckReference ReferenceChecks => _checks;

  private readonly CheckReference<DualReferenceAst> _checks;

  public ParseDualReferenceTests(Parser<DualReferenceAst>.D parser)
    => _checks = new(new DualFactories(), parser);
}
