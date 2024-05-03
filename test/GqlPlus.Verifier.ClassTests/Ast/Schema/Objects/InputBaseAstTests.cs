namespace GqlPlus.Verifier.Ast.Schema.Objects;

public class InputBaseAstTests
  : AstObjBaseTests<InputBaseAst>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<InputBaseAst> _checks
    = new(name => new InputBaseAst(AstNulls.At, name), arguments => arguments.InputBases());

  internal override IAstObjBaseChecks<InputBaseAst> ObjBaseChecks => _checks;
}
