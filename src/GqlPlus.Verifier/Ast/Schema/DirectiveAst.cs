namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class DirectiveAst(ParseAt At, string Name, string Description)
  : AstDeclaration(At, Name, Description), IEquatable<DirectiveAst>
{
  public DirectiveOption Option { get; set; } = DirectiveOption.Unique;
  public ParameterAst[] Parameters { get; set; } = Array.Empty<ParameterAst>();
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override string Abbr => "D";
  internal override string GroupName => "Directives";

  public DirectiveAst(ParseAt at, string name)
    : this(at, name, "") { }

  public bool Equals(DirectiveAst? other)
    => base.Equals(other)
    && Option == other.Option
    && Parameters.SequenceEqual(other.Parameters)
    && Locations == other.Locations;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Parameters.Bracket("(", ")"))
      .Append($"({Option})")
      .Append(Locations.ToString());
}

public enum DirectiveOption
{
  Unique,
  Repeatable,
}

[Flags]
public enum DirectiveLocation
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
