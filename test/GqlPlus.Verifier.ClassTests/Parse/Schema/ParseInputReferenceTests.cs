using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.ClassTests.Parse.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputReferenceTests : BaseReferenceTests
{
  internal override IBaseReferenceChecks Checks => Test;

  private static BaseReferenceChecks<InputReferenceAst> Test => new(
    new InputFactories(),
    (SchemaParser parser, out InputReferenceAst result) => parser.ParseReference(out result, new InputParserFactories(parser)));
}
