using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal sealed class SettingModelChecks : ModelDescribedChecks<SettingInput, OptionSettingAst>
{
  protected override IRendering AstToModel(OptionSettingAst ast)
    => ast.ToModel();

  protected override OptionSettingAst NewDescribedAst(SettingInput input, string description)
    => input.ToAst(description);
}

public record struct SettingInput(string Name, string Value)
{
  internal readonly OptionSettingAst ToAst(string description)
    => new(AstNulls.At, Name, description, new FieldKeyAst(AstNulls.At, Value));
}
