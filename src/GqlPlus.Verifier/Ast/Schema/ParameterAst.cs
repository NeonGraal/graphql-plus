using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ParameterAst(TokenAt At, InputReferenceAst Type)
  : AstAlternate<InputReferenceAst>(At, Type), IEquatable<ParameterAst>
{
  public ConstantAst? Default { get; set; }

  internal override string Abbr => "Pa";

  internal ParameterAst(TokenAt at, string input, string description = "")
    : this(at, new InputReferenceAst(at, input, description)) { }

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
