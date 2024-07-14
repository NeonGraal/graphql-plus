﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputBaseTests(
  ICheckObjectBase<IGqlpOutputBase> checks
) : TestObjectBase<IGqlpOutputBase>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithArgEnumValues_ReturnsCorrectAst(string name, string enumType, string[] enumValues)
    => checks.TrueExpected(
      name + "<" + enumValues.Joined(s => enumType + "." + s) + ">",
      new OutputBaseAst(AstNulls.At, name) with {
        BaseArgs = [.. enumValues.Select(enumMember => new OutputArgAst(AstNulls.At, enumType) with { EnumMember = enumMember })]
      });

  [Theory, RepeatData(Repeats)]
  public void WithArgEnumValueBad_ReturnsFalse(string name, string enumType)
    => checks.FalseExpected(name + "<" + enumType + ".>");
}

internal sealed class ParseOutputBaseChecks(
  Parser<IGqlpOutputBase>.D parser
) : CheckObjectBase<IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst>(new OutputFactories(), parser)
{ }
