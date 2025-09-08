using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualArgAstTests
  : AstObjectArgTests<IGqlpDualArg>
{
  private readonly AstObjArgChecks<IGqlpDualArg, DualArgAst> _checks
    = new(name => new DualArgAst(AstNulls.At, name));

  internal override IAstObjArgChecks<IGqlpDualArg> ObjArgChecks => _checks;
}
