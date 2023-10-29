using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.ClassTests.Parse.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputFieldTests : BaseFieldTests
{
  internal override IBaseFieldChecks Checks => Test;

  private static BaseFieldChecks<OutputFieldAst, OutputReferenceAst> Test => new(
    new OutputFactories(),
    (SchemaParser parser, out OutputFieldAst result) => parser.ParseField(out result, new OutputParserFactories(parser)));
}
