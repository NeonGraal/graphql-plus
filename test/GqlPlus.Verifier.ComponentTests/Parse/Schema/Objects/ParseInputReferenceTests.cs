using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseInputReferenceTests
  : BaseReferenceTests
{
  internal override IBaseReferenceChecks ReferenceChecks => _checks;

  private readonly BaseReferenceParsedChecks<InputReferenceAst> _checks;

  public ParseInputReferenceTests(Parser<InputReferenceAst>.D parser)
    => _checks = new(new InputFactories(), parser);
}
