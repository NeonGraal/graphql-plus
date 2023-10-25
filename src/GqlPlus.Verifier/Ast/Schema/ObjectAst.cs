namespace GqlPlus.Verifier.Ast.Schema;

internal abstract record class ObjectAst<F, R>(ParseAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<ObjectAst<F, R>>
  where R : AstNamed, IEquatable<R>
{
  public TypeParameterAst[] Parameters { get; set; } = Array.Empty<TypeParameterAst>();
  public R? Extends { get; set; }
  public F[] Fields { get; set; } = Array.Empty<F>();
  public R[] Alternates { get; set; } = Array.Empty<R>();

  public ObjectAst(ParseAt at, string name)
    : this(at, name, "") { }

  public virtual bool Equals(ObjectAst<F, R>? other)
    => base.Equals(other)
      && Parameters.SequenceEqual(other.Parameters)
      && Extends.NullEqual(other.Extends)
      && Fields.SequenceEqual(other.Fields)
      && Alternates.OrderedEqual(other.Alternates);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parameters.Length, Extends, Fields.Length, Alternates.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Parameters.Bracket("<", ">"))
      .Concat(Extends.Bracket("", ""))
      .Concat(Fields.Bracket("{", "}"))
      .Concat(Alternates.Bracket("|"));
}
