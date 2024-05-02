using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseOutputReferenceTests(
  Parser<OutputReferenceAst>.D parser
) : TestReference
{
  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValues_ReturnsCorrectAst(string name, string enumType, string[] enumValues)
    => _checks.TrueExpected(
      name + "<" + enumValues.Joined(s => enumType + "." + s) + ">",
      _checks.Reference(name) with {
        Arguments = [.. enumValues.Select(enumValue => _checks.Reference(enumType) with { EnumValue = enumValue })]
      });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValueBad_ReturnsFalse(string name, string enumType)
    => _checks.False(name + "<" + enumType + ".>");

  internal override ICheckReference ReferenceChecks => _checks;

  private readonly CheckReference<OutputReferenceAst> _checks = new(new OutputFactories(), parser);
}
