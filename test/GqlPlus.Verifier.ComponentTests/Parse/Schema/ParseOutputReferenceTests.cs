using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputReferenceTests(
  Parser<OutputReferenceAst>.D parser
) : BaseReferenceTests
{
  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValues_ReturnsCorrectAst(string name, string enumType, string[] enumValues)
    => _checks.TrueExpected(
      name + "<" + enumValues.Joined(enumType + ".") + ">",
      _checks.Reference(name) with {
        Arguments = [.. enumValues.Select(enumValue => _checks.Reference(enumType) with { EnumValue = enumValue })]
      });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValueBad_ReturnsFalse(string name, string enumType)
    => _checks.False(name + "<" + enumType + ".>");

  internal override IBaseReferenceChecks ReferenceChecks => _checks;

  private readonly BaseReferenceParsedChecks<OutputReferenceAst> _checks = new(new OutputFactories(), parser);
}
