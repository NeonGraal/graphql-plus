using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputReferenceTests : BaseReferenceTests
{
  internal override IBaseReferenceChecks Checks => Test;

  private static BaseReferenceChecks<InputReferenceAst> Test => new(
    new InputFactories(),
    (SchemaParser parser, out InputReferenceAst? result) => parser.ParseReference(new InputParserFactories(parser), "").Required(out result));
}
