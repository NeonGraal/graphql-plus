using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class OptionSettingAst(
  ITokenAt At,
  string Name,
  string Description,
  IGqlpConstant Value)
  : AstAliased(At, Name, Description)
  , IEquatable<OptionSettingAst>
  , IGqlpSchemaSetting
{
  internal override string Abbr => "OS";

  public OptionSettingAst(TokenAt at, string name, IGqlpConstant value)
    : this(at, name, "", value) { }

  public bool Equals(OptionSettingAst? other)
    => base.Equals(other)
    && Value.Equals(other.Value);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Value);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Value.Prefixed("="));
}
