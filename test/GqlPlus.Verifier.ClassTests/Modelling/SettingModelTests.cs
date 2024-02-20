using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class SettingModelTests
  : ModelDescribedTests<SettingInput>
{
  protected override string[] ExpectedDescription(SettingInput input, string description)
    => ["!_Setting",
      description,
      "name: " + input.Name,
      "value: " + input.Value];

  internal override IModelDescribedChecks<SettingInput> DescribedChecks => _checks;

  private readonly SettingModelChecks _checks = new();
}

internal sealed class SettingModelChecks
  : ModelDescribedChecks<SettingInput, OptionSettingAst>
{
  internal readonly IModeller<OptionSettingAst> Setting;
  internal readonly IModeller<ConstantAst> Constant;

  public SettingModelChecks()
    => Setting = new SettingModeller(
      Constant = ForModeller<ConstantAst, ConstantModel>(
        a => new(SimpleModel.Str("", a.Value?.Value ?? a.Value?.String ?? ""))));

  protected override IRendering AstToModel(OptionSettingAst ast)
    => Setting.ToRenderer(ast);

  protected override OptionSettingAst NewDescribedAst(SettingInput input, string description)
    => input.ToAst(description);
}

public record struct SettingInput(string Name, string Value)
{
  internal readonly OptionSettingAst ToAst(string description)
    => new(AstNulls.At, Name, description, new FieldKeyAst(AstNulls.At, Value));
}
