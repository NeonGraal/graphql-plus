namespace GqlPlus.Modelling.Simple;

public class ConstantModelTests(
  IModeller<IGqlpConstant, ConstantModel> modeller,
  IRenderer<ConstantModel> rendering
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

  private readonly ConstantModelChecks _checks = new(modeller, rendering);
}

internal sealed class ConstantModelChecks(
  IModeller<IGqlpConstant, ConstantModel> modeller,
  IRenderer<ConstantModel> rendering
) : CheckModelBase<string, IGqlpConstant, ConstantAst, ConstantModel>(modeller, rendering)
{
  protected override string[] ExpectedBase(string input)
    => [input.YamlQuoted()];

  protected override ConstantAst NewBaseAst(string input)
    => new FieldKeyAst(AstNulls.At, input);
}
