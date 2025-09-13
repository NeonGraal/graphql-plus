using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualArgAstTests
  : AstObjectArgTests<IGqlpObjArg>
{
  private readonly AstObjArgChecks<IGqlpObjArg, DualArgAst> _checks
    = new(name => new DualArgAst(AstNulls.At, name));

  internal override IAstObjArgChecks<IGqlpObjArg> ObjArgChecks => _checks;
}
