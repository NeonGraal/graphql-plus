using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputReferenceTests
  : BaseReferenceTests
{
  internal override IBaseReferenceChecks ReferenceChecks => _checks;

  private readonly BaseReferenceParsedChecks<InputReferenceAst> _checks;

  public ParseInputReferenceTests(Parser<InputReferenceAst>.D parser)
    => _checks = new(new InputFactories(), parser);
}
