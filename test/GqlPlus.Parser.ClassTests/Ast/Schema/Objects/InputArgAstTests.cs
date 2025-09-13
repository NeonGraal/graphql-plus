using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputArgAstTests
  : AstObjectArgTests<IGqlpObjArg>
{
  private readonly AstObjArgChecks<IGqlpObjArg, InputArgAst> _checks
    = new(name => new InputArgAst(AstNulls.At, name));

  internal override IAstObjArgChecks<IGqlpObjArg> ObjArgChecks => _checks;
}
