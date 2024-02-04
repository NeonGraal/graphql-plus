﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstObject<TField, TReference>(TokenAt At, string Name, string Description)
  : AstType<TReference>(At, Name, Description), IEquatable<AstObject<TField, TReference>>, IAstObject
  where TField : AstField<TReference> where TReference : AstReference<TReference>, IEquatable<TReference>
{
  public TypeParameterAst[] TypeParameters { get; set; } = [];
  public TField[] Fields { get; set; } = [];
  public AstAlternate<TReference>[] Alternates { get; set; } = [];

  public virtual bool Equals(AstObject<TField, TReference>? other)
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
