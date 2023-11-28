using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputTests : BaseObjectTests
{
  internal override IBaseObjectChecks Checks => Test;

  private readonly BaseObjectParserChecks<InputAst, InputFieldAst, InputReferenceAst> Test;

  public ParseInputTests(IParser<InputAst> parser)
    => Test = new(new InputFactories(), parser);
}
