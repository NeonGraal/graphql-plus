using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OptionSettingAst(TokenAt At, string Name, string Description, ConstantAst Value)
  : AstAliased(At, Name, Description), IEquatable<OptionSettingAst>
{
  internal override string Abbr => "OS";

  public OptionSettingAst(TokenAt at, string name, ConstantAst value)
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
