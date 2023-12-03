namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class TypeParameterAst(TokenAt At, string Name, string Description)
  : AstDescribed(At, Name, Description), IEquatable<TypeParameterAst>
{
  internal override string Abbr => "T";

  internal TypeParameterAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override IEnumerable<string?> GetFields()
    => new[] { At.ToString(), Description.Quoted("\""), Name.Prefixed("$") };
}
