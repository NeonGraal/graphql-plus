using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputReferenceTests : BaseReferenceTests
{
  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumLabels_ReturnsCorrectAst(string name, string enumType, string[] labels)
    => _test.TrueExpected(
      name + "<" + labels.Joined(enumType + ".") + ">",
      _test.Reference(name) with {
        Arguments = labels.Select(
          label => _test.Reference(enumType) with { Label = label })
          .ToArray()
      });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumLabelBad_ReturnsFalse(string name, string enumType)
    => _test.False(name + "<" + enumType + ".>");

  internal override IBaseReferenceChecks Checks => _test;

  private readonly BaseReferenceParsedChecks<OutputReferenceAst> _test;

  public ParseOutputReferenceTests(Parser<OutputReferenceAst>.D parser)
    => _test = new(new OutputFactories(), parser);
}
