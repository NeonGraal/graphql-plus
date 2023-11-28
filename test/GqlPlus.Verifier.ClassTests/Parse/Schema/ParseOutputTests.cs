using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputTests : BaseObjectTests
{
  internal override IBaseObjectChecks Checks => Test;

  private readonly BaseObjectParserChecks<OutputAst, OutputFieldAst, OutputReferenceAst> Test;

  public ParseOutputTests(IParser<OutputAst> parser)
    => Test = new(new OutputFactories(), parser);
}
