using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputTests(
  Parser<OutputDeclAst>.D parser
) : BaseObjectTests
{
  internal override IBaseObjectChecks ObjectChecks => _checks;

  private readonly BaseObjectChecks<OutputDeclAst, OutputFieldAst, OutputReferenceAst> _checks
    = new(new OutputFactories(), parser);
}
