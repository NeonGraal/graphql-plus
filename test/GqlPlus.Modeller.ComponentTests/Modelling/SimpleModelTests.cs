namespace GqlPlus.Modelling;

public class SimpleModelTests(
  ISimpleModelChecks checks
) : TestModelBase<string, SimpleModel>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void Model_Boolean(bool value)
    => checks.SimpleExpected(new FieldKeyAst(AstNulls.At, "Boolean", value.TrueFalse()), [value.TrueFalse()]);

  [Theory, RepeatData(Repeats)]
  public void Model_Enum(string type, string value)
    => checks.SimpleExpected(new FieldKeyAst(AstNulls.At, type, value), ["!" + type + " " + value]);

  [Fact]
  public void Model_Nothing()
    => checks.SimpleExpected(new FieldKeyAst(AstNulls.At), ["!Basic null"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Number(decimal number)
    => checks.SimpleExpected(new FieldKeyAst(AstNulls.At, number), [$"{number}"]);
}

internal sealed class SimpleModelChecks(
  IModeller<IGqlpFieldKey, SimpleModel> modeller,
  IRenderer<SimpleModel> rendering
) : CheckModelBase<string, IGqlpFieldKey, FieldKeyAst, SimpleModel>(modeller, rendering)
  , ISimpleModelChecks
{
  public void SimpleExpected(IGqlpFieldKey ast, string[] expected)
    => AstExpected((FieldKeyAst)ast, expected);

  protected override string[] ExpectedBase(string name)
    => [name.YamlQuoted()];

  protected override FieldKeyAst NewBaseAst(string input)
    => new(AstNulls.At, input);
}

public interface ISimpleModelChecks
  : ICheckModelBase<string, SimpleModel>
{
  void SimpleExpected(IGqlpFieldKey ast, string[] expected);
}
