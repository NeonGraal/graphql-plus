using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal sealed record class DirectiveAst(
  ITokenAt At,
  string Identifier
) : AstIdentified(At, Identifier)
  , IAstDirective
{
  public IGqlpArg? Arg { get; set; }

  internal override string Abbr => "d";

  IGqlpArg? IAstDirective.Arg => Arg;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Concat(Arg.Bracket("(", ")"));
}
