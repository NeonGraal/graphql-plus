namespace GqlPlus.Ast.Schema.Objects;

public class DualBaseAstTests
  : AstObjectBaseTests
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<DualBaseAst, DualArgAst> _checks
    = new(name => new DualBaseAst(AstNulls.At, name), arguments => arguments.DualArgs());

  internal override IAstObjBaseChecks ObjBaseChecks => _checks;
}
