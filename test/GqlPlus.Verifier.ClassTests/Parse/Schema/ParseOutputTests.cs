using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputTests : BaseObjectTests
{
  internal override IBaseObjectChecks Checks => _test;

  private readonly BaseObjectParserChecks<OutputAst, OutputFieldAst, OutputReferenceAst> _test;

  public ParseOutputTests(Parser<OutputAst>.D parser)
    => _test = new(new OutputFactories(), parser);
}
