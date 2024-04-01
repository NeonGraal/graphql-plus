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
    string[] expected = ["!_ConstantMap", key + ": " + value, value + ": " + key];

    switch (string.Compare(key, value, StringComparison.Ordinal)) {
      case 0:
        return;
      case > 0:
        expected = ["!_ConstantMap", value + ": " + key, key + ": " + value];
        break;
      default:
        break;

    }

    ConstantAst ast = new(AstNulls.At, value.ConstantObject(key));
    _checks.AstExpected(ast, expected);
  }

  internal override ICheckModelBase<string> BaseChecks => _checks;

  private readonly ConstantModelChecks _checks = new(modeller);
}

internal sealed class ConstantModelChecks(
  IModeller<ConstantAst, ConstantModel> modeller
) : CheckModelBase<string, ConstantAst, ConstantModel>(modeller)
{
  protected override string[] ExpectedBase(string input)
    => [input.YamlQuoted()];

  protected override ConstantAst NewBaseAst(string input)
    => new FieldKeyAst(AstNulls.At, input);
}
