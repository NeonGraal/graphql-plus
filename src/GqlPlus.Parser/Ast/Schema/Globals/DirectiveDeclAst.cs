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
  public ParameterAst[] Parameters { get; set; } = [];
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override string Abbr => "Di";
  public override string Label => "Directive";

  IEnumerable<IGqlpInputParameter> IGqlpSchemaDirective.Parameters => Parameters;
  DirectiveOption IGqlpSchemaDirective.DirectiveOption => Option;
  DirectiveLocation IGqlpSchemaDirective.Locations => Locations;

  public DirectiveDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(DirectiveDeclAst? other)
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
