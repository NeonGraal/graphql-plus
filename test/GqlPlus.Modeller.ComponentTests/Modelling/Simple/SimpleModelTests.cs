namespace GqlPlus.Modelling.Simple;

public class SimpleModelTests(
  IModeller<IGqlpFieldKey, SimpleModel> modeller
) : TestModelBase<string>
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

  private readonly SimpleModelChecks _checks = new(modeller);
}

internal sealed class SimpleModelChecks(
  IModeller<IGqlpFieldKey, SimpleModel> modeller
) : CheckModelBase<string, IGqlpFieldKey, FieldKeyAst, SimpleModel>(modeller)
{
  protected override string[] ExpectedBase(string name)
    => [name.YamlQuoted()];

  protected override FieldKeyAst NewBaseAst(string input)
    => new(AstNulls.At, input);
}
