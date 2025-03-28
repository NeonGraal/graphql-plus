using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseOutputBaseTests(
  ICheckObjectBase<IGqlpOutputBase> checks
) : TestObjectBase<IGqlpOutputBase>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithArgEnumValues_ReturnsCorrectAst(string name, string enumType, string[] enumValues)
    => checks.TrueExpected(
      name + "<" + enumValues.Joined(s => enumType + "." + s) + ">",
      new OutputBaseAst(AstNulls.At, name) with {
        BaseArgs = [.. enumValues.Select(enumLabel => new OutputArgAst(AstNulls.At, enumType) with { EnumLabel = enumLabel })]
      });

  [Theory, RepeatData(Repeats)]
  public void WithArgEnumValueBad_ReturnsFalse(string name, string enumType)
    => checks.FalseExpected(name + "<" + enumType + ".>");
}

internal sealed class ParseOutputBaseChecks(
  Parser<IGqlpOutputBase>.D parser
) : CheckObjectBase<IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst>(new OutputFactories(), parser)
{ }
