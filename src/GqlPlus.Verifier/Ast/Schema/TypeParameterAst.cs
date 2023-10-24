namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class TypeParameterAst(ParseAt At, string Name, string Description)
  : AstDescribed(At, Name, Description), IEquatable<TypeParameterAst>
{

  internal override string Abbr => "T";

  internal TypeParameterAst(ParseAt at, string name)
    : this(at, name, "") { }

  public bool Equals(ParameterAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();

  internal override IEnumerable<string?> GetFields()
    => new[] { At.ToString(), Description.Quoted("\""), Name.Prefixed("$") };
}
