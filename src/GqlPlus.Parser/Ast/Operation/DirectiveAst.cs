using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class DirectiveAst(TokenAt At, string Name)
  : AstNamed(At, Name)
  , IGqlpDirective
{
  public ArgAst? Arg { get; set; }

  internal override string Abbr => "d";

  IGqlpArg? IGqlpDirective.Arg => Arg;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Concat(Arg.Bracket("(", ")"));
}
