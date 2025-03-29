using GqlPlus.Modelling;

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
    checks.ConstantExpected(ast, expected);
  }
}

internal sealed class ConstantModelChecks(
  IModeller<IGqlpConstant, ConstantModel> modeller,
  IRenderer<ConstantModel> rendering
) : CheckModelBase<string, IGqlpConstant, ConstantAst, ConstantModel>(modeller, rendering)
  , IConstantModelChecks
{
  public void ConstantExpected(IGqlpConstant ast, string[] expected)
    => AstExpected((ConstantAst)ast, expected);

  protected override string[] ExpectedBase(string input)
    => [input.YamlQuoted()];

  protected override ConstantAst NewBaseAst(string input)
    => new(new FieldKeyAst(AstNulls.At, input));
}

public interface IConstantModelChecks
  : ICheckModelBase<string, ConstantModel>
{
  void ConstantExpected(IGqlpConstant ast, string[] expected);
}
