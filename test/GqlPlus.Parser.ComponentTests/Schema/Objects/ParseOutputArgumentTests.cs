using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseOutputArgTests(
  ICheckObjectArg<IGqlpObjArg> checks
) : TestObjectArg<IGqlpObjArg>(checks)
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
  Parser<IGqlpObjArg>.DA parser
) : CheckObjectArg<IGqlpObjArg, OutputArgAst>(new OutputFactories(), parser)
{ }
