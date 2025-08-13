using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputArgTests(
  ICheckObjectArg<IGqlpOutputArg> checks
) : TestObjectArg<IGqlpOutputArg>(checks)
{
  [Theory, RepeatData]
  public void WithArgEnumValues_ReturnsCorrectAst(string enumType, string[] enumValues)
    => checks.TrueExpected(
      "<" + enumValues.Joined(s => enumType + "." + s) + ">",
      [.. enumValues.Select(enumLabel
        => new OutputArgAst(AstNulls.At, enumType) { EnumLabel = enumLabel })]);

  [Theory, RepeatData]
  public void WithArgEnumValueBad_ReturnsFalse(string enumType)
    => checks.FalseExpected("<" + enumType + ".");
}

internal sealed class ParseOutputArgChecks(
  Parser<IGqlpOutputArg>.DA parser
) : CheckObjectArg<IGqlpOutputArg, OutputArgAst>(new OutputFactories(), parser)
{ }
