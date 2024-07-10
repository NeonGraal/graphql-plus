using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputArgumentTests(
  ICheckObjectArgument<IGqlpOutputArgument> checks
) : TestObjectArgument<IGqlpOutputArgument>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValues_ReturnsCorrectAst(string enumType, string[] enumValues)
    => checks.TrueExpected(
      "<" + enumValues.Joined(s => enumType + "." + s) + ">",
      [.. enumValues.Select(enumMember
        => new OutputArgumentAst(AstNulls.At, enumType) { EnumMember = enumMember })]);

  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValueBad_ReturnsFalse(string enumType)
    => checks.FalseExpected("<" + enumType + ".");
}

internal sealed class ParseOutputArgumentChecks(
  Parser<IGqlpOutputArgument>.DA parser
) : CheckObjectArgument<IGqlpOutputArgument, OutputArgumentAst>(new OutputFactories(), parser)
{ }
