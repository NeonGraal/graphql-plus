namespace GqlPlus.Ast.Operation;

internal sealed record class DirectiveAst(
  ITokenAt At,
  string Identifier
) : AstIdentified(At, Identifier)
  , IAstDirective
{
  public IAstArg? Arg { get; set; }

  internal override string Abbr => "d";

  IAstArg? IAstDirective.Arg => Arg;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Concat(Arg.Bracket("(", ")"));
}
