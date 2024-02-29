using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class SettingModelTests
  : DescribedModelTests<SettingInput>
{
  protected override string[] ExpectedDescription(SettingInput input, string description)
    => ["!_Setting",
      description,
      "name: " + input.Name,
      "value: " + input.Value];

  internal override IDescribedModelChecks<SettingInput> DescribedChecks => _checks;

  private readonly SettingModelChecks _checks = new();
}

internal sealed class SettingModelChecks
  : DescribedModelChecks<SettingInput, OptionSettingAst, SettingModel>
{

  public SettingModelChecks()
    : base(new SettingModeller(
      TestModeller<ConstantAst>.For<ConstantModel>(
        a => new(SimpleModel.Str("", a.Value?.Value ?? a.Value?.Text ?? "")))))
  { }

  protected override OptionSettingAst NewDescribedAst(SettingInput input, string description)
    => input.ToAst(description);
}

public record struct SettingInput(string Name, string Value)
{
  internal readonly OptionSettingAst ToAst(string description)
    => new(AstNulls.At, Name, description, new FieldKeyAst(AstNulls.At, Value));
}
