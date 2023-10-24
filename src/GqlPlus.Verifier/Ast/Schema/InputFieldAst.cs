namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class InputFieldAst(ParseAt At, string Name, string Description, InputReferenceAst Type)
  : AstAliased(At, Name, Description), IEquatable<InputFieldAst>
{
  internal override string Abbr => "IF";

  public InputFieldAst(ParseAt at, string name, InputReferenceAst fieldType)
    : this(at, name, "", fieldType) { }

  public bool Equals(InputFieldAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(":")
      .Concat(Type.GetFields());
}
