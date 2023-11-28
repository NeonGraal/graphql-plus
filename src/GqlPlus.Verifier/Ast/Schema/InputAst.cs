namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class InputAst(ParseAt At, string Name, string Description)
  : AstObject<InputFieldAst, InputReferenceAst>(At, Name, Description)
{
  internal override string Abbr => "I";

  public InputAst(ParseAt at, string name)
    : this(at, name, "") { }
}
