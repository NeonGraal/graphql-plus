using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal sealed record class DirectiveAst(
  ITokenAt At,
  string Identifier
) : AstIdentified(At, Identifier)
  , IGqlpDirective
{
  public IGqlpArg? Arg { get; set; }

  internal override string Abbr => "d";

  IGqlpArg? IGqlpDirective.Arg => Arg;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Concat(Arg.Bracket("(", ")"));
}
