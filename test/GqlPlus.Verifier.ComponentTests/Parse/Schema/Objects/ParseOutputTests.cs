using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseOutputTests(
  Parser<OutputDeclAst>.D parser
) : BaseObjectTests
{
  internal override IBaseObjectChecks ObjectChecks => _checks;

  private readonly BaseObjectChecks<OutputDeclAst, OutputFieldAst, OutputReferenceAst> _checks
    = new(new OutputFactories(), parser);
}
