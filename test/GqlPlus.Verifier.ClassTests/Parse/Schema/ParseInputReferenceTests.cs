using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputReferenceTests : BaseReferenceTests
{
  internal override IBaseReferenceChecks Checks => _test;

  private readonly BaseReferenceParsedChecks<InputReferenceAst> _test;

  public ParseInputReferenceTests(Parser<InputReferenceAst>.D parser)
    => _test = new(new InputFactories(), parser);
}
