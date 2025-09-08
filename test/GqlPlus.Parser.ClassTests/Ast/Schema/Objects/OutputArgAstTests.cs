using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputArgAstTests
  : AstObjectArgTests<IGqlpOutputArg>
{
  private readonly AstObjArgChecks<IGqlpOutputArg, OutputArgAst> _checks
    = new(name => new OutputArgAst(AstNulls.At, name));

  internal override IAstObjArgChecks<IGqlpOutputArg> ObjArgChecks => _checks;
}
