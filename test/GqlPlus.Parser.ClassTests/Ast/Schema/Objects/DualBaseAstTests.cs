using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualBaseAstTests
  : AstObjectBaseTests<IGqlpDualBase, DualBaseAst>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<IGqlpDualBase, DualBaseAst> _checks
    = new(name => new DualBaseAst(AstNulls.At, name), arguments => arguments.DualBases());

  internal override IAstObjBaseChecks<IGqlpDualBase, DualBaseAst> ObjBaseChecks => _checks;
}
