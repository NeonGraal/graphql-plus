namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class DirectiveAst(ParseAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<DirectiveAst>
{
  public DirectiveOption Option { get; set; } = DirectiveOption.Unique;
  public ParameterAst? Parameter { get; set; }
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override string Abbr => "D";

  public DirectiveAst(ParseAt at, string name)
    : this(at, name, "") { }

  public bool Equals(DirectiveAst? other)
    => base.Equals(other)
    && Option == other.Option;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(AstExtensions.Bracket("(", ")", new[] { Parameter }))
      .Append($"({Option})")
      .Append(Locations.ToString());
}

internal enum DirectiveOption
{
  Unique,
  Repeatable,
}

[Flags]
internal enum DirectiveLocation
{
  None = 0,
  All = 63,

  Operation = 1,
  Variable = 2,
  Field = 4,
  Inline = 8,
  Spread = 16,
  Fragment = 32,
}
