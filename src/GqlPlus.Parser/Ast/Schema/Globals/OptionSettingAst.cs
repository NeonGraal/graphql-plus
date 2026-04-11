using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class OptionSettingAst(
  ITokenAt At,
  string Name,
  string Description,
  IAstConstant Value)
  : AstAliased(At, Name, Description)
  , IAstSchemaSetting
{
  internal override string Abbr => "OS";

  public OptionSettingAst(TokenAt at, string name, IAstConstant value)
    : this(at, name, "", value) { }

  public bool Equals(OptionSettingAst? other)
    => other is IAstSchemaSetting setting && Equals(setting);
  public bool Equals(IAstSchemaSetting? other)
    => base.Equals(other as IAstAliased)
    && Value.Equals(other.Value);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Value.NullHashCode());

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Value.Prefixed("="));
}
