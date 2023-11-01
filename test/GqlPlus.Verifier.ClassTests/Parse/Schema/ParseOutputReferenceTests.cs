using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputReferenceTests : BaseReferenceTests
{
  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumLabels_ReturnsCorrectAst(string name, string enumType, string[] labels)
    => Test.TrueExpected(
      name + "<" + labels.Joined(enumType + ".") + ">",
      Test.Reference(name) with {
        Arguments = labels.Select(
          label => Test.Reference(enumType) with { Label = label })
          .ToArray()
      });

  internal override IBaseReferenceChecks Checks => Test;

  private static BaseReferenceChecks<OutputReferenceAst> Test => new(
    new OutputFactories(),
    (SchemaParser parser, out OutputReferenceAst result) => parser.ParseReference(out result, new OutputParserFactories(parser), ""));
}
