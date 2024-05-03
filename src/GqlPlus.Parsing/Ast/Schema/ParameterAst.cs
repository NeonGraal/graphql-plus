using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;

public sealed record class ParameterAst(TokenAt At, InputBaseAst Type)
  : AstAlternate<InputBaseAst>(At, Type), IEquatable<ParameterAst>
{
  public ConstantAst? Default { get; set; }

  internal override string Abbr => "Pa";

  internal ParameterAst(TokenAt at, string input, string description = "")
    : this(at, new InputBaseAst(at, input, description)) { }

  public bool Equals(ParameterAst? other)
    => base.Equals(other)
    && Default.NullEqual(other.Default);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Default);

  internal override IEnumerable<string?> GetFields()
    => new[] { "!" + Abbr }
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString())
      .Append(Default.Prefixed("="));
}
