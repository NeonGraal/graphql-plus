using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseDualFieldTests
  : TestObjectField
{
  internal override ICheckObjectField FieldChecks => _checks;

  private readonly CheckObjectField<DualFieldAst, DualBaseAst> _checks;

  public ParseDualFieldTests(Parser<DualFieldAst>.D parser)
    => _checks = new(new DualFactories(), parser);
}
