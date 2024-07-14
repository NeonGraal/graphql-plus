using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class DirectiveDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description)
  , IEquatable<DirectiveDeclAst>
  , IGqlpSchemaDirective
{
  public DirectiveOption Option { get; set; } = DirectiveOption.Unique;
  public IGqlpInputParam[] Params { get; set; } = [];
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override string Abbr => "Di";
  public override string Label => "Directive";

  IEnumerable<IGqlpInputParam> IGqlpSchemaDirective.Params => Params;
  DirectiveOption IGqlpSchemaDirective.DirectiveOption => Option;
  DirectiveLocation IGqlpSchemaDirective.Locations => Locations;

  public DirectiveDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(DirectiveDeclAst? other)
    => base.Equals(other)
    && Option == other.Option
    && Params.SequenceEqual(other.Params)
    && Locations == other.Locations;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Params.Bracket("(", ")"))
      .Append($"({Option})")
      .Append(Locations.ToString());
}
