using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ParameterAst(TokenAt At, InputReferenceAst Input)
  : AstBase(At), IEquatable<ParameterAst>, IAstDescribed
{
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  public ConstantAst? Default { get; set; }

  internal override string Abbr => "P";

  public string Description => Input.Description;

  internal ParameterAst(TokenAt at, string input)
    : this(at, new InputReferenceAst(at, input)) { }

  public bool Equals(ParameterAst? other)
    => base.Equals(other)
    && Input.NullEqual(other.Input)
    && Modifiers.SequenceEqual(other.Modifiers)
    && Default.NullEqual(other.Default);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Input, Modifiers.Length, Default);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Input.GetFields())
      .Concat(Modifiers.AsString())
      .Append(Default is null ? "" : "=" + Default.ToString());
}
