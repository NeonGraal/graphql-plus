using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class DirectiveDeclAst(
  ITokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description)
  , IGqlpSchemaDirective
{
  public DirectiveOption Option { get; set; } = DirectiveOption.Unique;
  public IGqlpInputParam? Parameter { get; set; }
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override string Abbr => "Di";
  public override string Label => "Directive";

  DirectiveOption IGqlpSchemaDirective.DirectiveOption => Option;
  DirectiveLocation IGqlpSchemaDirective.Locations => Locations;

  public DirectiveDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(DirectiveDeclAst? other)
    => other is IGqlpSchemaDirective directive && Equals(directive);
  public bool Equals(IGqlpSchemaDirective? other)
    => base.Equals(other)
    && Option == other.DirectiveOption
    && Parameter.NullEqual(other.Parameter)
    && Locations == other.Locations;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Parameter.Bracket("(", ")"))
      .Append($"({Option})")
      .Append(Locations.ToString());
}
