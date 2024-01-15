using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputTests : BaseObjectTests
{
  internal override IBaseObjectChecks ObjectChecks => _checks;

  private readonly BaseObjectChecks<InputDeclAst, InputFieldAst, InputReferenceAst> _checks;

  public ParseInputTests(Parser<InputDeclAst>.D parser)
    => _checks = new(new InputFactories(), parser);
}
