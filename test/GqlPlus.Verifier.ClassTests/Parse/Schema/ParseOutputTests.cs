using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputTests : BaseObjectTests
{
  internal override IBaseObjectChecks Checks => Test;

  private static BaseObjectChecks<OutputAst, OutputFieldAst, OutputReferenceAst> Test => new(
    new OutputFactories(),
    parser => parser.ParseOutputDeclaration(""));
}
