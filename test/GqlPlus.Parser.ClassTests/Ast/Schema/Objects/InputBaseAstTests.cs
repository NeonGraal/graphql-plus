namespace GqlPlus.Ast.Schema.Objects;

public class InputBaseAstTests
  : AstObjectBaseTests
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<InputBaseAst, InputArgAst> _checks
    = new(name => new InputBaseAst(AstNulls.At, name), arguments => arguments.InputArgs());

  internal override IAstObjBaseChecks ObjBaseChecks => _checks;
}
