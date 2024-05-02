using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseInputReferenceTests
  : TestReference
{
  internal override ICheckReference ReferenceChecks => _checks;

  private readonly CheckReference<InputReferenceAst> _checks;

  public ParseInputReferenceTests(Parser<InputReferenceAst>.D parser)
    => _checks = new(new InputFactories(), parser);
}
