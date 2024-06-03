using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputBaseTests(
  Parser<IGqlpOutputBase>.D parser
) : TestObjectBase
{
  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValues_ReturnsCorrectAst(string name, string enumType, string[] enumValues)
    => _checks.TrueExpected(
      name + "<" + enumValues.Joined(s => enumType + "." + s) + ">",
      _checks.ObjBase(name) with {
        TypeArguments = [.. enumValues.Select(enumValue => _checks.ObjBase(enumType) with { EnumValue = enumValue })]
      });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValueBad_ReturnsFalse(string name, string enumType)
    => _checks.False(name + "<" + enumType + ".>");

  internal override ICheckObjectBase ObjectBaseChecks => _checks;

  private readonly CheckObjectBase<IGqlpOutputBase, OutputBaseAst> _checks = new(new OutputFactories(), parser);
}
