namespace GqlPlus.Verifier.Modelling;

public class ConstantModelTests(
  IModeller<ConstantAst, ConstantModel> modeller
) : TestModelBase<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_List(string value)
    => _checks
    .AstExpected(
      new(AstNulls.At, value.ConstantList()),
      ["- " + value, "- " + value]);

  [Theory, RepeatData(Repeats)]
  public void Model_Object(string key, string value)
  {
    if (key == value) {
      return;
    }

    _checks
      .AstExpected(
        new(AstNulls.At, value.ConstantObject(key)),
        ["!_ConstantMap", key + ": " + value, value + ": " + key]);
  }

  internal override ICheckModelBase<string> BaseChecks => _checks;

  private readonly ConstantModelChecks _checks = new(modeller);
}

internal sealed class ConstantModelChecks(
  IModeller<ConstantAst, ConstantModel> modeller
) : CheckModelBase<string, ConstantAst, ConstantModel>(modeller)
{
  protected override string[] ExpectedBase(string name)
    => [name];

  protected override ConstantAst NewBaseAst(string input)
    => new FieldKeyAst(AstNulls.At, input);
}
