using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputTests(Parser<OutputDeclAst>.D parser)
  : BaseObjectTests
{
  internal override IBaseObjectChecks Checks => _test;

  private readonly BaseObjectChecks<OutputDeclAst, OutputFieldAst, OutputReferenceAst> _test
    = new(new OutputFactories(), parser);
}
