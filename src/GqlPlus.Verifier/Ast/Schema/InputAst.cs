namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class InputAst(ParseAt At, string Name, string Description)
  : ObjectAst<InputFieldAst, InputReferenceAst>(At, Name, Description)
{
  internal override string Abbr => "I";

  public InputAst(ParseAt at, string name)
    : this(at, name, "") { }
}
