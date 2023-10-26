namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class InputFieldAst(ParseAt At, string Name, string Description, InputReferenceAst Type)
  : AstField<InputReferenceAst>(At, Name, Description, Type), IEquatable<InputFieldAst>
{
  public ConstantAst? Default { get; set; }

  internal override string Abbr => "IF";

  public InputFieldAst(ParseAt at, string name, InputReferenceAst fieldType)
    : this(at, name, "", fieldType) { }

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
      .Append(Default is null ? "" : "=" + Default.ToString());
}
