using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public abstract record class AstObject<TField, TRef>(TokenAt At, string Name, string Description)
  : AstType<TRef>(At, Name, Description), IEquatable<AstObject<TField, TRef>>, IAstObject
  where TField : AstObjectField<TRef> where TRef : AstReference<TRef>, IEquatable<TRef>
{
  public TypeParameterAst[] TypeParameters { get; set; } = [];
  public TField[] Fields { get; set; } = [];
  public AstAlternate<TRef>[] Alternates { get; set; } = [];

  public virtual bool Equals(AstObject<TField, TRef>? other)
    => base.Equals(other)
      && TypeParameters.SequenceEqual(other.TypeParameters)
      && Fields.SequenceEqual(other.Fields)
      && Alternates.SequenceEqual(other.Alternates);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), TypeParameters.Length, Fields.Length, Alternates.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeParameters.Bracket("<", ">"))
      .Concat(Parent.Bracket(":", ""))
      .Concat(Fields.Bracket("{", "}"))
      .Concat(Alternates.Bracket("|"));
}

public interface IAstObject : IAstType
{
  TypeParameterAst[] TypeParameters { get; }
}
