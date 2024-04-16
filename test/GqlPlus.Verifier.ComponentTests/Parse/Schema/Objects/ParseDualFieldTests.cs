using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseDualFieldTests
  : BaseFieldTests
{
  internal override IBaseFieldChecks FieldChecks => _checks;

  private readonly BaseFieldChecks<DualFieldAst, DualReferenceAst> _checks;

  public ParseDualFieldTests(Parser<DualFieldAst>.D parser)
    => _checks = new(new DualFactories(), parser);
}
