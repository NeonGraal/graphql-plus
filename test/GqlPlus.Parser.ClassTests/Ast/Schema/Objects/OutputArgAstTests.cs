using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputArgAstTests
  : AstObjectArgTests<IGqlpObjArg>
{
  private readonly AstObjArgChecks<IGqlpObjArg, OutputArgAst> _checks
    = new(name => new OutputArgAst(AstNulls.At, name));

  internal override IAstObjArgChecks<IGqlpObjArg> ObjArgChecks => _checks;
}
