using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ParameterAst(TokenAt At, InputReferenceAst Input)
  : AlternateAst<InputReferenceAst>(At, Input), IEquatable<ParameterAst>
{
  public ConstantAst? Default { get; set; }

  internal override string Abbr => "P";

  internal ParameterAst(TokenAt at, string input)
    : this(at, new InputReferenceAst(at, input)) { }

  public bool Equals(ParameterAst? other)
    => base.Equals(other)
    && Default.NullEqual(other.Default);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Default);

  internal override IEnumerable<string?> GetFields()
    => new[] { "!" + Abbr }
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString())
      .Append(Default is null ? "" : "=" + Default.ToString());
}
