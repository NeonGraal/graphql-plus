namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class InputAst(ParseAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<InputAst>
{
  public InputReferenceAst? Extends { get; set; }
  public InputFieldAst[] Fields { get; set; } = Array.Empty<InputFieldAst>();
  public InputReferenceAst[] Alternates { get; set; } = Array.Empty<InputReferenceAst>();

  internal override string Abbr => "I";

  public InputAst(ParseAt at, string name)
    : this(at, name, "") { }

  public bool Equals(InputAst? other)
    => base.Equals(other)
      && Extends.NullEqual(other.Extends)
      && Fields.SequenceEqual(other.Fields)
      && Alternates.OrderedEqual(other.Alternates);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Extends, Fields.Length, Alternates.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Extends.Bracket("", ""))
      .Concat(Fields.Bracket("{", "}"))
      .Concat(Alternates.Bracket("|"));
}
