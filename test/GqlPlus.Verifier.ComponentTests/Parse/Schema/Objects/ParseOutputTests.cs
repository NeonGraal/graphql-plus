using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseOutputTests(
  Parser<OutputDeclAst>.D parser
) : TestObject
{
  internal override ICheckObject ObjectChecks => _checks;

  private readonly CheckObject<OutputDeclAst, OutputFieldAst, OutputReferenceAst> _checks
    = new(new OutputFactories(), parser);
}
