using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputReferenceTests : BaseReferenceTests
{
  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValues_ReturnsCorrectAst(string name, string enumType, string[] enumValues)
    => _test.TrueExpected(
      name + "<" + enumValues.Joined(enumType + ".") + ">",
      _test.Reference(name) with {
        Arguments = enumValues.Select(
          enumValue => _test.Reference(enumType) with { EnumValue = enumValue })
          .ToArray()
      });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValueBad_ReturnsFalse(string name, string enumType)
    => _test.False(name + "<" + enumType + ".>");

  internal override IBaseReferenceChecks Checks => _test;

  private readonly BaseReferenceParsedChecks<OutputReferenceAst> _test;

  public ParseOutputReferenceTests(Parser<OutputReferenceAst>.D parser)
    => _test = new(new OutputFactories(), parser);
}
