﻿using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

public class SimpleModelTests : ModelBaseTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Boolean(bool value)
    => _checks.AstExpected(new(AstNulls.At, "Boolean", value.TrueFalse()), [value.TrueFalse()]);

  [Theory, RepeatData(Repeats)]
  public void Model_Enum(string type, string value)
    => _checks.AstExpected(new(AstNulls.At, type, value), ["!" + type + " " + value]);

  [Fact]
  public void Model_Nothing()
    => _checks.AstExpected(new(AstNulls.At), ["!Basic null"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Number(decimal number)
    => _checks.AstExpected(new(AstNulls.At, number), [$"{number}"]);

  internal override IModelBaseChecks<string> BaseChecks => _checks;
  protected override string[] ExpectedBase(string input)
    => [input];

  private readonly SimpleModelChecks _checks = new();
}
