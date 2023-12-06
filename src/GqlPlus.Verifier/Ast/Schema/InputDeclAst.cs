using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class InputDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<InputFieldAst, InputReferenceAst>(At, Name, Description)
{
  internal override string Abbr => "I";

  public InputDeclAst(TokenAt at, string name)
    : this(at, name, "") { }
}
