namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class InputFieldAst(ParseAt At, string Name, string Description, InputReferenceAst Type)
  : AstAliased(At, Name, Description), IEquatable<InputFieldAst>
{
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  public ConstantAst? Default { get; set; }

  internal override string Abbr => "IF";

  public InputFieldAst(ParseAt at, string name, InputReferenceAst fieldType)
    : this(at, name, "", fieldType) { }

  public bool Equals(InputFieldAst? other)
    => base.Equals(other)
    && Type.Equals(other.Type)
    && Modifiers.SequenceEqual(other.Modifiers)
    && Default.NullEqual(other.Default);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length, Default);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(":")
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString())
      .Append(Default is null ? "" : "=" + Default.ToString());
}
