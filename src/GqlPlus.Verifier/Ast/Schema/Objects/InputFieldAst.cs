using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class InputFieldAst(TokenAt At, string Name, string Description, InputBaseAst Type)
  : AstObjectField<InputBaseAst>(At, Name, Description, Type), IEquatable<InputFieldAst>
{
  public ConstantAst? Default { get; set; }

  internal override string Abbr => "IF";

  public InputFieldAst(TokenAt at, string name, InputBaseAst typeBase)
    : this(at, name, "", typeBase) { }

  public bool Equals(InputFieldAst? other)
    => base.Equals(other)
    && Default.NullEqual(other.Default);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Default);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(":")
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString())
      .Append(Default.Prefixed("="));
}
