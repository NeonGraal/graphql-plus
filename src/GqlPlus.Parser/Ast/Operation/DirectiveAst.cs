using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class DirectiveAst(TokenAt At, string Name)
  : AstNamed(At, Name)
  , IGqlpDirective
{
  public ArgumentAst? Argument { get; set; }

  internal override string Abbr => "d";

  IGqlpArgument? IGqlpDirective.Argument => Argument;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Concat(Argument.Bracket("(", ")"));
}
