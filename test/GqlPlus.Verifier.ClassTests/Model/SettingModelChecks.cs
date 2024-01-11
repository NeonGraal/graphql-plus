using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal sealed class SettingModelChecks : ModelDescribedChecks<SettingInput, OptionSettingAst>
{
  protected override IRendering AstToModel(OptionSettingAst ast)
    => ast.ToModel();

  protected override OptionSettingAst NewAst(SettingInput input)
    => input.ToAst;
}

public record struct SettingInput(string Name, string Value)
{
  internal readonly OptionSettingAst ToAst
    => new(AstNulls.At, Name, new FieldKeyAst(AstNulls.At, Value));
}
