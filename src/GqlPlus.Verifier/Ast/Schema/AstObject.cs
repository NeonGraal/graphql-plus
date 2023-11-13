﻿namespace GqlPlus.Verifier.Ast.Schema;

internal abstract record class AstObject<F, R>(ParseAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<AstObject<F, R>>
  where F : AstField<R> where R : AstReference<R>, IEquatable<R>
{
  public TypeParameterAst[] Parameters { get; set; } = Array.Empty<TypeParameterAst>();
  public R? Extends { get; set; }
  public F[] Fields { get; set; } = Array.Empty<F>();
  public AstAlternate<R>[] Alternates { get; set; } = Array.Empty<AstAlternate<R>>();

  public virtual bool Equals(AstObject<F, R>? other)
    => base.Equals(other)
      && Parameters.SequenceEqual(other.Parameters)
      && Extends.NullEqual(other.Extends)
      && Fields.SequenceEqual(other.Fields)
      && Alternates.SequenceEqual(other.Alternates);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parameters.Length, Extends, Fields.Length, Alternates.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Parameters.Bracket("<", ">"))
      .Concat(Extends.Bracket("", ""))
      .Concat(Fields.Bracket("{", "}"))
      .Concat(Alternates.Bracket("|"));
}
