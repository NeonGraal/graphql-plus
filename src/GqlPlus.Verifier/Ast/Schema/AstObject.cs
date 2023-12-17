using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstObject<TField, TReference>(TokenAt At, string Name, string Description)
  : AstType(At, Name, Description), IEquatable<AstObject<TField, TReference>>, IAstObject
  where TField : AstField<TReference> where TReference : AstReference<TReference>, IEquatable<TReference>
{
  public TypeParameterAst[] TypeParameters { get; set; } = [];
  public TReference? Extends { get; set; }
  public TField[] Fields { get; set; } = [];
  public AlternateAst<TReference>[] Alternates { get; set; } = [];

  public abstract string Label { get; }

  public virtual bool Equals(AstObject<TField, TReference>? other)
    => base.Equals(other)
      && TypeParameters.SequenceEqual(other.TypeParameters)
      && Extends.NullEqual(other.Extends)
      && Fields.SequenceEqual(other.Fields)
      && Alternates.SequenceEqual(other.Alternates);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), TypeParameters.Length, Extends, Fields.Length, Alternates.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeParameters.Bracket("<", ">"))
      .Concat(Extends.Bracket(":", ""))
      .Concat(Fields.Bracket("{", "}"))
      .Concat(Alternates.Bracket("|"));
}

public interface IAstObject
{
  string Name { get; }
  TypeParameterAst[] TypeParameters { get; }
  string Label { get; }
}
