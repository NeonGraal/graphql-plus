using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputTests : BaseObjectTests
{
  internal override IBaseObjectChecks Checks => _test;

  private readonly BaseObjectParserChecks<InputDeclAst, InputFieldAst, InputReferenceAst> _test;

  public ParseInputTests(Parser<InputDeclAst>.D parser)
    => _test = new(new InputFactories(), parser);
}
