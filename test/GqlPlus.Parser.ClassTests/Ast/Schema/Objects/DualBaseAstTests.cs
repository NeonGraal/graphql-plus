namespace GqlPlus.Ast.Schema.Objects;

public class DualBaseAstTests
  : AstObjBaseTests<DualBaseAst>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<DualBaseAst> _checks
    = new(name => new DualBaseAst(AstNulls.At, name), arguments => arguments.DualBases());

  internal override IAstObjBaseChecks<DualBaseAst> ObjBaseChecks => _checks;
}
