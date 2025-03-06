using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class DualArgAstTests
  : AstObjectArgTests<IGqlpDualArg>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjArgChecks<IGqlpDualArg, DualArgAst> _checks
    = new(name => new DualArgAst(AstNulls.At, name));

  internal override IAstObjArgChecks<IGqlpDualArg> ObjArgChecks => _checks;
}
