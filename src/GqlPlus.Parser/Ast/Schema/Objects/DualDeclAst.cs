using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class DualDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<DualFieldAst, IGqlpDualBase>(At, Name, Description)
  , IGqlpDualObject
{
  internal override string Abbr => "Du";
  public override string Label => "Dual";

  IEnumerable<IGqlpDualField> IGqlpObject<IGqlpDualField, IGqlpDualBase>.Fields => Fields;
  IEnumerable<IGqlpAlternate<IGqlpDualBase>> IGqlpObject<IGqlpDualField, IGqlpDualBase>.Alternates
    => Alternates.Cast<IGqlpAlternate<IGqlpDualBase>>();
  IGqlpDualBase? IGqlpType<IGqlpDualBase>.Parent => Parent;

  public DualDeclAst(TokenAt at, string name)
    : this(at, name, "")
  { }
}
