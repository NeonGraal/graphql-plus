namespace GqlPlus.Modelling.Schema;

public class SimpleModelTests(
  ISimpleModelChecks checks
) : TestModelBase<string, SimpleModel>(checks)
{
  [Theory, RepeatData]
  public void Model_Boolean(bool value)
    => checks.SimpleExpected(new FieldKeyAst(AstNulls.At, "Boolean", value.TrueFalse()), [value.TrueFalse()]);

  [Theory, RepeatData]
  public void Model_Enum(string type, string value)
    => checks.SimpleExpected(new FieldKeyAst(AstNulls.At, type, value), ["!" + type + " " + value]);

  [Fact]
  public void Model_Nothing()
    => checks.SimpleExpected(new FieldKeyAst(AstNulls.At), [""]);

  [Theory, RepeatData]
  public void Model_Number(decimal number)
    => checks.SimpleExpected(new FieldKeyAst(AstNulls.At, number), [$"{number:0.#####}"]);
}

internal sealed class SimpleModelChecks(
  IModeller<IGqlpFieldKey, SimpleModel> modeller,
  IEncoder<SimpleModel> encoding
) : CheckModelBase<string, IGqlpFieldKey, FieldKeyAst, SimpleModel>(modeller, encoding)
  , ISimpleModelChecks
{
  public void SimpleExpected(IGqlpFieldKey ast, string[] expected)
    => AstExpected((FieldKeyAst)ast, expected);

  protected override string[] ExpectedBase(string name)
    => [name.Quoted("'")];

  protected override FieldKeyAst NewBaseAst(string input)
    => new(AstNulls.At, input);
}

public interface ISimpleModelChecks
  : ICheckModelBase<string, SimpleModel>
{
  void SimpleExpected(IGqlpFieldKey ast, string[] expected);
}
