using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class DirectiveAst(
  ITokenAt At,
  string Identifier
) : AstIdentified(At, Identifier)
  , IGqlpDirective
{
  public ArgAst? Arg { get; set; }

  internal override string Abbr => "d";

  IGqlpArg? IGqlpDirective.Arg => Arg;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Concat(Arg.Bracket("(", ")"));
}
