﻿namespace GqlPlus.Verifier.Ast;

internal abstract record class AstNamedDirectives(string Name)
  : AstNamed(Name), AstDirectives, IEquatable<AstNamedDirectives>
{
  public DirectiveAst[] Directives { get; set; } = Array.Empty<DirectiveAst>();

  public virtual bool Equals(AstNamedDirectives? other)
    => base.Equals(other)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine((AstNamed)this, Directives);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Directives.Select(d => $"{d}"));
}
