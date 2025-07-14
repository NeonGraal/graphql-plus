﻿using GqlPlus.Modelling;

namespace GqlPlus.Schema;

public class ConstantModelTests(
  IConstantModelChecks checks
) : TestModelBase<string, ConstantModel>(checks)
{
  [Theory, RepeatData]
  public void Model_List(string value)
    => checks
    .ConstantExpected(
      new ConstantAst(AstNulls.At, value.ConstantList()),
      ["- " + value, "- " + value]);

  [Theory, RepeatData]
  public void Model_Object(string key, string value)
  {
    Assert.SkipWhen(key == value, "key == value");

    string[] expected = ["!_ConstantMap", key + ": " + value, value + ": " + key];

    if (string.Compare(key, value, StringComparison.Ordinal) > 0) {
      expected = ["!_ConstantMap", value + ": " + key, key + ": " + value];
    }

    ConstantAst ast = new(AstNulls.At, value.ConstantObject(key));
    checks.ConstantExpected(ast, expected);
  }
}

internal sealed class ConstantModelChecks(
  IModeller<IGqlpConstant, ConstantModel> modeller,
  IEncoder<ConstantModel> encoding
) : CheckModelBase<string, IGqlpConstant, ConstantAst, ConstantModel>(modeller, encoding)
  , IConstantModelChecks
{
  public void ConstantExpected(IGqlpConstant ast, string[] expected)
    => AstExpected((ConstantAst)ast, expected);

  protected override string[] ExpectedBase(string input)
    => [input.Quoted("'")];

  protected override ConstantAst NewBaseAst(string input)
    => new(new FieldKeyAst(AstNulls.At, input));
}

public interface IConstantModelChecks
  : ICheckModelBase<string, ConstantModel>
{
  void ConstantExpected(IGqlpConstant ast, string[] expected);
}
