using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseInputTests(
  Parser<InputDeclAst>.D parser
) : BaseObjectTests
{
  internal override IBaseObjectChecks ObjectChecks => _checks;

  private readonly BaseObjectChecks<InputDeclAst, InputFieldAst, InputReferenceAst> _checks = new(new InputFactories(), parser);
}
