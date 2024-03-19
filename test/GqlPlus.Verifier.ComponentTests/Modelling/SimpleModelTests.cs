﻿using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class SimpleModelTests
  : TestModelBase<string>
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

  internal override ICheckModelBase<string> BaseChecks => _checks;

  private readonly SimpleModelChecks _checks = new();
}

internal sealed class SimpleModelChecks
  : CheckModelBase<string, FieldKeyAst, SimpleModel>
{
  public SimpleModelChecks()
    : base(new SimpleModeller())
  { }

  protected override string[] ExpectedBase(string name)
    => [name];

  protected override FieldKeyAst NewBaseAst(string input)
    => new(AstNulls.At, input);
}
