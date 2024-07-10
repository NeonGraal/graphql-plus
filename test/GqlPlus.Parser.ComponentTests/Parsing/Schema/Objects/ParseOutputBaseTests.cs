using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputBaseTests(
  ICheckObjectBase<IGqlpOutputBase> checks
) : TestObjectBase<IGqlpOutputBase>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValues_ReturnsCorrectAst(string name, string enumType, string[] enumValues)
    => checks.TrueExpected(
      name + "<" + enumValues.Joined(s => enumType + "." + s) + ">",
      new OutputBaseAst(AstNulls.At, name) with {
        BaseArguments = [.. enumValues.Select(enumMember => new OutputArgumentAst(AstNulls.At, enumType) with { EnumMember = enumMember })]
      });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumValueBad_ReturnsFalse(string name, string enumType)
    => checks.FalseExpected(name + "<" + enumType + ".>");
}

internal sealed class ParseOutputBaseChecks(
  Parser<IGqlpOutputBase>.D parser
) : CheckObjectBase<IGqlpOutputBase, OutputBaseAst, IGqlpOutputArgument, OutputArgumentAst>(new OutputFactories(), parser)
{ }
