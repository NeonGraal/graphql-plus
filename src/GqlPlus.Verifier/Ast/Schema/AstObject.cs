using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstObject<F, R>(TokenAt At, string Name, string Description)
  : AstType(At, Name, Description), IEquatable<AstObject<F, R>>
  where F : AstField<R> where R : AstReference<R>, IEquatable<R>
{
  public TypeParameterAst[] TypeParameters { get; set; } = [];
  public R? Extends { get; set; }
  public F[] Fields { get; set; } = [];
  public AlternateAst<R>[] Alternates { get; set; } = [];

  public virtual bool Equals(AstObject<F, R>? other)
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
