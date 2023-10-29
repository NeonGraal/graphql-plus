using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.ClassTests.Parse.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputFieldTests : BaseFieldTests
{
  internal override IBaseFieldChecks Checks => Test;

  private static BaseFieldChecks<InputFieldAst, InputReferenceAst> Test => new(
    new InputFactories(),
    (SchemaParser parser, out InputFieldAst result) => parser.ParseField(out result, new InputParserFactories(parser)));
}
