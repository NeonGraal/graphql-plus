using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class OutputDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<OutputFieldAst, OutputBaseAst>(At, Name, Description)
  , IGqlpOutputObject
{
  internal override string Abbr => "Ou";
  public override string Label => "Output";

  IEnumerable<IGqlpOutputField> IGqlpObject<IGqlpOutputField, IGqlpOutputBase>.Fields => Fields;
  IEnumerable<IGqlpAlternate<IGqlpOutputBase>> IGqlpObject<IGqlpOutputField, IGqlpOutputBase>.Alternates
    => Alternates.Cast<IGqlpAlternate<IGqlpOutputBase>>();
  IGqlpOutputBase? IGqlpType<IGqlpOutputBase>.Parent => Parent;

  public OutputDeclAst(TokenAt at, string name)
    : this(at, name, "") { }
}
