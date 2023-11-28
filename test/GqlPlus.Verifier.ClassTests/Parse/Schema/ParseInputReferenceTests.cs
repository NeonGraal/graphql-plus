using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputReferenceTests : BaseReferenceTests
{
  internal override IBaseReferenceChecks Checks => Test;

  private readonly BaseReferenceParsedChecks<InputReferenceAst> Test;

  public ParseInputReferenceTests(IParser<InputReferenceAst> parser)
    => Test = new(new InputFactories(), parser);
}
