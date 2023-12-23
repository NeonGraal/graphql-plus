using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Operation;

public sealed record class VariableAst(TokenAt At, string Name)
  : AstDirectives(At, Name), IEquatable<VariableAst>
{
  public string? Type { get; set; }
  public ModifierAst[] Modifers { get; set; } = Array.Empty<ModifierAst>();
  public ConstantAst? Default { get; set; }

  internal override string Abbr => "v";

  public bool Equals(VariableAst? other)
    => base.Equals(other)
    && Type.NullEqual(other.Type)
    && Modifers.SequenceEqual(other.Modifers)
    && Default.NullEqual(other.Default);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifers.Length, Default);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Type.Prefixed(":"))
      .Concat(Modifers.AsString())
      .Append(Default.Prefixed("="));
}
