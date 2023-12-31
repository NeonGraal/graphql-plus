using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OptionDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description), IEquatable<OptionDeclAst>
{
  public IMap<ConstantAst> Settings { get; set; } = Map<ConstantAst>.Empty();

  internal override string Abbr => "O";

  public OptionDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(OptionDeclAst? other)
    => base.Equals(other)
    && Settings.SequenceEqual(other.Settings);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Settings.Count);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Concat(Settings.Bracket("{", "}", kv => $"{kv.Key}={kv.Value}"));
}
