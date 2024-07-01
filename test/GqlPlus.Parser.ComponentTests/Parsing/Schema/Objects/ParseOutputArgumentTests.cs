using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputArgumentTests(
  Parser<IGqlpOutputArgument>.D parser
) : TestObjectArgument
{
  // Todo: correct
  //[Theory, RepeatData(Repeats)]
  //public void WithArgumentEnumValues_ReturnsCorrectAst(string enumType, string[] enumValues)
  //  => _checks.TrueExpected(
  //    "<" + enumValues.Joined(s => enumType + "." + s) + ">",
  //    _checks.ObjBase(name) with {
  //      BaseArguments = [.. enumValues.Select(enumMember => _checks.ObjArg(enumType) with { EnumMember = enumMember })]
  //    });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValueBad_ReturnsFalse(string enumType)
    => _checks.False(enumType + ".");

  internal override ICheckObjectArgument ObjectArgumentChecks => _checks;

  private readonly CheckObjectArgument<IGqlpOutputArgument, OutputArgumentAst> _checks = new(new OutputFactories(), parser);
}
