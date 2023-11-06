using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputReferenceTests : BaseReferenceTests
{
  internal override IBaseReferenceChecks Checks => Test;

  private static BaseReferenceChecks<InputReferenceAst> Test => new(
    new InputFactories(),
    parser => parser.ParseReference(new InputParserFactories(parser), ""));
}
